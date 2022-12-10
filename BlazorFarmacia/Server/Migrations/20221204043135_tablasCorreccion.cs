using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BlazorFarmacia.Server.Migrations
{
    public partial class tablasCorreccion : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Usuarios_Usuarios_UsuarioId",
                table: "Usuarios");

            migrationBuilder.DropIndex(
                name: "IX_Usuarios_UsuarioId",
                table: "Usuarios");

            migrationBuilder.DropColumn(
                name: "UsuarioId",
                table: "Usuarios");

            migrationBuilder.CreateIndex(
                name: "IX_Empleados_UsuarioId",
                table: "Empleados",
                column: "UsuarioId");

            migrationBuilder.AddForeignKey(
                name: "FK_Empleados_Usuarios_UsuarioId",
                table: "Empleados",
                column: "UsuarioId",
                principalTable: "Usuarios",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Empleados_Usuarios_UsuarioId",
                table: "Empleados");

            migrationBuilder.DropIndex(
                name: "IX_Empleados_UsuarioId",
                table: "Empleados");

            migrationBuilder.AddColumn<int>(
                name: "UsuarioId",
                table: "Usuarios",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Usuarios_UsuarioId",
                table: "Usuarios",
                column: "UsuarioId");

            migrationBuilder.AddForeignKey(
                name: "FK_Usuarios_Usuarios_UsuarioId",
                table: "Usuarios",
                column: "UsuarioId",
                principalTable: "Usuarios",
                principalColumn: "Id");
        }
    }
}
