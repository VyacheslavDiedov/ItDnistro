using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DataBase.Migrations
{
    public partial class TourPhotoTape : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ToutPhotoTypeId",
                table: "TourPhotos",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "ToutPhotoTypes",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ToutPhotoTypes", x => x.Id);
                });

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

            migrationBuilder.InsertData(
                table: "ToutPhotoTypes",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "General" },
                    { 2, "Background" }
                });

            migrationBuilder.UpdateData(
                table: "TourPhotos",
                keyColumn: "Id",
                keyValue: 1,
                column: "ToutPhotoTypeId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "TourPhotos",
                keyColumn: "Id",
                keyValue: 2,
                column: "ToutPhotoTypeId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "TourPhotos",
                keyColumn: "Id",
                keyValue: 3,
                column: "ToutPhotoTypeId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "TourPhotos",
                keyColumn: "Id",
                keyValue: 4,
                column: "ToutPhotoTypeId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "TourPhotos",
                keyColumn: "Id",
                keyValue: 5,
                column: "ToutPhotoTypeId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "TourPhotos",
                keyColumn: "Id",
                keyValue: 6,
                column: "ToutPhotoTypeId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "TourPhotos",
                keyColumn: "Id",
                keyValue: 7,
                column: "ToutPhotoTypeId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "TourPhotos",
                keyColumn: "Id",
                keyValue: 8,
                column: "ToutPhotoTypeId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "TourPhotos",
                keyColumn: "Id",
                keyValue: 9,
                column: "ToutPhotoTypeId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "TourPhotos",
                keyColumn: "Id",
                keyValue: 10,
                column: "ToutPhotoTypeId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "TourPhotos",
                keyColumn: "Id",
                keyValue: 11,
                column: "ToutPhotoTypeId",
                value: 1);

            migrationBuilder.CreateIndex(
                name: "IX_TourPhotos_ToutPhotoTypeId",
                table: "TourPhotos",
                column: "ToutPhotoTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_TourPhotos_ToutPhotoTypes_ToutPhotoTypeId",
                table: "TourPhotos",
                column: "ToutPhotoTypeId",
                principalTable: "ToutPhotoTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TourPhotos_ToutPhotoTypes_ToutPhotoTypeId",
                table: "TourPhotos");

            migrationBuilder.DropTable(
                name: "ToutPhotoTypes");

            migrationBuilder.DropIndex(
                name: "IX_TourPhotos_ToutPhotoTypeId",
                table: "TourPhotos");

            migrationBuilder.DropColumn(
                name: "ToutPhotoTypeId",
                table: "TourPhotos");

            migrationBuilder.UpdateData(
                table: "TourTypes",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "TourDateFrom", "TourDateTo" },
                values: new object[] { new DateTime(2020, 4, 12, 23, 55, 52, 272, DateTimeKind.Local).AddTicks(9340), new DateTime(2020, 4, 15, 23, 55, 52, 281, DateTimeKind.Local).AddTicks(4148) });

            migrationBuilder.UpdateData(
                table: "TourTypes",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "TourDateFrom", "TourDateTo" },
                values: new object[] { new DateTime(2020, 4, 15, 23, 55, 52, 281, DateTimeKind.Local).AddTicks(6570), new DateTime(2020, 4, 17, 23, 55, 52, 281, DateTimeKind.Local).AddTicks(6636) });

            migrationBuilder.UpdateData(
                table: "TourTypes",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "TourDateFrom", "TourDateTo" },
                values: new object[] { new DateTime(2020, 4, 13, 23, 55, 52, 281, DateTimeKind.Local).AddTicks(6685), new DateTime(2020, 4, 20, 23, 55, 52, 281, DateTimeKind.Local).AddTicks(6695) });
        }
    }
}
