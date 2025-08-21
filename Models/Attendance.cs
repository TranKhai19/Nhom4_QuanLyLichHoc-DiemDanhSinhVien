﻿namespace Backend.API.Models
{
    public class Attendance
    {
        public int Id { get; set; }
        public int ScheduleId { get; set; }
        public Schedule Schedule { get; set; }
        public int StudentId { get; set; }
        public User Student { get; set; }
        public bool IsPresent { get; set; }
    }
}