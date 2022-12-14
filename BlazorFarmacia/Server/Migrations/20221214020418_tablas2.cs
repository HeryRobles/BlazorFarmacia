using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BlazorFarmacia.Server.Migrations
{
    public partial class tablas2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "lote",
                table: "LoteProductos",
                newName: "Lote");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Lote",
                table: "LoteProductos",
                newName: "lote");
        }
    }
}
