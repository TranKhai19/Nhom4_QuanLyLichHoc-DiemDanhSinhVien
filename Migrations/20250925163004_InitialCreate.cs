using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace StudentAttendanceMVC.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ClassSessions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CourseName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Time = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Room = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClassSessions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Schedules",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CourseName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LecturerName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StudentName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Time = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Room = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Schedules", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Students",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Attended = table.Column<bool>(type: "bit", nullable: false),
                    ClassSessionId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Students", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Students_ClassSessions_ClassSessionId",
                        column: x => x.ClassSessionId,
                        principalTable: "ClassSessions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "ClassSessions",
                columns: new[] { "Id", "CourseName", "Date", "Room", "Time" },
                values: new object[,]
                {
                    { 1, "Lập trình Web", new DateTime(2025, 9, 25, 0, 0, 0, 0, DateTimeKind.Local), "Phòng 101", "08:00 - 10:00" },
                    { 2, "Cơ sở dữ liệu", new DateTime(2025, 9, 26, 0, 0, 0, 0, DateTimeKind.Local), "Phòng 102", "13:00 - 15:00" }
                });

            migrationBuilder.InsertData(
                table: "Schedules",
                columns: new[] { "Id", "CourseName", "Date", "LecturerName", "Room", "StudentName", "Time" },
                values: new object[,]
                {
                    { 1, "Lập trình Web", new DateTime(2025, 9, 25, 0, 0, 0, 0, DateTimeKind.Local), "Giảng viên A", "Phòng 101", "", "08:00 - 10:00" },
                    { 2, "Cơ sở dữ liệu", new DateTime(2025, 9, 26, 0, 0, 0, 0, DateTimeKind.Local), "Giảng viên A", "Phòng 102", "", "13:00 - 15:00" }
                });

            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "Id", "Attended", "ClassSessionId", "Name" },
                values: new object[,]
                {
                    { 1, false, 1, "Sinh viên X" },
                    { 2, false, 1, "Sinh viên Y" },
                    { 3, false, 1, "Sinh viên Z" },
                    { 4, false, 2, "Sinh viên X" },
                    { 5, false, 2, "Sinh viên Y" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Students_ClassSessionId",
                table: "Students",
                column: "ClassSessionId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Schedules");

            migrationBuilder.DropTable(
                name: "Students");

            migrationBuilder.DropTable(
                name: "ClassSessions");
        }
    }
}
