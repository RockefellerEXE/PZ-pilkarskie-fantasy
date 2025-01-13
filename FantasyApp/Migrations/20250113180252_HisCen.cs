using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FantasyApp.Migrations
{
    public partial class HisCen : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "HistoriaCen",
                columns: new[] { "HistoriaCenId", "CenaPrzed", "Kolejka", "ZawodnikId" },
                values: new object[,]
                {
                    { 1, 7m, 19, 1 },
                    { 2, 6m, 19, 2 },
                    { 3, 9m, 19, 3 },
                    { 4, 9m, 20, 14 },
                    { 5, 7m, 19, 1 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "HistoriaCen",
                keyColumn: "HistoriaCenId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "HistoriaCen",
                keyColumn: "HistoriaCenId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "HistoriaCen",
                keyColumn: "HistoriaCenId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "HistoriaCen",
                keyColumn: "HistoriaCenId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "HistoriaCen",
                keyColumn: "HistoriaCenId",
                keyValue: 5);
        }
    }
}
