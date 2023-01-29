using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CSACVM.AccesoDatos.Migrations
{
    public partial class AnadirBiografiaUsuario : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Biografia",
                table: "Usuario",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Biografia",
                table: "Usuario");
        }
    }
}
