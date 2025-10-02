using ClosedXML.Excel;
using CsvHelper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StudentAttendanceMVC.Data;
using StudentAttendanceMVC.Models;
using System.Globalization;
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
                // Lưu điểm danh (cho phép mọi trường hợp, không bắt buộc đầy đủ)
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
            return View("LecturerAttendance", classes); // Trả về view với model mới
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

        [Authorize(Roles = "Admin")]
        public IActionResult DownloadAttendanceExcel(int classId = 0)
        {
            IQueryable<Student> studentsQuery = _context.Students.Include(s => s.ClassSession);
            if (classId > 0)
            {
                studentsQuery = studentsQuery.Where(s => s.ClassSessionId == classId);
            }

            var attendanceData = studentsQuery.Select(s => new
            {
                StudentName = s.Name,
                ClassName = s.ClassSession.CourseName,
                Date = s.ClassSession.Date,
                Time = s.ClassSession.Time,
                Room = s.ClassSession.Room,
                Attended = s.Attended ? "Có" : "Vắng"
            }).ToList();

            using (var workbook = new XLWorkbook())
            {
                var worksheet = workbook.Worksheets.Add(classId == 0 ? "Báo Cáo Toàn Bộ" : "Lớp " + classId);
                worksheet.Cell(1, 1).Value = "Tên Sinh Viên";
                worksheet.Cell(1, 2).Value = "Lớp Học";
                worksheet.Cell(1, 3).Value = "Ngày";
                worksheet.Cell(1, 4).Value = "Giờ";
                worksheet.Cell(1, 5).Value = "Phòng";
                worksheet.Cell(1, 6).Value = "Trạng Thái Điểm Danh";

                for (int i = 0; i < attendanceData.Count; i++)
                {
                    worksheet.Cell(i + 2, 1).Value = attendanceData[i].StudentName;
                    worksheet.Cell(i + 2, 2).Value = attendanceData[i].ClassName;
                    worksheet.Cell(i + 2, 3).Value = attendanceData[i].Date.ToString("dd/MM/yyyy");
                    worksheet.Cell(i + 2, 4).Value = attendanceData[i].Time;
                    worksheet.Cell(i + 2, 5).Value = attendanceData[i].Room;
                    worksheet.Cell(i + 2, 6).Value = attendanceData[i].Attended;
                }

                worksheet.Columns().AdjustToContents();

                using (var stream = new MemoryStream())
                {
                    workbook.SaveAs(stream);
                    var fileName = classId == 0 ? "BaoCaoDiemDanhToanBo.xlsx" : $"Lop{classId}_DiemDanh.xlsx";
                    return File(stream.ToArray(), "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", fileName);
                }
            }
        }
    }
}