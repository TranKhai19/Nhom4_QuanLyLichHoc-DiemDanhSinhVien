using Microsoft.AspNetCore.Mvc;
using StudentAttendanceMVC.Models;

namespace StudentAttendanceMVC.Controllers
{
    public class AttendanceController : Controller
    {
        // Dữ liệu giả lập lớp học
        private List<ClassSession> GetClasses()
        {
            return new List<ClassSession>
            {
                new ClassSession
                {
                    Id = 1,
                    CourseName = "Lập trình Web",
                    Date = DateTime.Today,
                    Time = "08:00 - 10:00", // Thêm Time
                    Room = "Phòng 101",    // Thêm Room
                    Students = new List<Student>
                    {
                        new Student { Id = 1, Name = "Sinh viên X" },
                        new Student { Id = 2, Name = "Sinh viên Y" },
                        new Student { Id = 3, Name = "Sinh viên Z" }
                    }
                },
                new ClassSession
                {
                    Id = 2,
                    CourseName = "Cơ sở dữ liệu",
                    Date = DateTime.Today.AddDays(1),
                    Time = "13:00 - 15:00", // Thêm Time
                    Room = "Phòng 102",     // Thêm Room
                    Students = new List<Student>
                    {
                        new Student { Id = 1, Name = "Sinh viên X" },
                        new Student { Id = 2, Name = "Sinh viên Y" }
                    }
                }
            };
        }

        // Giả lập cập nhật điểm danh (sau này dùng POST)
        [HttpPost]
        public IActionResult UpdateAttendance(int classId, List<int> attendedStudentIds)
        {
            var classes = GetClasses();
            var selectedClass = classes.FirstOrDefault(c => c.Id == classId);
            if (selectedClass != null)
            {
                // Giả lập cập nhật
                foreach (var student in selectedClass.Students)
                {
                    student.Attended = attendedStudentIds.Contains(student.Id);
                }
            }
            TempData["Success"] = "Điểm danh đã được cập nhật!";
            return RedirectToAction("LecturerAttendance");
        }

        // Giả lập tải file (sau này dùng backend thực)
        public IActionResult DownloadAttendance(int classId)
        {
            TempData["DownloadMessage"] = "File điểm danh đã được tải (giả lập: attendance.csv)";
            return RedirectToAction("AdminAttendance");
        }

        public IActionResult LecturerAttendance()
        {
            var classes = GetClasses();
            return View(classes);
        }

        public IActionResult StudentAttendance()
        {
            var classes = GetClasses();
            var todaySchedules = classes.Where(c => c.Date.Date == DateTime.Today.Date).ToList();
            return View(todaySchedules);
        }

        public IActionResult AdminAttendance()
        {
            var classes = GetClasses();
            return View(classes);
        }
    }
}