﻿namespace Backend.API.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string PasswordHash { get; set; }
        public string Role { get; set; } // "Student", "Lecturer", "Admin"
        public string Name { get; set; }
    }
}