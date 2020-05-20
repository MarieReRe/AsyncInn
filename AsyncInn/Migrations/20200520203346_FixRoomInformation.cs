using Microsoft.EntityFrameworkCore.Migrations;

namespace AsyncInn.Migrations
{
    public partial class FixRoomInformation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "BedCount",
                table: "Room",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "BedStyle",
                table: "Room",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "Room",
                keyColumn: "ID",
                keyValue: 1L,
                columns: new[] { "BedCount", "BedStyle", "Style" },
                values: new object[] { 1, 1, 2 });

            migrationBuilder.UpdateData(
                table: "Room",
                keyColumn: "ID",
                keyValue: 2L,
                columns: new[] { "BedCount", "Style" },
                values: new object[] { 1, 0 });

            migrationBuilder.UpdateData(
                table: "Room",
                keyColumn: "ID",
                keyValue: 3L,
                columns: new[] { "BedCount", "Style" },
                values: new object[] { 1, 3 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BedCount",
                table: "Room");

            migrationBuilder.DropColumn(
                name: "BedStyle",
                table: "Room");

            migrationBuilder.UpdateData(
                table: "Room",
                keyColumn: "ID",
                keyValue: 1L,
                column: "Style",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Room",
                keyColumn: "ID",
                keyValue: 2L,
                column: "Style",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Room",
                keyColumn: "ID",
                keyValue: 3L,
                column: "Style",
                value: 1);
        }
    }
}
