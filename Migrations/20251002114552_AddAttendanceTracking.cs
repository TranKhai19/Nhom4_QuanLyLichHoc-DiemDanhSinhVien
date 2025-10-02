using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace StudentAttendanceMVC.Migrations
{
    /// <inheritdoc />
    public partial class AddAttendanceTracking : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "ClassSessions",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Date", "Time" },
                values: new object[] { new DateTime(2025, 10, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "17:45 - 21:00" });

            migrationBuilder.UpdateData(
                table: "ClassSessions",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Date", "Time" },
                values: new object[] { new DateTime(2025, 10, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "17:45 - 21:00" });

            migrationBuilder.UpdateData(
                table: "ClassSessions",
                keyColumn: "Id",
                keyValue: 3,
                column: "Date",
                value: new DateTime(2025, 10, 2, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Schedules",
                keyColumn: "Id",
                keyValue: 1,
                column: "Time",
                value: "17:45 - 21:00");

            migrationBuilder.UpdateData(
                table: "Schedules",
                keyColumn: "Id",
                keyValue: 2,
                column: "Time",
                value: "17:45 - 21:00");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "ClassSessions",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Date", "Time" },
                values: new object[] { new DateTime(2025, 9, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "08:00 - 10:00" });

            migrationBuilder.UpdateData(
                table: "ClassSessions",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Date", "Time" },
                values: new object[] { new DateTime(2025, 9, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), "13:00 - 15:00" });

            migrationBuilder.UpdateData(
                table: "ClassSessions",
                keyColumn: "Id",
                keyValue: 3,
                column: "Date",
                value: new DateTime(2025, 9, 29, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Schedules",
                keyColumn: "Id",
                keyValue: 1,
                column: "Time",
                value: "08:00 - 10:00");

            migrationBuilder.UpdateData(
                table: "Schedules",
                keyColumn: "Id",
                keyValue: 2,
                column: "Time",
                value: "13:00 - 15:00");
        }
    }
}
