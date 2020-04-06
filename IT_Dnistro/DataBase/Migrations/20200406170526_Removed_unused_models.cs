using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DataBase.Migrations
{
    public partial class Removed_unused_models : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "TourTypes",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "TourDateFrom", "TourDateTo" },
                values: new object[] { new DateTime(2020, 4, 13, 20, 5, 26, 127, DateTimeKind.Local).AddTicks(431), new DateTime(2020, 4, 16, 20, 5, 26, 129, DateTimeKind.Local).AddTicks(4964) });

            migrationBuilder.UpdateData(
                table: "TourTypes",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "TourDateFrom", "TourDateTo" },
                values: new object[] { new DateTime(2020, 4, 16, 20, 5, 26, 129, DateTimeKind.Local).AddTicks(6056), new DateTime(2020, 4, 18, 20, 5, 26, 129, DateTimeKind.Local).AddTicks(6088) });

            migrationBuilder.UpdateData(
                table: "TourTypes",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "TourDateFrom", "TourDateTo" },
                values: new object[] { new DateTime(2020, 4, 14, 20, 5, 26, 129, DateTimeKind.Local).AddTicks(6104), new DateTime(2020, 4, 21, 20, 5, 26, 129, DateTimeKind.Local).AddTicks(6108) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "TourTypes",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "TourDateFrom", "TourDateTo" },
                values: new object[] { new DateTime(2020, 4, 13, 20, 0, 58, 73, DateTimeKind.Local).AddTicks(193), new DateTime(2020, 4, 16, 20, 0, 58, 75, DateTimeKind.Local).AddTicks(3614) });

            migrationBuilder.UpdateData(
                table: "TourTypes",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "TourDateFrom", "TourDateTo" },
                values: new object[] { new DateTime(2020, 4, 16, 20, 0, 58, 75, DateTimeKind.Local).AddTicks(4688), new DateTime(2020, 4, 18, 20, 0, 58, 75, DateTimeKind.Local).AddTicks(4723) });

            migrationBuilder.UpdateData(
                table: "TourTypes",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "TourDateFrom", "TourDateTo" },
                values: new object[] { new DateTime(2020, 4, 14, 20, 0, 58, 75, DateTimeKind.Local).AddTicks(4741), new DateTime(2020, 4, 21, 20, 0, 58, 75, DateTimeKind.Local).AddTicks(4745) });
        }
    }
}
