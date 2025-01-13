using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FantasyApp.Migrations
{
    public partial class dodanieHistoriiCen : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "HistoriaCen",
                columns: table => new
                {
                    HistoriaCenId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ZawodnikId = table.Column<int>(type: "int", nullable: false),
                    Kolejka = table.Column<int>(type: "int", nullable: false),
                    Cena = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HistoriaCen", x => x.HistoriaCenId);
                    table.ForeignKey(
                        name: "FK_HistoriaCen_Zawodnicy_ZawodnikId",
                        column: x => x.ZawodnikId,
                        principalTable: "Zawodnicy",
                        principalColumn: "ZawodnikId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_HistoriaCen_ZawodnikId",
                table: "HistoriaCen",
                column: "ZawodnikId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "HistoriaCen");
        }
    }
}
