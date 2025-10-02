using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StudentAttendanceMVC.Data;
using StudentAttendanceMVC.Models;
using ClosedXML.Excel;
using System.IO;

namespace StudentAttendanceMVC.Controllers
{
    [Authorize]
    public class AttendanceController : Controller
    {
        private readonly AppDbContext _context;

        public AttendanceController(AppDbContext context)
        {
            _context = context;
        }

        [Authorize(Roles = "Lecturer, Admin")]
        public IActionResult LecturerAttendance()
        {
            var classes = _context.ClassSessions
                .Include(c => c.Students) // Load sinh viên để hiển thị trạng thái
                .ToList();
            return View(classes);
        }

        [HttpPost]
        [Authorize(Roles = "Lecturer, Admin")]
        public IActionResult UpdateAttendance(int classId, List<int> attendedStudentIds)
        {
            var selectedClass = _context.ClassSessions
                .Include(c => c.Students)
                .FirstOrDefault(c => c.Id == classId);
            if (selectedClass != null)
            {
                foreach (var student in selectedClass.Students)
                {
                    student.Attended = attendedStudentIds.Contains(student.Id);
                }
                _context.SaveChanges();
                TempData["Success"] = "Điểm danh đã được cập nhật thành công!";
            }
            else
            {
                TempData["Error"] = "Không tìm thấy lớp.";
            }

            // Reload model để hiển thị danh sách lớp sau khi lưu
            var classes = _context.ClassSessions
                .Include(c => c.Students)
                .ToList();
            return View("LecturerAttendance", classes);
        }

        [Authorize(Roles = "Student, Admin")]
        public IActionResult StudentAttendance()
        {
            var currentUser = User.Identity.Name; // Lấy tên sinh viên hiện tại
            var classes = _context.ClassSessions
                .Include(c => c.Students)
                .Where(c => c.Students.Any(s => s.Name == currentUser)) // Lọc lớp của sinh viên
                .ToList();
            return View(classes);
        }

        [Authorize(Roles = "Admin")]
        public IActionResult AdminAttendance(int? classId = null)
        {
            var classes = _context.ClassSessions
                .Include(c => c.Students)
                .ToList();

            ViewBag.ClassSessions = classes; // Để dropdown chọn lớp
            ViewBag.SelectedClassId = classId;

            if (classId.HasValue)
            {
                var selectedClass = classes.FirstOrDefault(c => c.Id == classId.Value);
                if (selectedClass != null)
                {
                    ViewBag.SelectedClass = selectedClass;
                }
            }

            return View();
        }

        [HttpGet]
        [Authorize(Roles = "Admin")]
        public IActionResult GetClassStudents(int classId)
        {
            var classSession = _context.ClassSessions
                .Include(c => c.Students)
                .FirstOrDefault(c => c.Id == classId);
            if (classSession == null)
            {
                return Json(new { success = false, message = "Không tìm thấy lớp." });
            }

            var students = classSession.Students.Select(s => new
            {
                Name = s.Name,
                Attended = s.Attended ? "Có" : "Vắng"
            }).ToList();

            return Json(new { success = true, students = students, className = classSession.CourseName, date = classSession.Date.ToShortDateString() });
        }

        [Authorize(Roles = "Admin")]
        public IActionResult DownloadAttendanceExcel(int classId)
        {
            var classSession = _context.ClassSessions
                .Include(c => c.Students)
                .FirstOrDefault(c => c.Id == classId);
            if (classSession == null)
            {
                return NotFound("Không tìm thấy lớp.");
            }

            using (var workbook = new XLWorkbook())
            {
                var worksheet = workbook.Worksheets.Add(classSession.CourseName);
                worksheet.Cell(1, 1).Value = "Tên Sinh Viên";
                worksheet.Cell(1, 2).Value = "Trạng Thái";

                for (int i = 0; i < classSession.Students.Count; i++)
                {
                    worksheet.Cell(i + 2, 1).Value = classSession.Students[i].Name;
                    worksheet.Cell(i + 2, 2).Value = classSession.Students[i].Attended ? "Có" : "Vắng";
                }

                worksheet.Columns().AdjustToContents();

                using (var stream = new MemoryStream())
                {
                    workbook.SaveAs(stream);
                    return File(stream.ToArray(), "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "attendance.xlsx");
                }
            }
        }

    }
}