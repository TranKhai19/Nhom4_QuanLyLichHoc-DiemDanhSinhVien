using System.ComponentModel.DataAnnotations;

namespace StudentAttendanceMVC.Models
{
    public class Student
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; } = string.Empty;
        public bool Attended { get; set; } = false;
    }
}