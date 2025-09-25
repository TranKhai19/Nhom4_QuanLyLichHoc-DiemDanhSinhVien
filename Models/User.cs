namespace Backend.API.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Username { get; set; } = string.Empty;
        public string PasswordHash { get; set; } = string.Empty;
        public string Role { get; set; } = string.Empty;// "Student", "Lecturer", "Admin"
        public string Name { get; set; } = string.Empty;
    }
}