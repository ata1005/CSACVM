using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CSACVM.AccesoDatos.Migrations
{
    public partial class QuitarReferenciaUsuarioCVEnFotoUsuarioCV : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FotoUsuarioCV_UsuarioCV_IdUsuarioCV",
                table: "FotoUsuarioCV");

            migrationBuilder.DropIndex(
                name: "IX_FotoUsuarioCV_IdUsuarioCV",
                table: "FotoUsuarioCV");

            migrationBuilder.DropColumn(
                name: "IdUsuarioCV",
                table: "FotoUsuarioCV");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "IdUsuarioCV",
                table: "FotoUsuarioCV",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_FotoUsuarioCV_IdUsuarioCV",
                table: "FotoUsuarioCV",
                column: "IdUsuarioCV");

            migrationBuilder.AddForeignKey(
                name: "FK_FotoUsuarioCV_UsuarioCV_IdUsuarioCV",
                table: "FotoUsuarioCV",
                column: "IdUsuarioCV",
                principalTable: "UsuarioCV",
                principalColumn: "IdUsuarioCV",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
