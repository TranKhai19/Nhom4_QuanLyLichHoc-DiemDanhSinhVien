using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace StudentAttendanceMVC.Migrations
{
    /// <inheritdoc />
    public partial class AddIsAttendanceTaken : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsAttendanceTaken",
                table: "ClassSessions",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.UpdateData(
                table: "ClassSessions",
                keyColumn: "Id",
                keyValue: 1,
                column: "IsAttendanceTaken",
                value: false);

            migrationBuilder.UpdateData(
                table: "ClassSessions",
                keyColumn: "Id",
                keyValue: 2,
                column: "IsAttendanceTaken",
                value: false);

            migrationBuilder.UpdateData(
                table: "ClassSessions",
                keyColumn: "Id",
                keyValue: 3,
                column: "IsAttendanceTaken",
                value: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsAttendanceTaken",
                table: "ClassSessions");
        }
    }
}
