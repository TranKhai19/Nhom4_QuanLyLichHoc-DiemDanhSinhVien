using System.ComponentModel.DataAnnotations;

namespace StudentAttendanceMVC.Models
{
    public class Student
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; } = string.Empty;
        public bool Attended { get; set; } = false;
        public int ClassSessionId { get; set; } // Liên kết với một lớp cụ thể
        public ClassSession? ClassSession { get; set; }
    }
}