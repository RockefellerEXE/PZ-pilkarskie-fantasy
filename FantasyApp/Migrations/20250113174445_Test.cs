using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FantasyApp.Migrations
{
    public partial class Test : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Cena",
                table: "HistoriaCen");

            migrationBuilder.AddColumn<decimal>(
                name: "CenaPrzed",
                table: "HistoriaCen",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CenaPrzed",
                table: "HistoriaCen");

            migrationBuilder.AddColumn<double>(
                name: "Cena",
                table: "HistoriaCen",
                type: "float",
                nullable: false,
                defaultValue: 0.0);
        }
    }
}
