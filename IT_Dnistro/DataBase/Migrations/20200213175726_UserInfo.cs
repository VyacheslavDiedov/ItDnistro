using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DataBase.Migrations
{
    public partial class UserInfo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tour_TourTypes_TourTypeId",
                table: "Tour");

            migrationBuilder.DropForeignKey(
                name: "FK_UserTour_Tour_TourId",
                table: "UserTour");

            migrationBuilder.DropForeignKey(
                name: "FK_UserTour_AspNetUsers_UserId1",
                table: "UserTour");

            migrationBuilder.DropUniqueConstraint(
                name: "AK_Tour_TempId",
                table: "Tour");

            migrationBuilder.RenameTable(
                name: "UserTour",
                newName: "UserTours");

            migrationBuilder.RenameTable(
                name: "Tour",
                newName: "Tours");

            migrationBuilder.RenameColumn(
                name: "TempId",
                table: "Tours",
                newName: "TourLength");

            migrationBuilder.AddColumn<DateTime>(
                name: "BirthDate",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "City",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Country",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "FirstName",
                table: "AspNetUsers",
                maxLength: 30,
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Gender",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LastName",
                table: "AspNetUsers",
                maxLength: 30,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "AspNetUsers",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<int>(
                name: "TourId",
                table: "UserTours",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "UserTours",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<string>(
                name: "HowFoundUs",
                table: "UserTours",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "UserTours",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<int>(
                name: "TourTypeId",
                table: "Tours",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "Tours",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<DateTime>(
                name: "TourDate",
                table: "Tours",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "TourName",
                table: "Tours",
                maxLength: 50,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserTours",
                table: "UserTours",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Tours",
                table: "Tours",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_UserTours_TourId",
                table: "UserTours",
                column: "TourId");

            migrationBuilder.CreateIndex(
                name: "IX_UserTours_UserId1",
                table: "UserTours",
                column: "UserId1");

            migrationBuilder.CreateIndex(
                name: "IX_Tours_TourTypeId",
                table: "Tours",
                column: "TourTypeId");

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

            migrationBuilder.AddForeignKey(
                name: "FK_UserTours_AspNetUsers_UserId1",
                table: "UserTours",
                column: "UserId1",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tours_TourTypes_TourTypeId",
                table: "Tours");

            migrationBuilder.DropForeignKey(
                name: "FK_UserTours_Tours_TourId",
                table: "UserTours");

            migrationBuilder.DropForeignKey(
                name: "FK_UserTours_AspNetUsers_UserId1",
                table: "UserTours");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserTours",
                table: "UserTours");

            migrationBuilder.DropIndex(
                name: "IX_UserTours_TourId",
                table: "UserTours");

            migrationBuilder.DropIndex(
                name: "IX_UserTours_UserId1",
                table: "UserTours");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Tours",
                table: "Tours");

            migrationBuilder.DropIndex(
                name: "IX_Tours_TourTypeId",
                table: "Tours");

            migrationBuilder.DropColumn(
                name: "BirthDate",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "City",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Country",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "FirstName",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Gender",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "LastName",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "UserTours");

            migrationBuilder.DropColumn(
                name: "HowFoundUs",
                table: "UserTours");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "UserTours");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "Tours");

            migrationBuilder.DropColumn(
                name: "TourDate",
                table: "Tours");

            migrationBuilder.DropColumn(
                name: "TourName",
                table: "Tours");

            migrationBuilder.RenameTable(
                name: "UserTours",
                newName: "UserTour");

            migrationBuilder.RenameTable(
                name: "Tours",
                newName: "Tour");

            migrationBuilder.RenameColumn(
                name: "TourLength",
                table: "Tour",
                newName: "TempId");

            migrationBuilder.AlterColumn<int>(
                name: "TourId",
                table: "UserTour",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<int>(
                name: "TourTypeId",
                table: "Tour",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddUniqueConstraint(
                name: "AK_Tour_TempId",
                table: "Tour",
                column: "TempId");

            migrationBuilder.AddForeignKey(
                name: "FK_Tour_TourTypes_TourTypeId",
                table: "Tour",
                column: "TourTypeId",
                principalTable: "TourTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserTour_Tour_TourId",
                table: "UserTour",
                column: "TourId",
                principalTable: "Tour",
                principalColumn: "TempId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserTour_AspNetUsers_UserId1",
                table: "UserTour",
                column: "UserId1",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
