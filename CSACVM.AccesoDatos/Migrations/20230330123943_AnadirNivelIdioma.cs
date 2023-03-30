using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CSACVM.AccesoDatos.Migrations
{
    public partial class AnadirNivelIdioma : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "FechaHasta",
                table: "IdiomaCV",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<DateTime>(
                name: "FechaDesde",
                table: "IdiomaCV",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AddColumn<int>(
                name: "IdNivelIdioma",
                table: "IdiomaCV",
                type: "int",
                nullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "FechaHasta",
                table: "FormacionCV",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<DateTime>(
                name: "FechaDesde",
                table: "FormacionCV",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.CreateTable(
                name: "NivelIdioma",
                columns: table => new
                {
                    idNivelIdioma = table.Column<int>(type: "int", nullable: false)
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
                    table.PrimaryKey("PK_NivelIdioma", x => x.idNivelIdioma);
                });

            migrationBuilder.CreateIndex(
                name: "IX_IdiomaCV_IdNivelIdioma",
                table: "IdiomaCV",
                column: "IdNivelIdioma");

            migrationBuilder.AddForeignKey(
                name: "FK_IdiomaCV_NivelIdioma_IdNivelIdioma",
                table: "IdiomaCV",
                column: "IdNivelIdioma",
                principalTable: "NivelIdioma",
                principalColumn: "idNivelIdioma");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_IdiomaCV_NivelIdioma_IdNivelIdioma",
                table: "IdiomaCV");

            migrationBuilder.DropTable(
                name: "NivelIdioma");

            migrationBuilder.DropIndex(
                name: "IX_IdiomaCV_IdNivelIdioma",
                table: "IdiomaCV");

            migrationBuilder.DropColumn(
                name: "IdNivelIdioma",
                table: "IdiomaCV");

            migrationBuilder.AlterColumn<DateTime>(
                name: "FechaHasta",
                table: "IdiomaCV",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "FechaDesde",
                table: "IdiomaCV",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "FechaHasta",
                table: "FormacionCV",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "FechaDesde",
                table: "FormacionCV",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);
        }
    }
}
