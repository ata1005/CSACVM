using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CSACVM.AccesoDatos.Migrations
{
    public partial class CambiarForeignKeyFotoUsuarioCVUsuarioCV : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FotoUsuarioCV_UsuarioCV_IdUsuario",
                table: "FotoUsuarioCV");

            migrationBuilder.DropIndex(
                name: "IX_FotoUsuarioCV_IdUsuario",
                table: "FotoUsuarioCV");

            migrationBuilder.DropColumn(
                name: "IdUsuario",
                table: "FotoUsuarioCV");

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FotoUsuarioCV_UsuarioCV_IdUsuarioCV",
                table: "FotoUsuarioCV");

            migrationBuilder.DropIndex(
                name: "IX_FotoUsuarioCV_IdUsuarioCV",
                table: "FotoUsuarioCV");

            migrationBuilder.AddColumn<int>(
                name: "IdUsuario",
                table: "FotoUsuarioCV",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_FotoUsuarioCV_IdUsuario",
                table: "FotoUsuarioCV",
                column: "IdUsuario");

            migrationBuilder.AddForeignKey(
                name: "FK_FotoUsuarioCV_UsuarioCV_IdUsuario",
                table: "FotoUsuarioCV",
                column: "IdUsuario",
                principalTable: "UsuarioCV",
                principalColumn: "IdUsuarioCV",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
