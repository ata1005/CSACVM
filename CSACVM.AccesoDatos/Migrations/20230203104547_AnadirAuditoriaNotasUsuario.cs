using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CSACVM.AccesoDatos.Migrations
{
    public partial class AnadirAuditoriaNotasUsuario : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "FechaActualizacion",
                table: "NotasUsuario",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "FechaCreacion",
                table: "NotasUsuario",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ProcesoActualizacion",
                table: "NotasUsuario",
                type: "nvarchar(255)",
                maxLength: 255,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ProcesoCreacion",
                table: "NotasUsuario",
                type: "nvarchar(255)",
                maxLength: 255,
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "UsuarioActualizacion",
                table: "NotasUsuario",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "UsuarioCreacion",
                table: "NotasUsuario",
                type: "int",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FechaActualizacion",
                table: "NotasUsuario");

            migrationBuilder.DropColumn(
                name: "FechaCreacion",
                table: "NotasUsuario");

            migrationBuilder.DropColumn(
                name: "ProcesoActualizacion",
                table: "NotasUsuario");

            migrationBuilder.DropColumn(
                name: "ProcesoCreacion",
                table: "NotasUsuario");

            migrationBuilder.DropColumn(
                name: "UsuarioActualizacion",
                table: "NotasUsuario");

            migrationBuilder.DropColumn(
                name: "UsuarioCreacion",
                table: "NotasUsuario");
        }
    }
}
