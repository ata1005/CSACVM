using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CSACVM.AccesoDatos.Migrations
{
    public partial class AnadirFotoUsuarioCV : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Foto",
                table: "UsuarioCV");

            migrationBuilder.AddColumn<DateTime>(
                name: "FechaNacimiento",
                table: "UsuarioCV",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "IdFotoUsuarioCV",
                table: "UsuarioCV",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<string>(
                name: "Titulo",
                table: "NotasUsuario",
                type: "nvarchar(40)",
                maxLength: 40,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(20)",
                oldMaxLength: 20);

            migrationBuilder.CreateTable(
                name: "FotoUsuarioCV",
                columns: table => new
                {
                    IdFotoUsuarioCV = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdUsuarioCV = table.Column<int>(type: "int", nullable: false),
                    IdUsuario = table.Column<int>(type: "int", nullable: false),
                    Foto = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    Ruta = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Guid = table.Column<string>(type: "nvarchar(32)", maxLength: 32, nullable: true),
                    UsuarioCreacion = table.Column<int>(type: "int", nullable: true),
                    FechaCreacion = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ProcesoCreacion = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    UsuarioActualizacion = table.Column<int>(type: "int", nullable: true),
                    FechaActualizacion = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ProcesoActualizacion = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FotoUsuarioCV", x => x.IdFotoUsuarioCV);
                    table.ForeignKey(
                        name: "FK_FotoUsuarioCV_Usuario_IdUsuario",
                        column: x => x.IdUsuario,
                        principalTable: "Usuario",
                        principalColumn: "IdUsuario",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_UsuarioCV_IdFotoUsuarioCV",
                table: "UsuarioCV",
                column: "IdFotoUsuarioCV");

            migrationBuilder.CreateIndex(
                name: "IX_FotoUsuarioCV_IdUsuario",
                table: "FotoUsuarioCV",
                column: "IdUsuario");

            migrationBuilder.AddForeignKey(
                name: "FK_UsuarioCV_FotoUsuarioCV_IdFotoUsuarioCV",
                table: "UsuarioCV",
                column: "IdFotoUsuarioCV",
                principalTable: "FotoUsuarioCV",
                principalColumn: "IdFotoUsuarioCV",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UsuarioCV_FotoUsuarioCV_IdFotoUsuarioCV",
                table: "UsuarioCV");

            migrationBuilder.DropTable(
                name: "FotoUsuarioCV");

            migrationBuilder.DropIndex(
                name: "IX_UsuarioCV_IdFotoUsuarioCV",
                table: "UsuarioCV");

            migrationBuilder.DropColumn(
                name: "FechaNacimiento",
                table: "UsuarioCV");

            migrationBuilder.DropColumn(
                name: "IdFotoUsuarioCV",
                table: "UsuarioCV");

            migrationBuilder.AddColumn<byte[]>(
                name: "Foto",
                table: "UsuarioCV",
                type: "varbinary(max)",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Titulo",
                table: "NotasUsuario",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(40)",
                oldMaxLength: 40);
        }
    }
}
