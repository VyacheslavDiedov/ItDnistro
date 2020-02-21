using Microsoft.EntityFrameworkCore.Migrations;

namespace DataBase.Migrations
{
    public partial class add_tour_photo_table : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "PhotoId",
                table: "TourTypes",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "TourPhotoId",
                table: "TourTypes",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "TourPhotos",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PhotoLink = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TourPhotos", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TourTypes_TourPhotoId",
                table: "TourTypes",
                column: "TourPhotoId");

            migrationBuilder.AddForeignKey(
                name: "FK_TourTypes_TourPhotos_TourPhotoId",
                table: "TourTypes",
                column: "TourPhotoId",
                principalTable: "TourPhotos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TourTypes_TourPhotos_TourPhotoId",
                table: "TourTypes");

            migrationBuilder.DropTable(
                name: "TourPhotos");

            migrationBuilder.DropIndex(
                name: "IX_TourTypes_TourPhotoId",
                table: "TourTypes");

            migrationBuilder.DropColumn(
                name: "PhotoId",
                table: "TourTypes");

            migrationBuilder.DropColumn(
                name: "TourPhotoId",
                table: "TourTypes");
        }
    }
}
