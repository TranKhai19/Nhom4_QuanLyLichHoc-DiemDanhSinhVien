using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace StudentAttendanceMVC.Migrations
{
    /// <inheritdoc />
    public partial class AddScheduleIdToClassSession : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Schedules",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "ClassSessions",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.AddColumn<int>(
                name: "ScheduleId",
                table: "ClassSessions",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "ClassSessions",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Date", "ScheduleId" },
                values: new object[] { new DateTime(2025, 9, 28, 0, 0, 0, 0, DateTimeKind.Local), 1 });

            migrationBuilder.UpdateData(
                table: "ClassSessions",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Date", "ScheduleId" },
                values: new object[] { new DateTime(2025, 9, 29, 0, 0, 0, 0, DateTimeKind.Local), 2 });

            migrationBuilder.UpdateData(
                table: "ClassSessions",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Date", "ScheduleId" },
                values: new object[] { new DateTime(2025, 9, 30, 0, 0, 0, 0, DateTimeKind.Local), 3 });

            migrationBuilder.UpdateData(
                table: "Schedules",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Date", "LecturerName", "StudentName" },
                values: new object[] { new DateTime(2025, 9, 28, 0, 0, 0, 0, DateTimeKind.Local), "lecturer@example.com", "student@example.com" });

            migrationBuilder.UpdateData(
                table: "Schedules",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Date", "LecturerName", "StudentName" },
                values: new object[] { new DateTime(2025, 9, 29, 0, 0, 0, 0, DateTimeKind.Local), "lecturer@example.com", "student@example.com" });

            migrationBuilder.UpdateData(
                table: "Schedules",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Date", "LecturerName", "StudentName" },
                values: new object[] { new DateTime(2025, 9, 30, 0, 0, 0, 0, DateTimeKind.Local), "lecturer2@example.com", "student2@example.com" });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Attended", "ClassSessionId" },
                values: new object[] { true, 1 });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 3,
                column: "ClassSessionId",
                value: 2);

            migrationBuilder.CreateIndex(
                name: "IX_ClassSessions_ScheduleId",
                table: "ClassSessions",
                column: "ScheduleId");

            migrationBuilder.AddForeignKey(
                name: "FK_ClassSessions_Schedules_ScheduleId",
                table: "ClassSessions",
                column: "ScheduleId",
                principalTable: "Schedules",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ClassSessions_Schedules_ScheduleId",
                table: "ClassSessions");

            migrationBuilder.DropIndex(
                name: "IX_ClassSessions_ScheduleId",
                table: "ClassSessions");

            migrationBuilder.DropColumn(
                name: "ScheduleId",
                table: "ClassSessions");

            migrationBuilder.UpdateData(
                table: "ClassSessions",
                keyColumn: "Id",
                keyValue: 1,
                column: "Date",
                value: new DateTime(2025, 9, 27, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "ClassSessions",
                keyColumn: "Id",
                keyValue: 2,
                column: "Date",
                value: new DateTime(2025, 9, 28, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "ClassSessions",
                keyColumn: "Id",
                keyValue: 3,
                column: "Date",
                value: new DateTime(2025, 9, 29, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.InsertData(
                table: "ClassSessions",
                columns: new[] { "Id", "CourseName", "Date", "Room", "Time" },
                values: new object[] { 4, "Lập trình Java", new DateTime(2025, 9, 30, 0, 0, 0, 0, DateTimeKind.Local), "Phòng 104", "14:00 - 16:00" });

            migrationBuilder.UpdateData(
                table: "Schedules",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Date", "LecturerName", "StudentName" },
                values: new object[] { new DateTime(2025, 9, 27, 0, 0, 0, 0, DateTimeKind.Local), "Giảng viên A", "Sinh viên X" });

            migrationBuilder.UpdateData(
                table: "Schedules",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Date", "LecturerName", "StudentName" },
                values: new object[] { new DateTime(2025, 9, 28, 0, 0, 0, 0, DateTimeKind.Local), "Giảng viên A", "Sinh viên Y" });

            migrationBuilder.UpdateData(
                table: "Schedules",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Date", "LecturerName", "StudentName" },
                values: new object[] { new DateTime(2025, 9, 29, 0, 0, 0, 0, DateTimeKind.Local), "Giảng viên B", "Sinh viên Z" });

            migrationBuilder.InsertData(
                table: "Schedules",
                columns: new[] { "Id", "CourseName", "Date", "IsActive", "LecturerName", "Room", "StudentName", "Time" },
                values: new object[] { 4, "Lập trình Java", new DateTime(2025, 9, 30, 0, 0, 0, 0, DateTimeKind.Local), true, "Giảng viên C", "Phòng 104", "Sinh viên X", "14:00 - 16:00" });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Attended", "ClassSessionId" },
                values: new object[] { false, 2 });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 3,
                column: "ClassSessionId",
                value: 3);

            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "Id", "Attended", "ClassSessionId", "Name" },
                values: new object[] { 4, false, 4, "Sinh viên X" });
        }
    }
}
