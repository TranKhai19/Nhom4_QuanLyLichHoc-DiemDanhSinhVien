using ClosedXML.Excel;
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
                return NotFound("Không tìm thấy lớp.");
            }
            return PartialView("_AttendanceForm", classSession);
        }

        [HttpPost]
        [Authorize(Roles = "Lecturer, Admin")]
        public IActionResult TakeAttendance(int classId, Dictionary<int, bool> attended)
        {
            if (classId <= 0)
            {
                return BadRequest("ID lớp không hợp lệ.");
            }

            var classSession = _context.ClassSessions
                .Include(c => c.Students) // Load sinh viên để cập nhật
                .FirstOrDefault(c => c.Id == classId && _context.Schedules.Any(s => s.Id == c.ScheduleId && s.LecturerName == User.Identity.Name && s.IsActive));
            if (classSession == null)
            {
                return NotFound("Không tìm thấy lớp.");
            }

            // Parse giờ bắt đầu lớp
            var classStartTimeStr = classSession.Time.Split('-')[0].Trim();
            var classStartTime = DateTime.Parse(classSession.Date.ToString("yyyy-MM-dd") + " " + classStartTimeStr);
            var timeLimit = classStartTime.AddMinutes(30);
            var currentTime = DateTime.Now;

            if (currentTime > timeLimit)
            {
                TempData["Error"] = $"Không thể chỉnh sửa điểm danh. Thời gian lớp đã hết hạn (chỉ cho phép trong 30 phút từ {classStartTime:HH:mm}).";
                return RedirectToAction("LecturerStudents", new { classId });
            }

            // Lưu điểm danh (cho phép mọi trường hợp)
            if (attended != null && attended.Any())
            {
                foreach (var kvp in attended)
                {
                    var student = classSession.Students.FirstOrDefault(s => s.Id == kvp.Key);
                    if (student != null)
                    {
                        student.Attended = kvp.Value;
                    }
                }
            }

            classSession.IsAttendanceTaken = true;
            _context.SaveChanges(); // Đảm bảo lưu thay đổi

            TempData["Success"] = "Điểm danh đã được lưu thành công! Bạn có thể chỉnh sửa trong 30 phút tiếp theo.";

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
                    Time = s.ClassSession.Time,
                    Room = s.ClassSession.Room,
                    Attended = s.Attended
                })
                .ToList();
            return View(attendanceData);
        }

        
        public IActionResult ResetAttendance(int classId = 0)
        {
            if (classId > 0)
            {
                // Reset một lớp
                var classSession = _context.ClassSessions.Find(classId);
                if (classSession != null)
                {
                    classSession.IsAttendanceTaken = false;
                    var students = _context.Students.Where(s => s.ClassSessionId == classId);
                    foreach (var student in students)
                    {
                        student.Attended = false;
                    }
                    _context.SaveChanges();
                    TempData["Success"] = $"Đã reset điểm danh cho lớp {classId}.";
                }
            }
            else
            {
                // Reset toàn bộ
                var classSessions = _context.ClassSessions.ToList();
                foreach (var cls in classSessions)
                {
                    cls.IsAttendanceTaken = false;
                }
                var allStudents = _context.Students.ToList();
                foreach (var student in allStudents)
                {
                    student.Attended = false;
                }
                _context.SaveChanges();
                TempData["Success"] = "Đã reset toàn bộ điểm danh.";
            }

            return RedirectToAction("AttendanceReport");
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