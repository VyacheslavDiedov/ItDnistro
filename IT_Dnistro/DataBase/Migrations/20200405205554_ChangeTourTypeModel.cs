using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DataBase.Migrations
{
    public partial class ChangeTourTypeModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "TourTypeTagName",
                table: "TourTypes",
                maxLength: 50,
                nullable: true);

            migrationBuilder.UpdateData(
                table: "TourTypes",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "TourDateFrom", "TourDateTo", "TourTypeDescription", "TourTypeTagName" },
                values: new object[] { new DateTime(2020, 4, 12, 23, 55, 52, 272, DateTimeKind.Local).AddTicks(9340), new DateTime(2020, 4, 15, 23, 55, 52, 281, DateTimeKind.Local).AddTicks(4148), "Вінницька IT Академія відкриває для всіх бажаючих простори рідного регіону. Ми підготували для вас цікаву і насичену програму. Беріть з собою друзів і гайда підкорювати нові «вершини»! Свіже повітря, захоплюючі пейзажі, гарна компанія - все для любителів активного відпочинку. Ми побачимо краєвиди, від яких точно перехопить подих. А вашим фотографіям  будуть заздрити всі знайомі. Пізнаємо рідний край,  проникаємось любов'ю до нього ;-) у приємній дружній компанії.", "In My Core" });

            migrationBuilder.UpdateData(
                table: "TourTypes",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "TourDateFrom", "TourDateTo", "TourTypeDescription", "TourTypeTagName" },
                values: new object[] { new DateTime(2020, 4, 15, 23, 55, 52, 281, DateTimeKind.Local).AddTicks(6570), new DateTime(2020, 4, 17, 23, 55, 52, 281, DateTimeKind.Local).AddTicks(6636), "Вінницька IT Академія відкриває для всіх бажаючих простори рідного регіону. Ми підготували для вас цікаву і насичену програму. Беріть з собою друзів і гайда підкорювати нові «вершини»! Свіже повітря, захоплюючі пейзажі, гарна компанія - все для любителів активного відпочинку. Ми побачимо краєвиди, від яких точно перехопить подих. А вашим фотографіям  будуть заздрити всі знайомі. Пізнаємо рідний край,  проникаємось любов'ю до нього ;-) у приємній дружній компанії.", "Pass with little losses" });

            migrationBuilder.UpdateData(
                table: "TourTypes",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "TourDateFrom", "TourDateTo", "TourTypeDescription", "TourTypeTagName" },
                values: new object[] { new DateTime(2020, 4, 13, 23, 55, 52, 281, DateTimeKind.Local).AddTicks(6685), new DateTime(2020, 4, 20, 23, 55, 52, 281, DateTimeKind.Local).AddTicks(6695), "Вінницька IT Академія відкриває для всіх бажаючих простори рідного регіону. Ми підготували для вас цікаву і насичену програму. Беріть з собою друзів і гайда підкорювати нові «вершини»! Свіже повітря, захоплюючі пейзажі, гарна компанія - все для любителів активного відпочинку. Ми побачимо краєвиди, від яких точно перехопить подих. А вашим фотографіям  будуть заздрити всі знайомі. Пізнаємо рідний край,  проникаємось любов'ю до нього ;-) у приємній дружній компанії.", "Move Your Drive" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TourTypeTagName",
                table: "TourTypes");

            migrationBuilder.UpdateData(
                table: "TourTypes",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "TourDateFrom", "TourDateTo", "TourTypeDescription" },
                values: new object[] { new DateTime(2020, 4, 12, 23, 34, 31, 65, DateTimeKind.Local).AddTicks(6797), new DateTime(2020, 4, 15, 23, 34, 31, 69, DateTimeKind.Local).AddTicks(7749), "In My Core" });

            migrationBuilder.UpdateData(
                table: "TourTypes",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "TourDateFrom", "TourDateTo", "TourTypeDescription" },
                values: new object[] { new DateTime(2020, 4, 15, 23, 34, 31, 69, DateTimeKind.Local).AddTicks(8713), new DateTime(2020, 4, 17, 23, 34, 31, 69, DateTimeKind.Local).AddTicks(8758), "Pass with little losses" });

            migrationBuilder.UpdateData(
                table: "TourTypes",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "TourDateFrom", "TourDateTo", "TourTypeDescription" },
                values: new object[] { new DateTime(2020, 4, 13, 23, 34, 31, 69, DateTimeKind.Local).AddTicks(8774), new DateTime(2020, 4, 20, 23, 34, 31, 69, DateTimeKind.Local).AddTicks(8779), "Move Your Drive" });
        }
    }
}
