using Microsoft.EntityFrameworkCore.Migrations;

namespace AsyncInn.Migrations
{
    public partial class AddCompositeKey : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RoomAmenities_Amenities_AmenitiesID",
                table: "RoomAmenities");

            migrationBuilder.DropForeignKey(
                name: "FK_RoomAmenities_Room_RoomID",
                table: "RoomAmenities");

            migrationBuilder.DropPrimaryKey(
                name: "PK_RoomAmenities",
                table: "RoomAmenities");

            migrationBuilder.DropIndex(
                name: "IX_RoomAmenities_AmenitiesID",
                table: "RoomAmenities");

            migrationBuilder.DropColumn(
                name: "AmenitiesId",
                table: "RoomAmenities");

            migrationBuilder.RenameColumn(
                name: "RoomID",
                table: "RoomAmenities",
                newName: "RoomId");

            migrationBuilder.RenameColumn(
                name: "AmenitiesID",
                table: "RoomAmenities",
                newName: "AmenitiesId");

            migrationBuilder.RenameIndex(
                name: "IX_RoomAmenities_RoomID",
                table: "RoomAmenities",
                newName: "IX_RoomAmenities_RoomId");

            migrationBuilder.AlterColumn<long>(
                name: "RoomId",
                table: "RoomAmenities",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_RoomAmenities",
                table: "RoomAmenities",
                columns: new[] { "AmenitiesId", "RoomId" });

            migrationBuilder.AddForeignKey(
                name: "FK_RoomAmenities_Amenities_AmenitiesId",
                table: "RoomAmenities",
                column: "AmenitiesId",
                principalTable: "Amenities",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_RoomAmenities_Room_RoomId",
                table: "RoomAmenities",
                column: "RoomId",
                principalTable: "Room",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RoomAmenities_Amenities_AmenitiesId",
                table: "RoomAmenities");

            migrationBuilder.DropForeignKey(
                name: "FK_RoomAmenities_Room_RoomId",
                table: "RoomAmenities");

            migrationBuilder.DropPrimaryKey(
                name: "PK_RoomAmenities",
                table: "RoomAmenities");

            migrationBuilder.RenameColumn(
                name: "RoomId",
                table: "RoomAmenities",
                newName: "RoomID");

            migrationBuilder.RenameColumn(
                name: "AmenitiesId",
                table: "RoomAmenities",
                newName: "AmenitiesID");

            migrationBuilder.RenameIndex(
                name: "IX_RoomAmenities_RoomId",
                table: "RoomAmenities",
                newName: "IX_RoomAmenities_RoomID");

            migrationBuilder.AlterColumn<long>(
                name: "RoomID",
                table: "RoomAmenities",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(long));

            migrationBuilder.AddColumn<int>(
                name: "AmenitiesId",
                table: "RoomAmenities",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_RoomAmenities",
                table: "RoomAmenities",
                column: "AmenitiesId");

            migrationBuilder.CreateIndex(
                name: "IX_RoomAmenities_AmenitiesID",
                table: "RoomAmenities",
                column: "AmenitiesID");

            migrationBuilder.AddForeignKey(
                name: "FK_RoomAmenities_Amenities_AmenitiesID",
                table: "RoomAmenities",
                column: "AmenitiesID",
                principalTable: "Amenities",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_RoomAmenities_Room_RoomID",
                table: "RoomAmenities",
                column: "RoomID",
                principalTable: "Room",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
