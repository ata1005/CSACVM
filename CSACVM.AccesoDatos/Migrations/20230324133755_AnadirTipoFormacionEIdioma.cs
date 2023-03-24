using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CSACVM.AccesoDatos.Migrations
{
    public partial class AnadirTipoFormacionEIdioma : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "IdIdioma",
                table: "IdiomaCV",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "IdTipoFormacion",
                table: "FormacionCV",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "TipoFormacion",
                columns: table => new
                {
                    IdTipoFormacion = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descripcion = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    UsuarioCreacion = table.Column<int>(type: "int", nullable: true),
                    FechaCreacion = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ProcesoCreacion = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    UsuarioActualizacion = table.Column<int>(type: "int", nullable: true),
                    FechaActualizacion = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ProcesoActualizacion = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipoFormacion", x => x.IdTipoFormacion);
                });

            migrationBuilder.CreateIndex(
                name: "IX_IdiomaCV_IdIdioma",
                table: "IdiomaCV",
                column: "IdIdioma");

            migrationBuilder.CreateIndex(
                name: "IX_FormacionCV_IdTipoFormacion",
                table: "FormacionCV",
                column: "IdTipoFormacion");

            migrationBuilder.AddForeignKey(
                name: "FK_FormacionCV_TipoFormacion_IdTipoFormacion",
                table: "FormacionCV",
                column: "IdTipoFormacion",
                principalTable: "TipoFormacion",
                principalColumn: "IdTipoFormacion");

            migrationBuilder.AddForeignKey(
                name: "FK_IdiomaCV_Idioma_IdIdioma",
                table: "IdiomaCV",
                column: "IdIdioma",
                principalTable: "Idioma",
                principalColumn: "IdIdioma");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FormacionCV_TipoFormacion_IdTipoFormacion",
                table: "FormacionCV");

            migrationBuilder.DropForeignKey(
                name: "FK_IdiomaCV_Idioma_IdIdioma",
                table: "IdiomaCV");

            migrationBuilder.DropTable(
                name: "TipoFormacion");

            migrationBuilder.DropIndex(
                name: "IX_IdiomaCV_IdIdioma",
                table: "IdiomaCV");

            migrationBuilder.DropIndex(
                name: "IX_FormacionCV_IdTipoFormacion",
                table: "FormacionCV");

            migrationBuilder.DropColumn(
                name: "IdIdioma",
                table: "IdiomaCV");

            migrationBuilder.DropColumn(
                name: "IdTipoFormacion",
                table: "FormacionCV");
        }
    }
}
