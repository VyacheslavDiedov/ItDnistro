using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DataBase.Migrations
{
    public partial class TourPhotoTape2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TourPhotoBackgrounds");

            migrationBuilder.UpdateData(
                table: "TourPhotos",
                keyColumn: "Id",
                keyValue: 7,
                column: "PhotoLink",
                value: "foto7.jpg");

            migrationBuilder.UpdateData(
                table: "TourPhotos",
                keyColumn: "Id",
                keyValue: 8,
                column: "PhotoLink",
                value: "foto8.jpg");

            migrationBuilder.UpdateData(
                table: "TourPhotos",
                keyColumn: "Id",
                keyValue: 9,
                column: "PhotoLink",
                value: "foto9.jpg");

            migrationBuilder.UpdateData(
                table: "TourPhotos",
                keyColumn: "Id",
                keyValue: 10,
                column: "PhotoLink",
                value: "foto10.jpg");

            migrationBuilder.UpdateData(
                table: "TourPhotos",
                keyColumn: "Id",
                keyValue: 11,
                columns: new[] { "PhotoLink", "TourTypeId", "ToutPhotoTypeId" },
                values: new object[] { "photo1.png", 1, 2 });

            migrationBuilder.InsertData(
                table: "TourPhotos",
                columns: new[] { "Id", "PhotoLink", "TourTypeId", "ToutPhotoTypeId" },
                values: new object[,]
                {
                    { 12, "photo2.png", 1, 2 },
                    { 13, "photo3.png", 1, 2 },
                    { 14, "photo4.jpg", 2, 2 },
                    { 15, "photo5.png", 2, 2 },
                    { 16, "photo6.png", 2, 2 },
                    { 17, "photo7.png", 3, 2 },
                    { 18, "photo8.png", 3, 2 },
                    { 19, "photo9.png", 3, 2 }
                });

            migrationBuilder.UpdateData(
                table: "TourTypes",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "TourDateFrom", "TourDateTo" },
                values: new object[] { new DateTime(2020, 4, 14, 1, 1, 22, 877, DateTimeKind.Local).AddTicks(3159), new DateTime(2020, 4, 17, 1, 1, 22, 883, DateTimeKind.Local).AddTicks(2963) });

            migrationBuilder.UpdateData(
                table: "TourTypes",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "TourDateFrom", "TourDateTo" },
                values: new object[] { new DateTime(2020, 4, 17, 1, 1, 22, 883, DateTimeKind.Local).AddTicks(6236), new DateTime(2020, 4, 19, 1, 1, 22, 883, DateTimeKind.Local).AddTicks(6468) });

            migrationBuilder.UpdateData(
                table: "TourTypes",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "TourDateFrom", "TourDateTo" },
                values: new object[] { new DateTime(2020, 4, 15, 1, 1, 22, 883, DateTimeKind.Local).AddTicks(6539), new DateTime(2020, 4, 22, 1, 1, 22, 883, DateTimeKind.Local).AddTicks(6549) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "TourPhotos",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "TourPhotos",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "TourPhotos",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "TourPhotos",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "TourPhotos",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "TourPhotos",
                keyColumn: "Id",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "TourPhotos",
                keyColumn: "Id",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "TourPhotos",
                keyColumn: "Id",
                keyValue: 19);

            migrationBuilder.CreateTable(
                name: "TourPhotoBackgrounds",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PhotoLink = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TourTypeId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TourPhotoBackgrounds", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TourPhotoBackgrounds_TourTypes_TourTypeId",
                        column: x => x.TourTypeId,
                        principalTable: "TourTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "TourPhotoBackgrounds",
                columns: new[] { "Id", "PhotoLink", "TourTypeId" },
                values: new object[,]
                {
                    { 1, "photo1.png", 1 },
                    { 8, "photo8.png", 3 },
                    { 7, "photo7.png", 3 },
                    { 6, "photo6.png", 2 },
                    { 9, "photo9.png", 3 },
                    { 4, "photo4.png", 2 },
                    { 3, "photo3.png", 1 },
                    { 2, "photo2.png", 1 },
                    { 5, "photo5.jpg", 2 }
                });

            migrationBuilder.UpdateData(
                table: "TourPhotos",
                keyColumn: "Id",
                keyValue: 7,
                column: "PhotoLink",
                value: "photo1.jpg");

            migrationBuilder.UpdateData(
                table: "TourPhotos",
                keyColumn: "Id",
                keyValue: 8,
                column: "PhotoLink",
                value: "photo2.jpg");

            migrationBuilder.UpdateData(
                table: "TourPhotos",
                keyColumn: "Id",
                keyValue: 9,
                column: "PhotoLink",
                value: "photo3.jpg");

            migrationBuilder.UpdateData(
                table: "TourPhotos",
                keyColumn: "Id",
                keyValue: 10,
                column: "PhotoLink",
                value: "photo4.jpg");

            migrationBuilder.UpdateData(
                table: "TourPhotos",
                keyColumn: "Id",
                keyValue: 11,
                columns: new[] { "PhotoLink", "TourTypeId", "ToutPhotoTypeId" },
                values: new object[] { "photo5.jpg", 3, 1 });

            migrationBuilder.UpdateData(
                table: "TourTypes",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "TourDateFrom", "TourDateTo" },
                values: new object[] { new DateTime(2020, 4, 13, 22, 50, 11, 332, DateTimeKind.Local).AddTicks(486), new DateTime(2020, 4, 16, 22, 50, 11, 340, DateTimeKind.Local).AddTicks(477) });

            migrationBuilder.UpdateData(
                table: "TourTypes",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "TourDateFrom", "TourDateTo" },
                values: new object[] { new DateTime(2020, 4, 16, 22, 50, 11, 341, DateTimeKind.Local).AddTicks(5782), new DateTime(2020, 4, 18, 22, 50, 11, 341, DateTimeKind.Local).AddTicks(5894) });

            migrationBuilder.UpdateData(
                table: "TourTypes",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "TourDateFrom", "TourDateTo" },
                values: new object[] { new DateTime(2020, 4, 14, 22, 50, 11, 341, DateTimeKind.Local).AddTicks(5937), new DateTime(2020, 4, 21, 22, 50, 11, 341, DateTimeKind.Local).AddTicks(5946) });

            migrationBuilder.CreateIndex(
                name: "IX_TourPhotoBackgrounds_TourTypeId",
                table: "TourPhotoBackgrounds",
                column: "TourTypeId");
        }
    }
}
