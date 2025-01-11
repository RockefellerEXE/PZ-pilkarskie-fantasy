using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FantasyApp.Migrations
{
    public partial class zmianaBudzetu : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "Budzet",
                table: "Druzyny",
                type: "decimal(18,2)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.UpdateData(
                table: "Druzyny",
                keyColumn: "DruzynaId",
                keyValue: 1,
                column: "Budzet",
                value: 100m);

            migrationBuilder.UpdateData(
                table: "Druzyny",
                keyColumn: "DruzynaId",
                keyValue: 2,
                column: "Budzet",
                value: 100m);

            migrationBuilder.UpdateData(
                table: "Druzyny",
                keyColumn: "DruzynaId",
                keyValue: 3,
                column: "Budzet",
                value: 100m);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "Budzet",
                table: "Druzyny",
                type: "int",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");

            migrationBuilder.UpdateData(
                table: "Druzyny",
                keyColumn: "DruzynaId",
                keyValue: 1,
                column: "Budzet",
                value: 100);

            migrationBuilder.UpdateData(
                table: "Druzyny",
                keyColumn: "DruzynaId",
                keyValue: 2,
                column: "Budzet",
                value: 100);

            migrationBuilder.UpdateData(
                table: "Druzyny",
                keyColumn: "DruzynaId",
                keyValue: 3,
                column: "Budzet",
                value: 100);
        }
    }
}
