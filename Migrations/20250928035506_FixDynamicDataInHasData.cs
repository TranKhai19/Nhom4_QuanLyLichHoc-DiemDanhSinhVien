using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace StudentAttendanceMVC.Migrations
{
    /// <inheritdoc />
    public partial class FixDynamicDataInHasData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
                column: "Name",
                value: "Nguyễn Văn A");

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Attended", "Name" },
                values: new object[] { false, "Trần Thị B" });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 3,
                column: "Name",
                value: "Lê Văn C");

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "Attended", "Name" },
                values: new object[] { false, "Phạm Thị D" });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 5,
                column: "Name",
                value: "Hoàng Văn E");

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "Attended", "Name" },
                values: new object[] { true, "Bùi Văn G" });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "Attended", "Name" },
                values: new object[] { true, "Vũ Văn I" });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "Attended", "Name" },
                values: new object[] { false, "Dương Thị K" });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 11,
                columns: new[] { "Attended", "Name" },
                values: new object[] { true, "Lý Văn L" });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 12,
                column: "Name",
                value: "Trịnh Thị M");

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 13,
                columns: new[] { "ClassSessionId", "Name" },
                values: new object[] { 2, "Nguyễn Văn A" });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 14,
                columns: new[] { "ClassSessionId", "Name" },
                values: new object[] { 2, "Trần Thị B" });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 15,
                columns: new[] { "Attended", "ClassSessionId", "Name" },
                values: new object[] { false, 2, "Lê Văn C" });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 16,
                column: "Name",
                value: "Phạm Thị D");

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 17,
                column: "Name",
                value: "Hoàng Văn E");

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 18,
                column: "Name",
                value: "Đỗ Thị F");

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 19,
                columns: new[] { "Attended", "Name" },
                values: new object[] { false, "Bùi Văn G" });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 20,
                columns: new[] { "Attended", "Name" },
                values: new object[] { true, "Ngô Thị H" });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 21,
                column: "Name",
                value: "Vũ Văn I");

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 22,
                columns: new[] { "Attended", "Name" },
                values: new object[] { true, "Dương Thị K" });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 23,
                columns: new[] { "Attended", "Name" },
                values: new object[] { false, "Lý Văn L" });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 24,
                column: "Name",
                value: "Trịnh Thị M");

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 25,
                column: "Name",
                value: "Hà Văn N");

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 26,
                columns: new[] { "ClassSessionId", "Name" },
                values: new object[] { 3, "Nguyễn Văn A" });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 27,
                columns: new[] { "Attended", "ClassSessionId", "Name" },
                values: new object[] { false, 3, "Trần Thị B" });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 28,
                columns: new[] { "ClassSessionId", "Name" },
                values: new object[] { 3, "Lê Văn C" });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 29,
                column: "Name",
                value: "Phạm Thị D");

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 30,
                columns: new[] { "Attended", "Name" },
                values: new object[] { true, "Hoàng Văn E" });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 31,
                columns: new[] { "Attended", "Name" },
                values: new object[] { false, "Đỗ Thị F" });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 32,
                columns: new[] { "Attended", "Name" },
                values: new object[] { true, "Bùi Văn G" });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 33,
                columns: new[] { "Attended", "Name" },
                values: new object[] { false, "Ngô Thị H" });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 34,
                columns: new[] { "Attended", "Name" },
                values: new object[] { true, "Vũ Văn I" });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 35,
                column: "Name",
                value: "Dương Thị K");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 1,
                column: "Name",
                value: "Hà Văn N");

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Attended", "Name" },
                values: new object[] { true, "Lê Văn C" });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 3,
                column: "Name",
                value: "Phạm Thị D");

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "Attended", "Name" },
                values: new object[] { true, "Bùi Văn G" });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 5,
                column: "Name",
                value: "Vũ Văn I");

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "Attended", "Name" },
                values: new object[] { false, "Trần Thị B" });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "Attended", "Name" },
                values: new object[] { false, "Lý Văn L" });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "Attended", "Name" },
                values: new object[] { true, "Hoàng Văn E" });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 11,
                columns: new[] { "Attended", "Name" },
                values: new object[] { false, "Nguyễn Văn A" });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 12,
                column: "Name",
                value: "Dương Thị K");

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 13,
                columns: new[] { "ClassSessionId", "Name" },
                values: new object[] { 1, "Đinh Văn Q" });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 14,
                columns: new[] { "ClassSessionId", "Name" },
                values: new object[] { 1, "Phan Thị P" });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 15,
                columns: new[] { "Attended", "ClassSessionId", "Name" },
                values: new object[] { true, 1, "Trịnh Thị M" });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 16,
                column: "Name",
                value: "Phan Thị P");

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 17,
                column: "Name",
                value: "Trần Thị B");

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 18,
                column: "Name",
                value: "Vũ Văn I");

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 19,
                columns: new[] { "Attended", "Name" },
                values: new object[] { true, "Hà Văn N" });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 20,
                columns: new[] { "Attended", "Name" },
                values: new object[] { false, "Phạm Thị D" });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 21,
                column: "Name",
                value: "Ngô Thị H");

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 22,
                columns: new[] { "Attended", "Name" },
                values: new object[] { false, "Đinh Văn Q" });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 23,
                columns: new[] { "Attended", "Name" },
                values: new object[] { true, "Trịnh Thị M" });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 24,
                column: "Name",
                value: "Dương Thị K");

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 25,
                column: "Name",
                value: "Lý Văn L");

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 26,
                columns: new[] { "ClassSessionId", "Name" },
                values: new object[] { 2, "Bùi Văn G" });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 27,
                columns: new[] { "Attended", "ClassSessionId", "Name" },
                values: new object[] { true, 2, "Lê Văn C" });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 28,
                columns: new[] { "ClassSessionId", "Name" },
                values: new object[] { 2, "Đỗ Thị F" });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 29,
                column: "Name",
                value: "Trịnh Thị M");

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 30,
                columns: new[] { "Attended", "Name" },
                values: new object[] { false, "Đỗ Thị F" });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 31,
                columns: new[] { "Attended", "Name" },
                values: new object[] { true, "Lê Văn C" });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 32,
                columns: new[] { "Attended", "Name" },
                values: new object[] { false, "Trần Thị B" });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 33,
                columns: new[] { "Attended", "Name" },
                values: new object[] { true, "Hà Văn N" });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 34,
                columns: new[] { "Attended", "Name" },
                values: new object[] { false, "Dương Thị K" });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 35,
                column: "Name",
                value: "Nguyễn Văn A");

            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "Id", "Attended", "ClassSessionId", "Name" },
                values: new object[,]
                {
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
    }
}
