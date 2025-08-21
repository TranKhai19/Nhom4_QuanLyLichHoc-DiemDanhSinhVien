namespace Backend.API.Models
{
    public class Schedule
    {
        public int Id { get; set; }
        public string CourseName { get; set; }
        public DateTime Date { get; set; }
        public string Time { get; set; } // Ví dụ: "08:00 - 10:00"
        public string Location { get; set; }
        public int LecturerId { get; set; }
        public User Lecturer { get; set; }
        public List<Attendance> Attendances { get; set; }
    }
}