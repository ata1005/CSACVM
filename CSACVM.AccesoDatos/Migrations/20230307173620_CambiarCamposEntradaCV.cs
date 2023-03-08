using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CSACVM.AccesoDatos.Migrations
{
    public partial class CambiarCamposEntradaCV : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Descripcion",
                table: "EntradaCV");

            migrationBuilder.RenameColumn(
                name: "NombreTitulacion",
                table: "EntradaCV",
                newName: "PuestoTrabajo");

            migrationBuilder.AddColumn<string>(
                name: "Observaciones",
                table: "EntradaCV",
                type: "nvarchar(max)",
                maxLength: 2147483647,
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Observaciones",
                table: "EntradaCV");

            migrationBuilder.RenameColumn(
                name: "PuestoTrabajo",
                table: "EntradaCV",
                newName: "NombreTitulacion");

            migrationBuilder.AddColumn<string>(
                name: "Descripcion",
                table: "EntradaCV",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");
        }
    }
}
