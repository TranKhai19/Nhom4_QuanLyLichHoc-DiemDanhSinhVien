using System.ComponentModel.DataAnnotations;

namespace StudentAttendanceMVC.Models
{
    public class ClassSession
    {
        public int Id { get; set; }
        [Required]
        public string CourseName { get; set; } = string.Empty;
        public DateTime Date { get; set; }
        public string Time { get; set; } = string.Empty; // Thêm Time
        public string Room { get; set; } = string.Empty; // Thêm Room
        public List<Student> Students { get; set; } = new List<Student>();
    }
}