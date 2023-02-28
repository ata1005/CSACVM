using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CSACVM.AccesoDatos.Migrations
{
    public partial class AnadirForeignKeysCV : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FotoUsuarioCV_Usuario_IdUsuario",
                table: "FotoUsuarioCV");

            migrationBuilder.DropForeignKey(
                name: "FK_UsuarioCV_FotoUsuarioCV_IdFotoUsuarioCV",
                table: "UsuarioCV");

            migrationBuilder.AlterColumn<int>(
                name: "Telefono",
                table: "UsuarioCV",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "IdFotoUsuarioCV",
                table: "UsuarioCV",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "Foto",
                table: "Usuario",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(byte[]),
                oldType: "varbinary(max)",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_FotoUsuarioCV_UsuarioCV_IdUsuario",
                table: "FotoUsuarioCV",
                column: "IdUsuario",
                principalTable: "UsuarioCV",
                principalColumn: "IdUsuarioCV",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UsuarioCV_FotoUsuarioCV_IdFotoUsuarioCV",
                table: "UsuarioCV",
                column: "IdFotoUsuarioCV",
                principalTable: "FotoUsuarioCV",
                principalColumn: "IdFotoUsuarioCV");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FotoUsuarioCV_UsuarioCV_IdUsuario",
                table: "FotoUsuarioCV");

            migrationBuilder.DropForeignKey(
                name: "FK_UsuarioCV_FotoUsuarioCV_IdFotoUsuarioCV",
                table: "UsuarioCV");

            migrationBuilder.AlterColumn<int>(
                name: "Telefono",
                table: "UsuarioCV",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "IdFotoUsuarioCV",
                table: "UsuarioCV",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<byte[]>(
                name: "Foto",
                table: "Usuario",
                type: "varbinary(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_FotoUsuarioCV_Usuario_IdUsuario",
                table: "FotoUsuarioCV",
                column: "IdUsuario",
                principalTable: "Usuario",
                principalColumn: "IdUsuario",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UsuarioCV_FotoUsuarioCV_IdFotoUsuarioCV",
                table: "UsuarioCV",
                column: "IdFotoUsuarioCV",
                principalTable: "FotoUsuarioCV",
                principalColumn: "IdFotoUsuarioCV",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
