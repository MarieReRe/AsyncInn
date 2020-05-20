using Microsoft.EntityFrameworkCore.Migrations;

namespace AsyncInn.Migrations
{
    public partial class AddRoomTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "RoomID",
                table: "HotelRoom",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.CreateTable(
                name: "Room",
                columns: table => new
                {
                    ID = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: false),
                    Style = table.Column<int>(nullable: false),
                    MaxGuests = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Room", x => x.ID);
                });

            migrationBuilder.InsertData(
                table: "Room",
                columns: new[] { "ID", "MaxGuests", "Name", "Style" },
                values: new object[] { 1L, 2, "Charming Room", 1 });

            migrationBuilder.InsertData(
                table: "Room",
                columns: new[] { "ID", "MaxGuests", "Name", "Style" },
                values: new object[] { 2L, 2, "Superior Room - Pool Floor", 1 });

            migrationBuilder.InsertData(
                table: "Room",
                columns: new[] { "ID", "MaxGuests", "Name", "Style" },
                values: new object[] { 3L, 2, "Superior Room - Top Floor", 1 });

            migrationBuilder.CreateIndex(
                name: "IX_HotelRoom_RoomID",
                table: "HotelRoom",
                column: "RoomID");

            migrationBuilder.AddForeignKey(
                name: "FK_HotelRoom_Room_RoomID",
                table: "HotelRoom",
                column: "RoomID",
                principalTable: "Room",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_HotelRoom_Room_RoomID",
                table: "HotelRoom");

            migrationBuilder.DropTable(
                name: "Room");

            migrationBuilder.DropIndex(
                name: "IX_HotelRoom_RoomID",
                table: "HotelRoom");

            migrationBuilder.DropColumn(
                name: "RoomID",
                table: "HotelRoom");
        }
    }
}
