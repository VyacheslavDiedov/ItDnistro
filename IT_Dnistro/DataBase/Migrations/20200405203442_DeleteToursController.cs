using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DataBase.Migrations
{
    public partial class DeleteToursController : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tours_TourTypes_TourTypeId",
                table: "Tours");

            migrationBuilder.DropForeignKey(
                name: "FK_UserTours_Tours_TourId",
                table: "UserTours");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Tours",
                table: "Tours");

            migrationBuilder.RenameTable(
                name: "Tours",
                newName: "Tour");

            migrationBuilder.RenameIndex(
                name: "IX_Tours_TourTypeId",
                table: "Tour",
                newName: "IX_Tour_TourTypeId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Tour",
                table: "Tour",
                column: "Id");

            migrationBuilder.UpdateData(
                table: "TourPhotoBackgrounds",
                keyColumn: "Id",
                keyValue: 1,
                column: "PhotoLink",
                value: "photo1.png");

            migrationBuilder.UpdateData(
                table: "TourPhotoBackgrounds",
                keyColumn: "Id",
                keyValue: 2,
                column: "PhotoLink",
                value: "photo2.png");

            migrationBuilder.UpdateData(
                table: "TourPhotoBackgrounds",
                keyColumn: "Id",
                keyValue: 3,
                column: "PhotoLink",
                value: "photo3.png");

            migrationBuilder.UpdateData(
                table: "TourPhotoBackgrounds",
                keyColumn: "Id",
                keyValue: 4,
                column: "PhotoLink",
                value: "photo4.png");

            migrationBuilder.UpdateData(
                table: "TourPhotoBackgrounds",
                keyColumn: "Id",
                keyValue: 6,
                column: "PhotoLink",
                value: "photo6.png");

            migrationBuilder.UpdateData(
                table: "TourPhotoBackgrounds",
                keyColumn: "Id",
                keyValue: 7,
                column: "PhotoLink",
                value: "photo7.png");

            migrationBuilder.UpdateData(
                table: "TourPhotoBackgrounds",
                keyColumn: "Id",
                keyValue: 8,
                column: "PhotoLink",
                value: "photo8.png");

            migrationBuilder.UpdateData(
                table: "TourPhotoBackgrounds",
                keyColumn: "Id",
                keyValue: 9,
                column: "PhotoLink",
                value: "photo9.png");

            migrationBuilder.UpdateData(
                table: "TourTypes",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "TourDateFrom", "TourDateTo" },
                values: new object[] { new DateTime(2020, 4, 12, 23, 34, 31, 65, DateTimeKind.Local).AddTicks(6797), new DateTime(2020, 4, 15, 23, 34, 31, 69, DateTimeKind.Local).AddTicks(7749) });

            migrationBuilder.UpdateData(
                table: "TourTypes",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "TourDateFrom", "TourDateTo" },
                values: new object[] { new DateTime(2020, 4, 15, 23, 34, 31, 69, DateTimeKind.Local).AddTicks(8713), new DateTime(2020, 4, 17, 23, 34, 31, 69, DateTimeKind.Local).AddTicks(8758) });

            migrationBuilder.UpdateData(
                table: "TourTypes",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "TourDateFrom", "TourDateTo" },
                values: new object[] { new DateTime(2020, 4, 13, 23, 34, 31, 69, DateTimeKind.Local).AddTicks(8774), new DateTime(2020, 4, 20, 23, 34, 31, 69, DateTimeKind.Local).AddTicks(8779) });

            migrationBuilder.AddForeignKey(
                name: "FK_Tour_TourTypes_TourTypeId",
                table: "Tour",
                column: "TourTypeId",
                principalTable: "TourTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserTours_Tour_TourId",
                table: "UserTours",
                column: "TourId",
                principalTable: "Tour",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tour_TourTypes_TourTypeId",
                table: "Tour");

            migrationBuilder.DropForeignKey(
                name: "FK_UserTours_Tour_TourId",
                table: "UserTours");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Tour",
                table: "Tour");

            migrationBuilder.RenameTable(
                name: "Tour",
                newName: "Tours");

            migrationBuilder.RenameIndex(
                name: "IX_Tour_TourTypeId",
                table: "Tours",
                newName: "IX_Tours_TourTypeId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Tours",
                table: "Tours",
                column: "Id");

            migrationBuilder.UpdateData(
                table: "TourPhotoBackgrounds",
                keyColumn: "Id",
                keyValue: 1,
                column: "PhotoLink",
                value: "photo1.jpg");

            migrationBuilder.UpdateData(
                table: "TourPhotoBackgrounds",
                keyColumn: "Id",
                keyValue: 2,
                column: "PhotoLink",
                value: "photo2.jpg");

            migrationBuilder.UpdateData(
                table: "TourPhotoBackgrounds",
                keyColumn: "Id",
                keyValue: 3,
                column: "PhotoLink",
                value: "photo3.jpg");

            migrationBuilder.UpdateData(
                table: "TourPhotoBackgrounds",
                keyColumn: "Id",
                keyValue: 4,
                column: "PhotoLink",
                value: "photo4.jpg");

            migrationBuilder.UpdateData(
                table: "TourPhotoBackgrounds",
                keyColumn: "Id",
                keyValue: 6,
                column: "PhotoLink",
                value: "photo6.jpg");

            migrationBuilder.UpdateData(
                table: "TourPhotoBackgrounds",
                keyColumn: "Id",
                keyValue: 7,
                column: "PhotoLink",
                value: "photo7.jpg");

            migrationBuilder.UpdateData(
                table: "TourPhotoBackgrounds",
                keyColumn: "Id",
                keyValue: 8,
                column: "PhotoLink",
                value: "photo8.jpg");

            migrationBuilder.UpdateData(
                table: "TourPhotoBackgrounds",
                keyColumn: "Id",
                keyValue: 9,
                column: "PhotoLink",
                value: "photo9.jpg");

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

            migrationBuilder.AddForeignKey(
                name: "FK_Tours_TourTypes_TourTypeId",
                table: "Tours",
                column: "TourTypeId",
                principalTable: "TourTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserTours_Tours_TourId",
                table: "UserTours",
                column: "TourId",
                principalTable: "Tours",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
