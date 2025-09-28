using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using StudentAttendanceMVC.Data;
using StudentAttendanceMVC.Models;
using CsvHelper;
using System.Globalization;
using System.IO;

namespace StudentAttendanceMVC.Controllers
{
    [Authorize]  // Yêu cầu đăng nhập cho tất cả action
    public class AttendanceController : Controller
    {
        private readonly AppDbContext _context;

        public AttendanceController(AppDbContext context)
        {
            _context = context;
        }

        [Authorize(Roles = "Lecturer, Admin")]  // Chỉ Lecturer và Admin vào điểm danh
        public IActionResult LecturerAttendance()
        {
            var classes = _context.ClassSessions.ToList();
            return View(classes);
        }

        [HttpPost]
        [Authorize(Roles = "Lecturer, Admin")]  // Chỉ Lecturer và Admin cập nhật điểm danh
        public IActionResult UpdateAttendance(int classId, List<int> attendedStudentIds)
        {
            var selectedClass = _context.ClassSessions.Find(classId);
            if (selectedClass != null)
            {
                var students = _context.Students.Where(s => s.ClassSessionId == classId).ToList();
                foreach (var student in students)
                {
                    student.Attended = attendedStudentIds.Contains(student.Id);
                }
                _context.SaveChanges();
                TempData["Success"] = "Điểm danh đã được cập nhật vào hệ thống!";
            }
            return RedirectToAction("LecturerAttendance");
        }

        [Authorize(Roles = "Student, Admin")]  // Chỉ Student và Admin xem trạng thái
        public IActionResult StudentAttendance()
        {
            var classes = _context.ClassSessions.Where(c => c.Date.Date == DateTime.Today.Date).ToList();
            return View(classes);
        }

        [Authorize(Roles = "Admin")]  // Chỉ Admin vào quản lý
        public IActionResult AdminAttendance()
        {
            var classes = _context.ClassSessions.ToList();
            return View(classes);
        }

        [HttpGet]
        [Authorize(Roles = "Admin")]  // Chỉ Admin tải file
        public IActionResult DownloadAttendance(int classId)
        {
            var selectedClass = _context.ClassSessions.Find(classId);
            if (selectedClass != null)
            {
                var students = _context.Students.Where(s => s.ClassSessionId == classId).ToList();
                using (var memoryStream = new MemoryStream())
                {
                    using (var writer = new StreamWriter(memoryStream))
                    {
                        using (var csv = new CsvWriter(writer, CultureInfo.InvariantCulture))
                        {
                            csv.WriteRecords(students.Select(s => new
                            {
                                Name = s.Name,
                                Attended = s.Attended ? "Có" : "Vắng"
                            }));
                        }
                    }
                    return File(memoryStream.ToArray(), "text/csv", "attendance.csv");
                }
            }
            TempData["DownloadMessage"] = "Không tìm thấy lớp!";
            return RedirectToAction("AdminAttendance");
        }
    }
}