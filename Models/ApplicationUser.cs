using Microsoft.AspNetCore.Identity;

namespace StudentAttendanceMVC.Models
{
    public class ApplicationUser : IdentityUser
    {
        public string FullName { get; set; } = string.Empty;
        public string Role { get; set; } = string.Empty; // "Lecturer" hoặc "Student" hoặc "Admin"
    }
}
