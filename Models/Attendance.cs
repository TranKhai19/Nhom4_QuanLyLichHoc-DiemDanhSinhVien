namespace Backend.API.Models
{
    public class Attendance
    {
        public int Id { get; set; }
        public int ScheduleId { get; set; }
        public Schedule Schedule { get; set; } = new Schedule();
        public int StudentId { get; set; }
        public User Student { get; set; } = new User();
        public bool ísPresent { get; set; }
    }
}