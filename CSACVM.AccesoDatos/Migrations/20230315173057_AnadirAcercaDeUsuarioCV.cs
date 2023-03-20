using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CSACVM.AccesoDatos.Migrations
{
    public partial class AnadirAcercaDeUsuarioCV : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "AcercaDe",
                table: "UsuarioCV",
                type: "nvarchar(max)",
                maxLength: 2147483647,
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AcercaDe",
                table: "UsuarioCV");
        }
    }
}
