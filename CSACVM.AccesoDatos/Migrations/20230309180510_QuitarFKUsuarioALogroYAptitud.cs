using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CSACVM.AccesoDatos.Migrations
{
    public partial class QuitarFKUsuarioALogroYAptitud : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AptitudCV_Usuario_IdUsuario",
                table: "AptitudCV");

            migrationBuilder.DropIndex(
                name: "IX_AptitudCV_IdUsuario",
                table: "AptitudCV");

            migrationBuilder.DropColumn(
                name: "IdUsuario",
                table: "AptitudCV");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "IdUsuario",
                table: "AptitudCV",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_AptitudCV_IdUsuario",
                table: "AptitudCV",
                column: "IdUsuario");

            migrationBuilder.AddForeignKey(
                name: "FK_AptitudCV_Usuario_IdUsuario",
                table: "AptitudCV",
                column: "IdUsuario",
                principalTable: "Usuario",
                principalColumn: "IdUsuario",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
