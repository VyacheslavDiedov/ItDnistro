using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DataBase.Migrations
{
    public partial class ChangeUserType : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserTours_Users_UserId",
                table: "UserTours");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropIndex(
                name: "IX_UserTours_UserId",
                table: "UserTours");

            //migrationBuilder.AddColumn<string>(
            //    name: "UserId1",
            //    table: "UserTours",
            //    nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_UserTours_UserId",
                table: "UserTours",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_UserTours_AspNetUsers_UserId",
                table: "UserTours",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserTours_AspNetUsers_UserId",
                table: "UserTours");

            migrationBuilder.DropIndex(
                name: "IX_UserTours_UserId",
                table: "UserTours");

            //migrationBuilder.DropColumn(
            //    name: "UserId",
            //    table: "UserTours");

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BirthDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Country = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EMail = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Gender = table.Column<int>(type: "int", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_UserTours_UserId",
                table: "UserTours",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_UserTours_Users_UserId",
                table: "UserTours",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
