using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StudentAttendanceMVC.Data;
using StudentAttendanceMVC.Models;

namespace StudentAttendanceMVC.Controllers
{
    [Authorize]
    public class SchedulesController : Controller
    {
        private readonly AppDbContext _context;

        public SchedulesController(AppDbContext context)
        {
            _context = context;
        }

        [Authorize(Roles = "Lecturer, Admin")]
        public IActionResult LecturerSchedule(DateTime? dateFilter = null, string viewMode = "day")
        {
            var currentUser = User.Identity.Name;
            var classSessions = _context.ClassSessions
                .Include(c => c.Students)
                .Where(c => _context.Schedules.Any(s => s.Id == c.ScheduleId && s.LecturerName == currentUser && s.IsActive))
                .ToList();

            if (viewMode == "week")
            {
                var startOfWeek = dateFilter?.AddDays(-(int)dateFilter.Value.DayOfWeek) ?? DateTime.Today.AddDays(-(int)DateTime.Today.DayOfWeek);
                var endOfWeek = startOfWeek.AddDays(6);
                classSessions = classSessions.Where(c => c.Date.Date >= startOfWeek.Date && c.Date.Date <= endOfWeek.Date).ToList();
            }
            else if (dateFilter.HasValue)
            {
                classSessions = classSessions.Where(c => c.Date.Date == dateFilter.Value.Date).ToList();
            }

            ViewBag.DateFilter = dateFilter ?? DateTime.Today;
            ViewBag.ViewMode = viewMode;
            return View(classSessions);
        }

        [Authorize(Roles = "Student, Admin")]
        public IActionResult StudentSchedule(DateTime? dateFilter = null, string viewMode = "day")
        {
            var currentUser = User.Identity.Name;
            var schedules = _context.Schedules
                .Where(s => s.StudentName != string.Empty && s.IsActive && s.StudentName == currentUser)
                .ToList();

            if (viewMode == "week")
            {
                var startOfWeek = dateFilter?.AddDays(-(int)dateFilter.Value.DayOfWeek) ?? DateTime.Today.AddDays(-(int)DateTime.Today.DayOfWeek);
                var endOfWeek = startOfWeek.AddDays(6);
                schedules = schedules.Where(s => s.Date.Date >= startOfWeek.Date && s.Date.Date <= endOfWeek.Date).ToList();
            }
            else if (dateFilter.HasValue)
            {
                schedules = schedules.Where(s => s.Date.Date == dateFilter.Value.Date).ToList();
            }

            ViewBag.DateFilter = dateFilter ?? DateTime.Today;
            ViewBag.ViewMode = viewMode;
            return View(schedules);
        }

        [Authorize(Roles = "Lecturer, Admin")]
        public IActionResult LecturerStudents(int? classId = null)
        {
            var currentUser = User.Identity.Name;
            var classSessions = _context.ClassSessions
                .Include(c => c.Students)
                .Where(c => _context.Schedules.Any(s => s.Id == c.ScheduleId && s.LecturerName == currentUser && s.IsActive))
                .ToList();

            if (classId.HasValue)
            {
                classSessions = classSessions.Where(c => c.Id == classId.Value).ToList();
            }

            ViewBag.ClassSessions = _context.ClassSessions
                .Include(c => c.Students)
                .Where(c => _context.Schedules.Any(s => s.Id == c.ScheduleId && s.LecturerName == currentUser && s.IsActive))
                .ToList();
            ViewBag.ClassId = classId;

            return View(classSessions);
        }

        [HttpGet]
        [Authorize(Roles = "Lecturer, Admin")]
        public IActionResult AttendanceForm(int classId)
        {
            var classSession = _context.ClassSessions
                .Include(c => c.Students)
                .FirstOrDefault(c => c.Id == classId && _context.Schedules.Any(s => s.Id == c.ScheduleId && s.LecturerName == User.Identity.Name && s.IsActive));
            if (classSession == null)
            {
                return NotFound();
            }
            return PartialView("_AttendanceForm", classSession);
        }

        [HttpPost]
        [Authorize(Roles = "Lecturer, Admin")]
        public IActionResult TakeAttendance(int classId, List<int> studentIds, List<bool> attendedStatuses)
        {
            if (classId <= 0 || studentIds == null || attendedStatuses == null || studentIds.Count != attendedStatuses.Count)
            {
                return BadRequest("Dữ liệu điểm danh không hợp lệ.");
            }

            for (int i = 0; i < studentIds.Count; i++)
            {
                var student = _context.Students.Find(studentIds[i]);
                if (student != null && student.ClassSessionId == classId)
                {
                    student.Attended = attendedStatuses[i];
                    _context.Students.Update(student);
                }
            }

            _context.SaveChanges();
            return RedirectToAction("LecturerStudents", new { classId });
        }

        [Authorize(Roles = "Admin")]
        public IActionResult AttendanceReport()
        {
            var attendanceData = _context.Students
                .Include(s => s.ClassSession)
                .Where(s => s.ClassSession != null)
                .Select(s => new
                {
                    StudentName = s.Name,
                    ClassName = s.ClassSession.CourseName,
                    Date = s.ClassSession.Date,
                    Attended = s.Attended
                })
                .ToList();
            return View(attendanceData);
        }
    }
}