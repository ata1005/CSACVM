using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CSACVM.AccesoDatos.Migrations
{
    public partial class CambiarForeignKeyCurriculumExtraCV : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ExtraEntradasCV_Curriculum_IdCurriculum",
                table: "ExtraEntradasCV");

            migrationBuilder.DropIndex(
                name: "IX_ExtraEntradasCV_IdCurriculum",
                table: "ExtraEntradasCV");

            migrationBuilder.DropColumn(
                name: "IdCurriculum",
                table: "ExtraEntradasCV");

            migrationBuilder.AddColumn<int>(
                name: "IdCurriculum",
                table: "ExtraCV",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_ExtraCV_IdCurriculum",
                table: "ExtraCV",
                column: "IdCurriculum");

            migrationBuilder.AddForeignKey(
                name: "FK_ExtraCV_Curriculum_IdCurriculum",
                table: "ExtraCV",
                column: "IdCurriculum",
                principalTable: "Curriculum",
                principalColumn: "IdCurriculum");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ExtraCV_Curriculum_IdCurriculum",
                table: "ExtraCV");

            migrationBuilder.DropIndex(
                name: "IX_ExtraCV_IdCurriculum",
                table: "ExtraCV");

            migrationBuilder.DropColumn(
                name: "IdCurriculum",
                table: "ExtraCV");

            migrationBuilder.AddColumn<int>(
                name: "IdCurriculum",
                table: "ExtraEntradasCV",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_ExtraEntradasCV_IdCurriculum",
                table: "ExtraEntradasCV",
                column: "IdCurriculum");

            migrationBuilder.AddForeignKey(
                name: "FK_ExtraEntradasCV_Curriculum_IdCurriculum",
                table: "ExtraEntradasCV",
                column: "IdCurriculum",
                principalTable: "Curriculum",
                principalColumn: "IdCurriculum");
        }
    }
}
