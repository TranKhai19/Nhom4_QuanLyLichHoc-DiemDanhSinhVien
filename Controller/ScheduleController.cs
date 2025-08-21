using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Backend.API.Data;
using Backend.API.Models;

namespace Backend.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class ScheduleController : ControllerBase
    {
        private readonly AppDbContext _context;

        public ScheduleController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet("student/{studentId}")]
        [Authorize(Roles = "Student")]
        public async Task<IActionResult> GetStudentSchedule(int studentId, [FromQuery] DateTime? date)
        {
            var query = _context.Schedules
                .Include(s => s.Attendances)
                .Where(s => s.Attendances.Any(a => a.StudentId == studentId));

            if (date.HasValue)
                query = query.Where(s => s.Date.Date == date.Value.Date);

            var schedules = await query
                .Select(s => new ScheduleDto
                {
                    CourseName = s.CourseName,
                    Time = s.Time,
                    Location = s.Location
                })
                .ToListAsync();

            return Ok(schedules);
        }

        [HttpGet("lecturer/{lecturerId}")]
        [Authorize(Roles = "Lecturer")]
        public async Task<IActionResult> GetLecturerSchedule(int lecturerId, [FromQuery] DateTime? date)
        {
            var query = _context.Schedules
                .Where(s => s.LecturerId == lecturerId);

            if (date.HasValue)
                query = query.Where(s => s.Date.Date == date.Value.Date);

            var schedules = await query
                .Select(s => new ScheduleDto
                {
                    SessionId = s.Id,
                    CourseName = s.CourseName,
                    Time = s.Time,
                    Location = s.Location
                })
                .ToListAsync();

            return Ok(schedules);
        }
    }

    public class ScheduleDto
    {
        public int SessionId { get; set; }
        public string CourseName { get; set; }
        public string Time { get; set; }
        public string Location { get; set; }
    }
}