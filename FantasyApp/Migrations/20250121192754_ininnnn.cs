using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FantasyApp.Migrations
{
    public partial class ininnnn : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Kluby",
                keyColumn: "KlubId",
                keyValue: 2,
                column: "Nazwa",
                value: "Jagiellonia Białystok");

            migrationBuilder.UpdateData(
                table: "Kluby",
                keyColumn: "KlubId",
                keyValue: 3,
                column: "Nazwa",
                value: "Raków Częstochowa");

            migrationBuilder.UpdateData(
                table: "Kluby",
                keyColumn: "KlubId",
                keyValue: 5,
                column: "Nazwa",
                value: "Pogoń Szczecin");

            migrationBuilder.UpdateData(
                table: "Kluby",
                keyColumn: "KlubId",
                keyValue: 6,
                column: "Nazwa",
                value: "Cracovia");

            migrationBuilder.UpdateData(
                table: "Kluby",
                keyColumn: "KlubId",
                keyValue: 7,
                column: "Nazwa",
                value: "Górnik Zabrze");

            migrationBuilder.UpdateData(
                table: "Kluby",
                keyColumn: "KlubId",
                keyValue: 8,
                column: "Nazwa",
                value: "Motor Lublin");

            migrationBuilder.UpdateData(
                table: "Kluby",
                keyColumn: "KlubId",
                keyValue: 12,
                column: "Nazwa",
                value: "Stal Mielec");

            migrationBuilder.UpdateData(
                table: "Kluby",
                keyColumn: "KlubId",
                keyValue: 13,
                column: "Nazwa",
                value: "Zagłębie Lubin");

            migrationBuilder.UpdateData(
                table: "Kluby",
                keyColumn: "KlubId",
                keyValue: 14,
                column: "Nazwa",
                value: "Puszcza Niepołomice");

            migrationBuilder.UpdateData(
                table: "Kluby",
                keyColumn: "KlubId",
                keyValue: 15,
                column: "Nazwa",
                value: "Korona Kielce");

            migrationBuilder.UpdateData(
                table: "Kluby",
                keyColumn: "KlubId",
                keyValue: 16,
                column: "Nazwa",
                value: "Radomiak Radom");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Kluby",
                keyColumn: "KlubId",
                keyValue: 2,
                column: "Nazwa",
                value: "Raków Częstochowa");

            migrationBuilder.UpdateData(
                table: "Kluby",
                keyColumn: "KlubId",
                keyValue: 3,
                column: "Nazwa",
                value: "Jagiellonia Białystok");

            migrationBuilder.UpdateData(
                table: "Kluby",
                keyColumn: "KlubId",
                keyValue: 5,
                column: "Nazwa",
                value: "Cracovia");

            migrationBuilder.UpdateData(
                table: "Kluby",
                keyColumn: "KlubId",
                keyValue: 6,
                column: "Nazwa",
                value: "Górnik Zabrze");

            migrationBuilder.UpdateData(
                table: "Kluby",
                keyColumn: "KlubId",
                keyValue: 7,
                column: "Nazwa",
                value: "Motor Lublin");

            migrationBuilder.UpdateData(
                table: "Kluby",
                keyColumn: "KlubId",
                keyValue: 8,
                column: "Nazwa",
                value: "Pogoń Szczecin");

            migrationBuilder.UpdateData(
                table: "Kluby",
                keyColumn: "KlubId",
                keyValue: 12,
                column: "Nazwa",
                value: "Radomiak Radom");

            migrationBuilder.UpdateData(
                table: "Kluby",
                keyColumn: "KlubId",
                keyValue: 13,
                column: "Nazwa",
                value: "Stal Mielec");

            migrationBuilder.UpdateData(
                table: "Kluby",
                keyColumn: "KlubId",
                keyValue: 14,
                column: "Nazwa",
                value: "Zagłębie Lubin");

            migrationBuilder.UpdateData(
                table: "Kluby",
                keyColumn: "KlubId",
                keyValue: 15,
                column: "Nazwa",
                value: "Puszcza Niepołomice");

            migrationBuilder.UpdateData(
                table: "Kluby",
                keyColumn: "KlubId",
                keyValue: 16,
                column: "Nazwa",
                value: "Korona Kielce");
        }
    }
}
