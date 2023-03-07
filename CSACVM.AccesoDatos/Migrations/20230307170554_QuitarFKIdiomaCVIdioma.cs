using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CSACVM.AccesoDatos.Migrations
{
    public partial class QuitarFKIdiomaCVIdioma : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_IdiomaCV_Idioma_IdIdioma",
                table: "IdiomaCV");

            migrationBuilder.DropIndex(
                name: "IX_IdiomaCV_IdIdioma",
                table: "IdiomaCV");

            migrationBuilder.DropColumn(
                name: "IdIdioma",
                table: "IdiomaCV");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "IdIdioma",
                table: "IdiomaCV",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_IdiomaCV_IdIdioma",
                table: "IdiomaCV",
                column: "IdIdioma");

            migrationBuilder.AddForeignKey(
                name: "FK_IdiomaCV_Idioma_IdIdioma",
                table: "IdiomaCV",
                column: "IdIdioma",
                principalTable: "Idioma",
                principalColumn: "IdIdioma",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
