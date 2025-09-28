using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace StudentAttendanceMVC.Migrations
{
    /// <inheritdoc />
    public partial class AddMoreStudentsToClasses : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Attended", "Name" },
                values: new object[] { true, "Hà Văn N" });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 2,
                column: "Name",
                value: "Lê Văn C");

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Attended", "ClassSessionId", "Name" },
                values: new object[] { true, 1, "Phạm Thị D" });

            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "Id", "Attended", "ClassSessionId", "Name" },
                values: new object[,]
                {
                    { 4, true, 1, "Bùi Văn G" },
                    { 5, true, 1, "Vũ Văn I" },
                    { 6, false, 1, "Đỗ Thị F" },
                    { 7, false, 1, "Trần Thị B" },
                    { 8, false, 1, "Ngô Thị H" },
                    { 9, false, 1, "Lý Văn L" },
                    { 10, true, 1, "Hoàng Văn E" },
                    { 11, false, 1, "Nguyễn Văn A" },
                    { 12, false, 1, "Dương Thị K" },
                    { 13, false, 1, "Đinh Văn Q" },
                    { 14, true, 1, "Phan Thị P" },
                    { 15, true, 1, "Trịnh Thị M" },
                    { 16, true, 2, "Phan Thị P" },
                    { 17, false, 2, "Trần Thị B" },
                    { 18, true, 2, "Vũ Văn I" },
                    { 19, true, 2, "Hà Văn N" },
                    { 20, false, 2, "Phạm Thị D" },
                    { 21, false, 2, "Ngô Thị H" },
                    { 22, false, 2, "Đinh Văn Q" },
                    { 23, true, 2, "Trịnh Thị M" },
                    { 24, true, 2, "Dương Thị K" },
                    { 25, false, 2, "Lý Văn L" },
                    { 26, true, 2, "Bùi Văn G" },
                    { 27, true, 2, "Lê Văn C" },
                    { 28, true, 2, "Đỗ Thị F" },
                    { 29, false, 3, "Trịnh Thị M" },
                    { 30, false, 3, "Đỗ Thị F" },
                    { 31, true, 3, "Lê Văn C" },
                    { 32, false, 3, "Trần Thị B" },
                    { 33, true, 3, "Hà Văn N" },
                    { 34, false, 3, "Dương Thị K" },
                    { 35, false, 3, "Nguyễn Văn A" },
                    { 36, true, 3, "Hoàng Văn E" },
                    { 37, false, 3, "Phạm Thị D" },
                    { 38, false, 3, "Phan Thị P" },
                    { 39, false, 3, "Đinh Văn Q" },
                    { 40, false, 3, "Bùi Văn G" },
                    { 41, false, 3, "Lý Văn L" },
                    { 42, true, 3, "Vũ Văn I" },
                    { 43, false, 3, "Lê Văn C" },
                    { 44, true, 3, "Bùi Văn G" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 21);

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 22);

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 23);

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 24);

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 25);

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 26);

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 27);

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 28);

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 29);

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 30);

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 31);

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 32);

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 33);

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 34);

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 35);

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 36);

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 37);

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 38);

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 39);

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 40);

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 41);

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 42);

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 43);

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 44);

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Attended", "Name" },
                values: new object[] { false, "Sinh viên X" });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 2,
                column: "Name",
                value: "Sinh viên Y");

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Attended", "ClassSessionId", "Name" },
                values: new object[] { false, 2, "Sinh viên Z" });
        }
    }
}
