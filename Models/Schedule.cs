namespace Backend.API.Models
{
    public class Schedule
    {
        public int Id { get; set; }
        public string CourseName { get; set; } = string.Empty;
        public DateTime Date { get; set; }
        public string Time { get; set; } = string.Empty;// Example: "08:00 - 10:00"
        public string Location { get; set; } = string.Empty; // Fixed syntax error
        public int LecturerId { get; set; }
        public User Lecturer { get; set; }
        public List<Attendance> Attendances { get; set; } = new List<Attendance>();
    }
}