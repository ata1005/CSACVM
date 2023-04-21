using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CSACVM.AccesoDatos.Migrations
{
    public partial class QuitarReferenciasEntradas : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Entrada_Proyecto_IdProyecto",
                table: "Entrada");

            migrationBuilder.DropForeignKey(
                name: "FK_Entrada_TipoEntrada_IdTipoEntrada",
                table: "Entrada");

            migrationBuilder.DropIndex(
                name: "IX_Entrada_IdTipoEntrada",
                table: "Entrada");

            migrationBuilder.DropColumn(
                name: "IdTipoEntrada",
                table: "Entrada");

            migrationBuilder.AlterColumn<int>(
                name: "IdProyecto",
                table: "Entrada",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Entrada_Proyecto_IdProyecto",
                table: "Entrada",
                column: "IdProyecto",
                principalTable: "Proyecto",
                principalColumn: "IdProyecto");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Entrada_Proyecto_IdProyecto",
                table: "Entrada");

            migrationBuilder.AlterColumn<int>(
                name: "IdProyecto",
                table: "Entrada",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "IdTipoEntrada",
                table: "Entrada",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Entrada_IdTipoEntrada",
                table: "Entrada",
                column: "IdTipoEntrada");

            migrationBuilder.AddForeignKey(
                name: "FK_Entrada_Proyecto_IdProyecto",
                table: "Entrada",
                column: "IdProyecto",
                principalTable: "Proyecto",
                principalColumn: "IdProyecto",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Entrada_TipoEntrada_IdTipoEntrada",
                table: "Entrada",
                column: "IdTipoEntrada",
                principalTable: "TipoEntrada",
                principalColumn: "IdTipoEntrada",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
