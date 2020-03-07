using Microsoft.EntityFrameworkCore.Migrations;

namespace DataBase.Migrations
{
    public partial class initial_data : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Admins");

            migrationBuilder.InsertData(
                table: "TourTypes",
                columns: new[] { "Id", "TourTypeDescription", "TourTypeName" },
                values: new object[] { 1, "For those who like to relax on the river bank", "Dnistro" });

            migrationBuilder.InsertData(
                table: "TourTypes",
                columns: new[] { "Id", "TourTypeDescription", "TourTypeName" },
                values: new object[] { 2, "For those who like to relax in the mountains", "Carpaty" });

            migrationBuilder.InsertData(
                table: "TourTypes",
                columns: new[] { "Id", "TourTypeDescription", "TourTypeName" },
                values: new object[] { 3, "For those who love fjords", "Scandinadia" });

            migrationBuilder.InsertData(
                table: "TourPhotos",
                columns: new[] { "Id", "PhotoLink", "TourTypeId" },
                values: new object[,]
                {
                    { 1, "foto1.jpg", 1 },
                    { 2, "foto2.jpg", 1 },
                    { 3, "foto3.jpg", 1 },
                    { 4, "foto4.jpg", 2 },
                    { 5, "foto5.jpg", 2 },
                    { 6, "foto6.jpg", 2 },
                    { 7, "photo1.jpg", 3 },
                    { 8, "photo2.jpg", 3 },
                    { 9, "photo3.jpg", 3 },
                    { 10, "photo4.jpg", 3 },
                    { 11, "photo5.jpg", 3 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "TourPhotos",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "TourPhotos",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "TourPhotos",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "TourPhotos",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "TourPhotos",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "TourPhotos",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "TourPhotos",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "TourPhotos",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "TourPhotos",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "TourPhotos",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "TourPhotos",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "TourTypes",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "TourTypes",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "TourTypes",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.CreateTable(
                name: "Admins",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Admins", x => x.Id);
                });
        }
    }
}
