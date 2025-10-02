using System.ComponentModel.DataAnnotations;

namespace StudentAttendanceMVC.Models
{
    public class ClassSession
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string CourseName { get; set; } = string.Empty;
        public DateTime Date { get; set; }
        public string Time { get; set; } = string.Empty;
        public string Room { get; set; } = string.Empty;
        public int ScheduleId { get; set; }
        public Schedules? Schedule { get; set; }
        public bool IsAttendanceTaken { get; set; } = false; // Thêm thuộc tính đánh dấu đã điểm danh
        public List<Student> Students { get; set; } = new List<Student>();
    }
}