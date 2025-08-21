using Microsoft.EntityFrameworkCore;
using Backend.API.Models;

namespace Backend.API.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Schedule> Schedules { get; set; }
        public DbSet<Attendance> Attendances { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                .HasIndex(u => u.Username)
                .IsUnique();

            modelBuilder.Entity<Attendance>()
                .HasOne(a => a.Schedule)
                .WithMany(s => s.Attendances)
                .HasForeignKey(a => a.ScheduleId);

            modelBuilder.Entity<Attendance>()
                .HasOne(a => a.Student)
                .WithMany()
                .HasForeignKey(a => a.StudentId);

            modelBuilder.Entity<Schedule>()
                .HasOne(s => s.Lecturer)
                .WithMany()
                .HasForeignKey(s => s.LecturerId);
        }
    }
}