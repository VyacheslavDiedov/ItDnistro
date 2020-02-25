using Microsoft.EntityFrameworkCore.Migrations;

namespace DataBase.Migrations
{
    public partial class resolving_development_issues : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TourTypes_TourPhotos_TourPhotoId",
                table: "TourTypes");

            migrationBuilder.DropIndex(
                name: "IX_TourTypes_TourPhotoId",
                table: "TourTypes");

            migrationBuilder.DropColumn(
                name: "PhotoId",
                table: "TourTypes");

            migrationBuilder.DropColumn(
                name: "TourPhotoId",
                table: "TourTypes");

            migrationBuilder.AddColumn<int>(
                name: "TourTypeId",
                table: "TourPhotos",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_TourPhotos_TourTypeId",
                table: "TourPhotos",
                column: "TourTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_TourPhotos_TourTypes_TourTypeId",
                table: "TourPhotos",
                column: "TourTypeId",
                principalTable: "TourTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TourPhotos_TourTypes_TourTypeId",
                table: "TourPhotos");

            migrationBuilder.DropIndex(
                name: "IX_TourPhotos_TourTypeId",
                table: "TourPhotos");

            migrationBuilder.DropColumn(
                name: "TourTypeId",
                table: "TourPhotos");

            migrationBuilder.AddColumn<int>(
                name: "PhotoId",
                table: "TourTypes",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "TourPhotoId",
                table: "TourTypes",
                type: "int",
                nullable: true);

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
    }
}
