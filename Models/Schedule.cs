using System.ComponentModel.DataAnnotations;

namespace StudentAttendanceMVC.Models
{
    public class Schedule
    {
        public int Id { get; set; }
        [Required]
        public string CourseName { get; set; } = string.Empty;
        public string LecturerName { get; set; } = string.Empty;
        public string StudentName { get; set; } = string.Empty;
        public DateTime Date { get; set; }
        public string Time { get; set; } = string.Empty;
        public string Room { get; set; } = string.Empty;
    }
}