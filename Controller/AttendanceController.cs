using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Backend.API.Data;
using Backend.API.Models;
using System.Text;

namespace Backend.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class AttendanceController : ControllerBase
    {
        private readonly AppDbContext _context;

        public AttendanceController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet("student/{studentId}/today")]
        [Authorize(Roles = "Student")]
        public async Task<IActionResult> GetStudentAttendance(int studentId)
        {
            var today = DateTime.Today;
            var attendances = await _context.Attendances
                .Include(a => a.Schedule)
                .Where(a => a.StudentId == studentId && a.Schedule.Date.Date == today)
                .Select(a => new AttendanceDto
                {
                    CourseName = a.Schedule.CourseName,
                    Date = a.Schedule.Date.ToString("yyyy-MM-dd"),
                    Status = a.IsPresent ? "Present" : "Absent"
                })
                .ToListAsync();

            return Ok(attendances);
        }

        [HttpGet("session/{sessionId}/students")]
        [Authorize(Roles = "Lecturer,Admin")]
        public async Task<IActionResult> GetSessionAttendance(int sessionId)
        {
            var attendances = await _context.Attendances
                .Include(a => a.Student)
                .Include(a => a.Schedule)
                .Where(a => a.ScheduleId == sessionId)
                .Select(a => new AttendanceDto
                {
                    Id = a.Id,
                    StudentName = a.Student.Name,
                    IsPresent = a.IsPresent
                })
                .ToListAsync();

            return Ok(attendances);
        }

        [HttpPost("update")]
        [Authorize(Roles = "Lecturer")]
        public async Task<IActionResult> UpdateAttendance([FromBody] List<AttendanceDto> attendances)
        {
            foreach (var dto in attendances)
            {
                var attendance = await _context.Attendances.FindAsync(dto.Id);
                if (attendance != null)
                {
                    attendance.IsPresent = dto.IsPresent;
                }
            }
            await _context.SaveChangesAsync();
            return Ok(new { message = "Cập nhật điểm danh thành công" });
        }

        [HttpGet("session/{sessionId}/export")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> ExportSessionAttendance(int sessionId)
        {
            var attendances = await _context.Attendances
                .Include(a => a.Student)
                .Include(a => a.Schedule)
                .Where(a => a.ScheduleId == sessionId)
                .Select(a => new { a.Student.Name, Status = a.IsPresent ? "Present" : "Absent" })
                .ToListAsync();

            var csv = new StringBuilder();
            csv.AppendLine("StudentName,Status");
            foreach (var att in attendances)
            {
                csv.AppendLine($"\"{att.Name}\",\"{att.Status}\"");
            }

            var bytes = Encoding.UTF8.GetBytes(csv.ToString());
            return File(bytes, "text/csv", $"attendance_{sessionId}.csv");
        }
    }

    public class AttendanceDto
    {
        public int Id { get; set; }
        public string StudentName { get; set; }
        public bool IsPresent { get; set; }
        public string CourseName { get; set; }
        public string Date { get; set; }
        public string Status { get; set; }
    }
}