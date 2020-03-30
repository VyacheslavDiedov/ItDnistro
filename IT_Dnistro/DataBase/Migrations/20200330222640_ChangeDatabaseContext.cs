using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DataBase.Migrations
{
    public partial class ChangeDatabaseContext : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "TourPhotoBackgrounds",
                columns: new[] { "Id", "PhotoLink", "TourTypeId" },
                values: new object[,]
                {
                    { 1, "photo1.png", 1 },
                    { 2, "photo2.png", 1 },
                    { 3, "photo3.png", 1 },
                    { 4, "photo4.jpg", 2 },
                    { 5, "photo5.png", 2 },
                    { 6, "photo6.png", 2 },
                    { 7, "photo7.png", 3 },
                    { 8, "photo8.png", 3 },
                    { 9, "photo9.png", 3 }
                });

            migrationBuilder.UpdateData(
                table: "TourTypes",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "TourDateFrom", "TourDateTo" },
                values: new object[] { new DateTime(2020, 4, 7, 1, 26, 28, 470, DateTimeKind.Local).AddTicks(2178), new DateTime(2020, 4, 10, 1, 26, 28, 476, DateTimeKind.Local).AddTicks(4918) });

            migrationBuilder.UpdateData(
                table: "TourTypes",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "TourDateFrom", "TourDateTo" },
                values: new object[] { new DateTime(2020, 4, 10, 1, 26, 28, 476, DateTimeKind.Local).AddTicks(6377), new DateTime(2020, 4, 12, 1, 26, 28, 476, DateTimeKind.Local).AddTicks(6453) });

            migrationBuilder.UpdateData(
                table: "TourTypes",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "TourDateFrom", "TourDateTo" },
                values: new object[] { new DateTime(2020, 4, 8, 1, 26, 28, 476, DateTimeKind.Local).AddTicks(6487), new DateTime(2020, 4, 15, 1, 26, 28, 476, DateTimeKind.Local).AddTicks(6497) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "TourPhotoBackgrounds",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "TourPhotoBackgrounds",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "TourPhotoBackgrounds",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "TourPhotoBackgrounds",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "TourPhotoBackgrounds",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "TourPhotoBackgrounds",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "TourPhotoBackgrounds",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "TourPhotoBackgrounds",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "TourPhotoBackgrounds",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.UpdateData(
                table: "TourTypes",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "TourDateFrom", "TourDateTo" },
                values: new object[] { new DateTime(2020, 4, 6, 22, 45, 9, 149, DateTimeKind.Local).AddTicks(5601), new DateTime(2020, 4, 9, 22, 45, 9, 154, DateTimeKind.Local).AddTicks(1335) });

            migrationBuilder.UpdateData(
                table: "TourTypes",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "TourDateFrom", "TourDateTo" },
                values: new object[] { new DateTime(2020, 4, 9, 22, 45, 9, 154, DateTimeKind.Local).AddTicks(2402), new DateTime(2020, 4, 11, 22, 45, 9, 154, DateTimeKind.Local).AddTicks(2454) });

            migrationBuilder.UpdateData(
                table: "TourTypes",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "TourDateFrom", "TourDateTo" },
                values: new object[] { new DateTime(2020, 4, 7, 22, 45, 9, 154, DateTimeKind.Local).AddTicks(2473), new DateTime(2020, 4, 14, 22, 45, 9, 154, DateTimeKind.Local).AddTicks(2479) });
        }
    }
}
