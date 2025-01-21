using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FantasyApp.Migrations
{
    public partial class mig2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CzyTransfer",
                columns: table => new
                {
                    CzyTransferId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    czyTransfer = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CzyTransfer", x => x.CzyTransferId);
                });

            migrationBuilder.InsertData(
                table: "CzyTransfer",
                columns: new[] { "CzyTransferId", "czyTransfer" },
                values: new object[] { 1, false });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CzyTransfer");
        }
    }
}
