using Microsoft.EntityFrameworkCore.Migrations;

namespace AsyncInn.Migrations
{
    public partial class AddRoomTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<long>(
                name: "RoomId",
                table: "HotelRoom",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.CreateTable(
                name: "Room",
                columns: table => new
                {
                    ID = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: false),
                    Style = table.Column<int>(nullable: false),
                    MaxGuests = table.Column<int>(nullable: false),
                    BedCount = table.Column<int>(nullable: false),
                    BedStyle = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Room", x => x.ID);
                });

            migrationBuilder.InsertData(
                table: "Room",
                columns: new[] { "ID", "BedCount", "BedStyle", "MaxGuests", "Name", "Style" },
                values: new object[] { 1L, 1, 1, 2, "Charming Room", 2 });

            migrationBuilder.InsertData(
                table: "Room",
                columns: new[] { "ID", "BedCount", "BedStyle", "MaxGuests", "Name", "Style" },
                values: new object[] { 2L, 1, 0, 2, "Superior Room - Pool Floor", 0 });

            migrationBuilder.InsertData(
                table: "Room",
                columns: new[] { "ID", "BedCount", "BedStyle", "MaxGuests", "Name", "Style" },
                values: new object[] { 3L, 1, 0, 2, "Superior Room - Top Floor", 3 });

            migrationBuilder.CreateIndex(
                name: "IX_HotelRoom_RoomId",
                table: "HotelRoom",
                column: "RoomId");

            migrationBuilder.AddForeignKey(
                name: "FK_HotelRoom_Hotel_HotelId",
                table: "HotelRoom",
                column: "HotelId",
                principalTable: "Hotel",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_HotelRoom_Room_RoomId",
                table: "HotelRoom",
                column: "RoomId",
                principalTable: "Room",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_HotelRoom_Hotel_HotelId",
                table: "HotelRoom");

            migrationBuilder.DropForeignKey(
                name: "FK_HotelRoom_Room_RoomId",
                table: "HotelRoom");

            migrationBuilder.DropTable(
                name: "Room");

            migrationBuilder.DropIndex(
                name: "IX_HotelRoom_RoomId",
                table: "HotelRoom");

            migrationBuilder.AlterColumn<int>(
                name: "RoomId",
                table: "HotelRoom",
                type: "int",
                nullable: false,
                oldClrType: typeof(long));
        }
    }
}
