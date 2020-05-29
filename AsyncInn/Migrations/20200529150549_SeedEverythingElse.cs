using Microsoft.EntityFrameworkCore.Migrations;

namespace AsyncInn.Migrations
{
    public partial class SeedEverythingElse : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ID",
                table: "Room",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "ID",
                table: "Hotel",
                newName: "Id");

            migrationBuilder.InsertData(
                table: "Amenities",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Fridge" },
                    { 2, "Coffee Pot" },
                    { 3, "Hot Tub" }
                });

            migrationBuilder.InsertData(
                table: "HotelRoom",
                columns: new[] { "HotelId", "RoomNumber", "Rate", "RoomId" },
                values: new object[,]
                {
                    { 1L, 101, 100m, 1L },
                    { 1L, 202, 200m, 2L },
                    { 1L, 303, 500m, 3L }
                });

            migrationBuilder.InsertData(
                table: "RoomAmenities",
                columns: new[] { "AmenitiesId", "RoomId" },
                values: new object[,]
                {
                    { 1, 1L },
                    { 1, 2L },
                    { 1, 3L },
                    { 2, 1L },
                    { 2, 2L },
                    { 2, 3L },
                    { 3, 3L }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "HotelRoom",
                keyColumns: new[] { "HotelId", "RoomNumber" },
                keyValues: new object[] { 1L, 101 });

            migrationBuilder.DeleteData(
                table: "HotelRoom",
                keyColumns: new[] { "HotelId", "RoomNumber" },
                keyValues: new object[] { 1L, 202 });

            migrationBuilder.DeleteData(
                table: "HotelRoom",
                keyColumns: new[] { "HotelId", "RoomNumber" },
                keyValues: new object[] { 1L, 303 });

            migrationBuilder.DeleteData(
                table: "RoomAmenities",
                keyColumns: new[] { "AmenitiesId", "RoomId" },
                keyValues: new object[] { 1, 1L });

            migrationBuilder.DeleteData(
                table: "RoomAmenities",
                keyColumns: new[] { "AmenitiesId", "RoomId" },
                keyValues: new object[] { 1, 2L });

            migrationBuilder.DeleteData(
                table: "RoomAmenities",
                keyColumns: new[] { "AmenitiesId", "RoomId" },
                keyValues: new object[] { 1, 3L });

            migrationBuilder.DeleteData(
                table: "RoomAmenities",
                keyColumns: new[] { "AmenitiesId", "RoomId" },
                keyValues: new object[] { 2, 1L });

            migrationBuilder.DeleteData(
                table: "RoomAmenities",
                keyColumns: new[] { "AmenitiesId", "RoomId" },
                keyValues: new object[] { 2, 2L });

            migrationBuilder.DeleteData(
                table: "RoomAmenities",
                keyColumns: new[] { "AmenitiesId", "RoomId" },
                keyValues: new object[] { 2, 3L });

            migrationBuilder.DeleteData(
                table: "RoomAmenities",
                keyColumns: new[] { "AmenitiesId", "RoomId" },
                keyValues: new object[] { 3, 3L });

            migrationBuilder.DeleteData(
                table: "Amenities",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Amenities",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Amenities",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Room",
                newName: "ID");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Hotel",
                newName: "ID");
        }
    }
}
