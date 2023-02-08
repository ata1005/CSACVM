using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CSACVM.AccesoDatos.Migrations
{
    public partial class AnadirTablaCurriculum : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "IdCurriculum",
                table: "UsuarioCV",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "IdCurriculum",
                table: "IdiomaCV",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "IdCurriculum",
                table: "FotoUsuarioCV",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "IdCurriculum",
                table: "FormacionCV",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "IdCurriculum",
                table: "ExtraEntradasCV",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "IdCurriculum",
                table: "EntradaCV",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Curriculum",
                columns: table => new
                {
                    IdCurriculum = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdUsuario = table.Column<int>(type: "int", nullable: false),
                    FechaCurriculum = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UsuarioCreacion = table.Column<int>(type: "int", nullable: true),
                    FechaCreacion = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ProcesoCreacion = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    UsuarioActualizacion = table.Column<int>(type: "int", nullable: true),
                    FechaActualizacion = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ProcesoActualizacion = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Curriculum", x => x.IdCurriculum);
                });

            migrationBuilder.CreateIndex(
                name: "IX_UsuarioCV_IdCurriculum",
                table: "UsuarioCV",
                column: "IdCurriculum");

            migrationBuilder.CreateIndex(
                name: "IX_IdiomaCV_IdCurriculum",
                table: "IdiomaCV",
                column: "IdCurriculum");

            migrationBuilder.CreateIndex(
                name: "IX_FotoUsuarioCV_IdCurriculum",
                table: "FotoUsuarioCV",
                column: "IdCurriculum");

            migrationBuilder.CreateIndex(
                name: "IX_FormacionCV_IdCurriculum",
                table: "FormacionCV",
                column: "IdCurriculum");

            migrationBuilder.CreateIndex(
                name: "IX_ExtraEntradasCV_IdCurriculum",
                table: "ExtraEntradasCV",
                column: "IdCurriculum");

            migrationBuilder.CreateIndex(
                name: "IX_EntradaCV_IdCurriculum",
                table: "EntradaCV",
                column: "IdCurriculum");

            migrationBuilder.AddForeignKey(
                name: "FK_EntradaCV_Curriculum_IdCurriculum",
                table: "EntradaCV",
                column: "IdCurriculum",
                principalTable: "Curriculum",
                principalColumn: "IdCurriculum");

            migrationBuilder.AddForeignKey(
                name: "FK_ExtraEntradasCV_Curriculum_IdCurriculum",
                table: "ExtraEntradasCV",
                column: "IdCurriculum",
                principalTable: "Curriculum",
                principalColumn: "IdCurriculum");

            migrationBuilder.AddForeignKey(
                name: "FK_FormacionCV_Curriculum_IdCurriculum",
                table: "FormacionCV",
                column: "IdCurriculum",
                principalTable: "Curriculum",
                principalColumn: "IdCurriculum");

            migrationBuilder.AddForeignKey(
                name: "FK_FotoUsuarioCV_Curriculum_IdCurriculum",
                table: "FotoUsuarioCV",
                column: "IdCurriculum",
                principalTable: "Curriculum",
                principalColumn: "IdCurriculum");

            migrationBuilder.AddForeignKey(
                name: "FK_IdiomaCV_Curriculum_IdCurriculum",
                table: "IdiomaCV",
                column: "IdCurriculum",
                principalTable: "Curriculum",
                principalColumn: "IdCurriculum");

            migrationBuilder.AddForeignKey(
                name: "FK_UsuarioCV_Curriculum_IdCurriculum",
                table: "UsuarioCV",
                column: "IdCurriculum",
                principalTable: "Curriculum",
                principalColumn: "IdCurriculum");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EntradaCV_Curriculum_IdCurriculum",
                table: "EntradaCV");

            migrationBuilder.DropForeignKey(
                name: "FK_ExtraEntradasCV_Curriculum_IdCurriculum",
                table: "ExtraEntradasCV");

            migrationBuilder.DropForeignKey(
                name: "FK_FormacionCV_Curriculum_IdCurriculum",
                table: "FormacionCV");

            migrationBuilder.DropForeignKey(
                name: "FK_FotoUsuarioCV_Curriculum_IdCurriculum",
                table: "FotoUsuarioCV");

            migrationBuilder.DropForeignKey(
                name: "FK_IdiomaCV_Curriculum_IdCurriculum",
                table: "IdiomaCV");

            migrationBuilder.DropForeignKey(
                name: "FK_UsuarioCV_Curriculum_IdCurriculum",
                table: "UsuarioCV");

            migrationBuilder.DropTable(
                name: "Curriculum");

            migrationBuilder.DropIndex(
                name: "IX_UsuarioCV_IdCurriculum",
                table: "UsuarioCV");

            migrationBuilder.DropIndex(
                name: "IX_IdiomaCV_IdCurriculum",
                table: "IdiomaCV");

            migrationBuilder.DropIndex(
                name: "IX_FotoUsuarioCV_IdCurriculum",
                table: "FotoUsuarioCV");

            migrationBuilder.DropIndex(
                name: "IX_FormacionCV_IdCurriculum",
                table: "FormacionCV");

            migrationBuilder.DropIndex(
                name: "IX_ExtraEntradasCV_IdCurriculum",
                table: "ExtraEntradasCV");

            migrationBuilder.DropIndex(
                name: "IX_EntradaCV_IdCurriculum",
                table: "EntradaCV");

            migrationBuilder.DropColumn(
                name: "IdCurriculum",
                table: "UsuarioCV");

            migrationBuilder.DropColumn(
                name: "IdCurriculum",
                table: "IdiomaCV");

            migrationBuilder.DropColumn(
                name: "IdCurriculum",
                table: "FotoUsuarioCV");

            migrationBuilder.DropColumn(
                name: "IdCurriculum",
                table: "FormacionCV");

            migrationBuilder.DropColumn(
                name: "IdCurriculum",
                table: "ExtraEntradasCV");

            migrationBuilder.DropColumn(
                name: "IdCurriculum",
                table: "EntradaCV");
        }
    }
}
