using Microsoft.AspNetCore.Mvc;
using StudentAttendanceMVC.Models;

namespace StudentAttendanceMVC.Controllers
{
    public class SchedulesController : Controller
    {
        // Dữ liệu giả lập lịch dạy giảng viên
        private List<Schedule> GetLecturerSchedules()
        {
            return new List<Schedule>
            {
                new Schedule { Id = 1, CourseName = "Lập trình Web", LecturerName = "Giảng viên A", Date = DateTime.Today, Time = "08:00 - 10:00", Room = "Phòng 101" },
                new Schedule { Id = 2, CourseName = "Cơ sở dữ liệu", LecturerName = "Giảng viên A", Date = DateTime.Today.AddDays(1), Time = "13:00 - 15:00", Room = "Phòng 102" }
            };
        }

        // Dữ liệu giả lập lịch học sinh viên (đồng bộ với lịch dạy)
        private List<Schedule> GetStudentSchedules()
        {
            return new List<Schedule>
            {
                new Schedule { Id = 1, CourseName = "Lập trình Web", StudentName = "Sinh viên X", Date = DateTime.Today, Time = "08:00 - 10:00", Room = "Phòng 101" },
                new Schedule { Id = 2, CourseName = "Cơ sở dữ liệu", StudentName = "Sinh viên X", Date = DateTime.Today.AddDays(1), Time = "13:00 - 15:00", Room = "Phòng 102" }
            };
        }

        public IActionResult LecturerSchedule()
        {
            var schedules = GetLecturerSchedules();
            return View(schedules);
        }

        public IActionResult StudentSchedule()
        {
            var schedules = GetStudentSchedules();
            return View(schedules);
        }
    }
}