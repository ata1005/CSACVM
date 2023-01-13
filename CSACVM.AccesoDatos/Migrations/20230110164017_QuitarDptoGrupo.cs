using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CSACVM.AccesoDatos.Migrations
{
    public partial class QuitarDptoGrupo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Grupo_Departamento_DepartamentoIdDepartamento",
                table: "Grupo");

            migrationBuilder.DropIndex(
                name: "IX_Grupo_DepartamentoIdDepartamento",
                table: "Grupo");

            migrationBuilder.DropColumn(
                name: "DepartamentoIdDepartamento",
                table: "Grupo");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "DepartamentoIdDepartamento",
                table: "Grupo",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Grupo_DepartamentoIdDepartamento",
                table: "Grupo",
                column: "DepartamentoIdDepartamento");

            migrationBuilder.AddForeignKey(
                name: "FK_Grupo_Departamento_DepartamentoIdDepartamento",
                table: "Grupo",
                column: "DepartamentoIdDepartamento",
                principalTable: "Departamento",
                principalColumn: "IdDepartamento");
        }
    }
}
