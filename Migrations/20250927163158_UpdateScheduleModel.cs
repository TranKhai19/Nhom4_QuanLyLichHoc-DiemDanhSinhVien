using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace StudentAttendanceMVC.Migrations
{
    /// <inheritdoc />
    public partial class UpdateScheduleModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "Schedules",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.InsertData(
                table: "ClassSessions",
                columns: new[] { "Id", "CourseName", "Date", "Room", "Time" },
                values: new object[,]
                {
                    { 3, "Toán cao cấp", new DateTime(2025, 9, 29, 0, 0, 0, 0, DateTimeKind.Local), "Phòng 103", "09:00 - 11:00" },
                    { 4, "Lập trình Java", new DateTime(2025, 9, 30, 0, 0, 0, 0, DateTimeKind.Local), "Phòng 104", "14:00 - 16:00" }
                });

            migrationBuilder.UpdateData(
                table: "Schedules",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "IsActive", "StudentName" },
                values: new object[] { true, "Sinh viên X" });

            migrationBuilder.UpdateData(
                table: "Schedules",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "IsActive", "StudentName" },
                values: new object[] { true, "Sinh viên Y" });

            migrationBuilder.InsertData(
                table: "Schedules",
                columns: new[] { "Id", "CourseName", "Date", "IsActive", "LecturerName", "Room", "StudentName", "Time" },
                values: new object[,]
                {
                    { 3, "Toán cao cấp", new DateTime(2025, 9, 29, 0, 0, 0, 0, DateTimeKind.Local), true, "Giảng viên B", "Phòng 103", "Sinh viên Z", "09:00 - 11:00" },
                    { 4, "Lập trình Java", new DateTime(2025, 9, 30, 0, 0, 0, 0, DateTimeKind.Local), true, "Giảng viên C", "Phòng 104", "Sinh viên X", "14:00 - 16:00" }
                });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 2,
                column: "ClassSessionId",
                value: 2);

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 3,
                column: "ClassSessionId",
                value: 3);

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 4,
                column: "ClassSessionId",
                value: 4);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "ClassSessions",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "ClassSessions",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Schedules",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Schedules",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "Schedules");

            migrationBuilder.UpdateData(
                table: "Schedules",
                keyColumn: "Id",
                keyValue: 1,
                column: "StudentName",
                value: "");

            migrationBuilder.UpdateData(
                table: "Schedules",
                keyColumn: "Id",
                keyValue: 2,
                column: "StudentName",
                value: "");

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 2,
                column: "ClassSessionId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 3,
                column: "ClassSessionId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 4,
                column: "ClassSessionId",
                value: 2);

            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "Id", "Attended", "ClassSessionId", "Name" },
                values: new object[] { 5, false, 2, "Sinh viên Y" });
        }
    }
}
