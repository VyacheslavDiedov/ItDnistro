using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DataBase.Migrations
{
    public partial class AddTourPhotoBackground : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "EMail",
                table: "Participants",
                maxLength: 35,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(40)",
                oldMaxLength: 40);

            migrationBuilder.CreateTable(
                name: "TourPhotoBackgrounds",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PhotoLink = table.Column<string>(nullable: true),
                    TourTypeId = table.Column<int>(nullable: false)
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

            migrationBuilder.UpdateData(
                table: "TourTypes",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "TourDateFrom", "TourDateTo", "TourTypeDescription" },
                values: new object[] { new DateTime(2020, 4, 6, 22, 45, 9, 149, DateTimeKind.Local).AddTicks(5601), new DateTime(2020, 4, 9, 22, 45, 9, 154, DateTimeKind.Local).AddTicks(1335), "In My Core" });

            migrationBuilder.UpdateData(
                table: "TourTypes",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "TourDateFrom", "TourDateTo", "TourTypeDescription" },
                values: new object[] { new DateTime(2020, 4, 9, 22, 45, 9, 154, DateTimeKind.Local).AddTicks(2402), new DateTime(2020, 4, 11, 22, 45, 9, 154, DateTimeKind.Local).AddTicks(2454), "Pass with little losses" });

            migrationBuilder.UpdateData(
                table: "TourTypes",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "TourDateFrom", "TourDateTo", "TourTypeDescription" },
                values: new object[] { new DateTime(2020, 4, 7, 22, 45, 9, 154, DateTimeKind.Local).AddTicks(2473), new DateTime(2020, 4, 14, 22, 45, 9, 154, DateTimeKind.Local).AddTicks(2479), "Move Your Drive" });

            migrationBuilder.CreateIndex(
                name: "IX_TourPhotoBackgrounds_TourTypeId",
                table: "TourPhotoBackgrounds",
                column: "TourTypeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TourPhotoBackgrounds");

            migrationBuilder.AlterColumn<string>(
                name: "EMail",
                table: "Participants",
                type: "nvarchar(40)",
                maxLength: 40,
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 35);

            migrationBuilder.UpdateData(
                table: "TourTypes",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "TourDateFrom", "TourDateTo", "TourTypeDescription" },
                values: new object[] { new DateTime(2020, 4, 4, 10, 26, 57, 748, DateTimeKind.Local).AddTicks(3561), new DateTime(2020, 4, 7, 10, 26, 57, 753, DateTimeKind.Local).AddTicks(4215), "For those who like to relax on the river bank" });

            migrationBuilder.UpdateData(
                table: "TourTypes",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "TourDateFrom", "TourDateTo", "TourTypeDescription" },
                values: new object[] { new DateTime(2020, 4, 7, 10, 26, 57, 753, DateTimeKind.Local).AddTicks(5051), new DateTime(2020, 4, 9, 10, 26, 57, 753, DateTimeKind.Local).AddTicks(5112), "For those who like to relax in the mountains" });

            migrationBuilder.UpdateData(
                table: "TourTypes",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "TourDateFrom", "TourDateTo", "TourTypeDescription" },
                values: new object[] { new DateTime(2020, 4, 5, 10, 26, 57, 753, DateTimeKind.Local).AddTicks(5146), new DateTime(2020, 4, 12, 10, 26, 57, 753, DateTimeKind.Local).AddTicks(5155), "For those who love fjords" });
        }
    }
}
