using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using StudentAttendanceMVC.Models;

namespace StudentAttendanceMVC.Data
{
    public class AppDbContext : IdentityDbContext<ApplicationUser>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Schedules> Schedules { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<ClassSession> ClassSessions { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Student>()
                .HasOne(s => s.ClassSession)
                .WithMany(c => c.Students)
                .HasForeignKey(s => s.ClassSessionId);

 
            // Change .HasOne(c => c.Schedule) to .HasOne<Schedules>(c => c.Schedule)
            modelBuilder.Entity<ClassSession>()
                .HasOne<Schedules>(c => c.Schedule)
                .WithMany()
                .HasForeignKey(c => c.ScheduleId);
                

            // Seed data với giá trị tĩnh
            var baseDate = new DateTime(2025, 9, 28); // Ngày cố định

            var schedule1 = new Schedules { Id = 1, CourseName = "Lập trình Web", LecturerName = "lecturer@example.com", StudentName = "student@example.com", Date = baseDate, Time = "08:00 - 10:00", Room = "Phòng 101", IsActive = true };
            var schedule2 = new Schedules { Id = 2, CourseName = "Cơ sở dữ liệu", LecturerName = "lecturer@example.com", StudentName = "student@example.com", Date = baseDate.AddDays(1), Time = "13:00 - 15:00", Room = "Phòng 102", IsActive = true };
            var schedule3 = new Schedules { Id = 3, CourseName = "Toán cao cấp", LecturerName = "lecturer@example.com", StudentName = "student2@example.com", Date = baseDate.AddDays(2), Time = "09:00 - 11:00", Room = "Phòng 103", IsActive = true };

            modelBuilder.Entity<Schedules>().HasData(
                schedule1,
                schedule2,
                schedule3
            );

            // Trong OnModelCreating, thêm vào seed ClassSession
            modelBuilder.Entity<ClassSession>().HasData(
                new ClassSession { Id = 1, CourseName = "Lập trình Web", Date = new DateTime(2025, 9, 28), Time = "08:00 - 10:00", Room = "Phòng 101", ScheduleId = 1, IsAttendanceTaken = false },
                new ClassSession { Id = 2, CourseName = "Cơ sở dữ liệu", Date = new DateTime(2025, 9, 29), Time = "13:00 - 15:00", Room = "Phòng 102", ScheduleId = 2, IsAttendanceTaken = false },
                new ClassSession { Id = 3, CourseName = "Toán cao cấp", Date = new DateTime(2025, 9, 29), Time = "09:00 - 11:00", Room = "Phòng 103", ScheduleId = 3, IsAttendanceTaken = false }
            );


            // Danh sách sinh viên tĩnh (10-15 sinh viên mỗi lớp)
            var students = new List<Student>
            {
                // Lớp 1: Lập trình Web
                new Student { Id = 1, Name = "Nguyễn Văn A", Attended = true, ClassSessionId = 1 },
                new Student { Id = 2, Name = "Trần Thị B", Attended = false, ClassSessionId = 1 },
                new Student { Id = 3, Name = "Lê Văn C", Attended = true, ClassSessionId = 1 },
                new Student { Id = 4, Name = "Phạm Thị D", Attended = false, ClassSessionId = 1 },
                new Student { Id = 5, Name = "Hoàng Văn E", Attended = true, ClassSessionId = 1 },
                new Student { Id = 6, Name = "Đỗ Thị F", Attended = false, ClassSessionId = 1 },
                new Student { Id = 7, Name = "Bùi Văn G", Attended = true, ClassSessionId = 1 },
                new Student { Id = 8, Name = "Ngô Thị H", Attended = false, ClassSessionId = 1 },
                new Student { Id = 9, Name = "Vũ Văn I", Attended = true, ClassSessionId = 1 },
                new Student { Id = 10, Name = "Dương Thị K", Attended = false, ClassSessionId = 1 },
                new Student { Id = 11, Name = "Lý Văn L", Attended = true, ClassSessionId = 1 },
                new Student { Id = 12, Name = "Trịnh Thị M", Attended = false, ClassSessionId = 1 },

                // Lớp 2: Cơ sở dữ liệu
                new Student { Id = 13, Name = "Nguyễn Văn A", Attended = false, ClassSessionId = 2 }, // Học nhiều lớp
                new Student { Id = 14, Name = "Trần Thị B", Attended = true, ClassSessionId = 2 },
                new Student { Id = 15, Name = "Lê Văn C", Attended = false, ClassSessionId = 2 },
                new Student { Id = 16, Name = "Phạm Thị D", Attended = true, ClassSessionId = 2 },
                new Student { Id = 17, Name = "Hoàng Văn E", Attended = false, ClassSessionId = 2 },
                new Student { Id = 18, Name = "Đỗ Thị F", Attended = true, ClassSessionId = 2 },
                new Student { Id = 19, Name = "Bùi Văn G", Attended = false, ClassSessionId = 2 },
                new Student { Id = 20, Name = "Ngô Thị H", Attended = true, ClassSessionId = 2 },
                new Student { Id = 21, Name = "Vũ Văn I", Attended = false, ClassSessionId = 2 },
                new Student { Id = 22, Name = "Dương Thị K", Attended = true, ClassSessionId = 2 },
                new Student { Id = 23, Name = "Lý Văn L", Attended = false, ClassSessionId = 2 },
                new Student { Id = 24, Name = "Trịnh Thị M", Attended = true, ClassSessionId = 2 },
                new Student { Id = 25, Name = "Hà Văn N", Attended = false, ClassSessionId = 2 },

                // Lớp 3: Toán cao cấp
                new Student { Id = 26, Name = "Nguyễn Văn A", Attended = true, ClassSessionId = 3 }, // Học nhiều lớp
                new Student { Id = 27, Name = "Trần Thị B", Attended = false, ClassSessionId = 3 },
                new Student { Id = 28, Name = "Lê Văn C", Attended = true, ClassSessionId = 3 },
                new Student { Id = 29, Name = "Phạm Thị D", Attended = false, ClassSessionId = 3 },
                new Student { Id = 30, Name = "Hoàng Văn E", Attended = true, ClassSessionId = 3 },
                new Student { Id = 31, Name = "Đỗ Thị F", Attended = false, ClassSessionId = 3 },
                new Student { Id = 32, Name = "Bùi Văn G", Attended = true, ClassSessionId = 3 },
                new Student { Id = 33, Name = "Ngô Thị H", Attended = false, ClassSessionId = 3 },
                new Student { Id = 34, Name = "Vũ Văn I", Attended = true, ClassSessionId = 3 },
                new Student { Id = 35, Name = "Dương Thị K", Attended = false, ClassSessionId = 3 }
            };

            modelBuilder.Entity<Student>().HasData(students);
        }
    }
}