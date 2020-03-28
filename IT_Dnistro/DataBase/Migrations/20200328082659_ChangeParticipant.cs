using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DataBase.Migrations
{
    public partial class ChangeParticipant : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "PhoneNumber",
                table: "Participants",
                maxLength: 20,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "FullName",
                table: "Participants",
                maxLength: 40,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<string>(
                name: "EMail",
                table: "Participants",
                maxLength: 35,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.UpdateData(
                table: "TourTypes",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "TourDateFrom", "TourDateTo", "TourTypeName" },
                values: new object[] { new DateTime(2020, 4, 4, 10, 26, 57, 748, DateTimeKind.Local).AddTicks(3561), new DateTime(2020, 4, 7, 10, 26, 57, 753, DateTimeKind.Local).AddTicks(4215), "IT DnistrO" });

            migrationBuilder.UpdateData(
                table: "TourTypes",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "TourDateFrom", "TourDateTo", "TourTypeName" },
                values: new object[] { new DateTime(2020, 4, 7, 10, 26, 57, 753, DateTimeKind.Local).AddTicks(5051), new DateTime(2020, 4, 9, 10, 26, 57, 753, DateTimeKind.Local).AddTicks(5112), "IT Carpaty" });

            migrationBuilder.UpdateData(
                table: "TourTypes",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "TourDateFrom", "TourDateTo", "TourTypeName" },
                values: new object[] { new DateTime(2020, 4, 5, 10, 26, 57, 753, DateTimeKind.Local).AddTicks(5146), new DateTime(2020, 4, 12, 10, 26, 57, 753, DateTimeKind.Local).AddTicks(5155), "IT Scandinavia" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "PhoneNumber",
                table: "Participants",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 20);

            migrationBuilder.AlterColumn<string>(
                name: "FullName",
                table: "Participants",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 40);

            migrationBuilder.AlterColumn<string>(
                name: "EMail",
                table: "Participants",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 40);

            migrationBuilder.UpdateData(
                table: "TourTypes",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "TourDateFrom", "TourDateTo", "TourTypeName" },
                values: new object[] { new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Dnistro" });

            migrationBuilder.UpdateData(
                table: "TourTypes",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "TourDateFrom", "TourDateTo", "TourTypeName" },
                values: new object[] { new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Carpaty" });

            migrationBuilder.UpdateData(
                table: "TourTypes",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "TourDateFrom", "TourDateTo", "TourTypeName" },
                values: new object[] { new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Scandinadia" });
        }
    }
}
