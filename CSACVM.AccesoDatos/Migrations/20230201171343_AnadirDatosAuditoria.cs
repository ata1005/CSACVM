using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CSACVM.AccesoDatos.Migrations
{
    public partial class AnadirDatosAuditoria : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FechaCreacion",
                table: "NotasUsuario");

            migrationBuilder.AddColumn<DateTime>(
                name: "FechaActualizacion",
                table: "UsuarioCV",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "FechaCreacion",
                table: "UsuarioCV",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ProcesoActualizacion",
                table: "UsuarioCV",
                type: "nvarchar(255)",
                maxLength: 255,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ProcesoCreacion",
                table: "UsuarioCV",
                type: "nvarchar(255)",
                maxLength: 255,
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "UsuarioActualizacion",
                table: "UsuarioCV",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "UsuarioCreacion",
                table: "UsuarioCV",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "FechaActualizacion",
                table: "Usuario",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "FechaCreacion",
                table: "Usuario",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ProcesoActualizacion",
                table: "Usuario",
                type: "nvarchar(255)",
                maxLength: 255,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ProcesoCreacion",
                table: "Usuario",
                type: "nvarchar(255)",
                maxLength: 255,
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "UsuarioActualizacion",
                table: "Usuario",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "UsuarioCreacion",
                table: "Usuario",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "FechaActualizacion",
                table: "TipoNotificacion",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "FechaCreacion",
                table: "TipoNotificacion",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ProcesoActualizacion",
                table: "TipoNotificacion",
                type: "nvarchar(255)",
                maxLength: 255,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ProcesoCreacion",
                table: "TipoNotificacion",
                type: "nvarchar(255)",
                maxLength: 255,
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "UsuarioActualizacion",
                table: "TipoNotificacion",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "UsuarioCreacion",
                table: "TipoNotificacion",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "FechaActualizacion",
                table: "TipoExtraCV",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "FechaCreacion",
                table: "TipoExtraCV",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ProcesoActualizacion",
                table: "TipoExtraCV",
                type: "nvarchar(255)",
                maxLength: 255,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ProcesoCreacion",
                table: "TipoExtraCV",
                type: "nvarchar(255)",
                maxLength: 255,
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "UsuarioActualizacion",
                table: "TipoExtraCV",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "UsuarioCreacion",
                table: "TipoExtraCV",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "FechaActualizacion",
                table: "TipoEntrada",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "FechaCreacion",
                table: "TipoEntrada",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ProcesoActualizacion",
                table: "TipoEntrada",
                type: "nvarchar(255)",
                maxLength: 255,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ProcesoCreacion",
                table: "TipoEntrada",
                type: "nvarchar(255)",
                maxLength: 255,
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "UsuarioActualizacion",
                table: "TipoEntrada",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "UsuarioCreacion",
                table: "TipoEntrada",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "FechaActualizacion",
                table: "Rol",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "FechaCreacion",
                table: "Rol",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ProcesoActualizacion",
                table: "Rol",
                type: "nvarchar(255)",
                maxLength: 255,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ProcesoCreacion",
                table: "Rol",
                type: "nvarchar(255)",
                maxLength: 255,
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "UsuarioActualizacion",
                table: "Rol",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "UsuarioCreacion",
                table: "Rol",
                type: "int",
                nullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "FechaCreacion",
                table: "Respuesta",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AddColumn<DateTime>(
                name: "FechaActualizacion",
                table: "Respuesta",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ProcesoActualizacion",
                table: "Respuesta",
                type: "nvarchar(255)",
                maxLength: 255,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ProcesoCreacion",
                table: "Respuesta",
                type: "nvarchar(255)",
                maxLength: 255,
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "UsuarioActualizacion",
                table: "Respuesta",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "UsuarioCreacion",
                table: "Respuesta",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "FechaActualizacion",
                table: "Proyecto",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "FechaCreacion",
                table: "Proyecto",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ProcesoActualizacion",
                table: "Proyecto",
                type: "nvarchar(255)",
                maxLength: 255,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ProcesoCreacion",
                table: "Proyecto",
                type: "nvarchar(255)",
                maxLength: 255,
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "UsuarioActualizacion",
                table: "Proyecto",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "UsuarioCreacion",
                table: "Proyecto",
                type: "int",
                nullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "FechaCreacion",
                table: "Notificacion",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AddColumn<DateTime>(
                name: "FechaActualizacion",
                table: "Notificacion",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ProcesoActualizacion",
                table: "Notificacion",
                type: "nvarchar(255)",
                maxLength: 255,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ProcesoCreacion",
                table: "Notificacion",
                type: "nvarchar(255)",
                maxLength: 255,
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "UsuarioActualizacion",
                table: "Notificacion",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "UsuarioCreacion",
                table: "Notificacion",
                type: "int",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Descripcion",
                table: "NotasUsuario",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50);

            migrationBuilder.AddColumn<string>(
                name: "Titulo",
                table: "NotasUsuario",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "FechaActualizacion",
                table: "IdiomaCV",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "FechaCreacion",
                table: "IdiomaCV",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ProcesoActualizacion",
                table: "IdiomaCV",
                type: "nvarchar(255)",
                maxLength: 255,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ProcesoCreacion",
                table: "IdiomaCV",
                type: "nvarchar(255)",
                maxLength: 255,
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "UsuarioActualizacion",
                table: "IdiomaCV",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "UsuarioCreacion",
                table: "IdiomaCV",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "FechaActualizacion",
                table: "Idioma",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "FechaCreacion",
                table: "Idioma",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ProcesoActualizacion",
                table: "Idioma",
                type: "nvarchar(255)",
                maxLength: 255,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ProcesoCreacion",
                table: "Idioma",
                type: "nvarchar(255)",
                maxLength: 255,
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "UsuarioActualizacion",
                table: "Idioma",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "UsuarioCreacion",
                table: "Idioma",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "FechaActualizacion",
                table: "Grupo",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "FechaCreacion",
                table: "Grupo",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ProcesoActualizacion",
                table: "Grupo",
                type: "nvarchar(255)",
                maxLength: 255,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ProcesoCreacion",
                table: "Grupo",
                type: "nvarchar(255)",
                maxLength: 255,
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "UsuarioActualizacion",
                table: "Grupo",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "UsuarioCreacion",
                table: "Grupo",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "FechaActualizacion",
                table: "FormacionCV",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "FechaCreacion",
                table: "FormacionCV",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ProcesoActualizacion",
                table: "FormacionCV",
                type: "nvarchar(255)",
                maxLength: 255,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ProcesoCreacion",
                table: "FormacionCV",
                type: "nvarchar(255)",
                maxLength: 255,
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "UsuarioActualizacion",
                table: "FormacionCV",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "UsuarioCreacion",
                table: "FormacionCV",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "FechaActualizacion",
                table: "ExtraEntradasCV",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "FechaCreacion",
                table: "ExtraEntradasCV",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ProcesoActualizacion",
                table: "ExtraEntradasCV",
                type: "nvarchar(255)",
                maxLength: 255,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ProcesoCreacion",
                table: "ExtraEntradasCV",
                type: "nvarchar(255)",
                maxLength: 255,
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "UsuarioActualizacion",
                table: "ExtraEntradasCV",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "UsuarioCreacion",
                table: "ExtraEntradasCV",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "FechaActualizacion",
                table: "ExtraCV",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "FechaCreacion",
                table: "ExtraCV",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ProcesoActualizacion",
                table: "ExtraCV",
                type: "nvarchar(255)",
                maxLength: 255,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ProcesoCreacion",
                table: "ExtraCV",
                type: "nvarchar(255)",
                maxLength: 255,
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "UsuarioActualizacion",
                table: "ExtraCV",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "UsuarioCreacion",
                table: "ExtraCV",
                type: "int",
                nullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "FechaCreacion",
                table: "EventosUsuario",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AddColumn<DateTime>(
                name: "FechaActualizacion",
                table: "EventosUsuario",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ProcesoActualizacion",
                table: "EventosUsuario",
                type: "nvarchar(255)",
                maxLength: 255,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ProcesoCreacion",
                table: "EventosUsuario",
                type: "nvarchar(255)",
                maxLength: 255,
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "UsuarioActualizacion",
                table: "EventosUsuario",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "UsuarioCreacion",
                table: "EventosUsuario",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "FechaActualizacion",
                table: "EntradaCV",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "FechaCreacion",
                table: "EntradaCV",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ProcesoActualizacion",
                table: "EntradaCV",
                type: "nvarchar(255)",
                maxLength: 255,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ProcesoCreacion",
                table: "EntradaCV",
                type: "nvarchar(255)",
                maxLength: 255,
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "UsuarioActualizacion",
                table: "EntradaCV",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "UsuarioCreacion",
                table: "EntradaCV",
                type: "int",
                nullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "FechaCreacion",
                table: "Entrada",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AddColumn<DateTime>(
                name: "FechaActualizacion",
                table: "Entrada",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ProcesoActualizacion",
                table: "Entrada",
                type: "nvarchar(255)",
                maxLength: 255,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ProcesoCreacion",
                table: "Entrada",
                type: "nvarchar(255)",
                maxLength: 255,
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "UsuarioActualizacion",
                table: "Entrada",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "UsuarioCreacion",
                table: "Entrada",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "FechaActualizacion",
                table: "Departamento",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "FechaCreacion",
                table: "Departamento",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ProcesoActualizacion",
                table: "Departamento",
                type: "nvarchar(255)",
                maxLength: 255,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ProcesoCreacion",
                table: "Departamento",
                type: "nvarchar(255)",
                maxLength: 255,
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "UsuarioActualizacion",
                table: "Departamento",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "UsuarioCreacion",
                table: "Departamento",
                type: "int",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FechaActualizacion",
                table: "UsuarioCV");

            migrationBuilder.DropColumn(
                name: "FechaCreacion",
                table: "UsuarioCV");

            migrationBuilder.DropColumn(
                name: "ProcesoActualizacion",
                table: "UsuarioCV");

            migrationBuilder.DropColumn(
                name: "ProcesoCreacion",
                table: "UsuarioCV");

            migrationBuilder.DropColumn(
                name: "UsuarioActualizacion",
                table: "UsuarioCV");

            migrationBuilder.DropColumn(
                name: "UsuarioCreacion",
                table: "UsuarioCV");

            migrationBuilder.DropColumn(
                name: "FechaActualizacion",
                table: "Usuario");

            migrationBuilder.DropColumn(
                name: "FechaCreacion",
                table: "Usuario");

            migrationBuilder.DropColumn(
                name: "ProcesoActualizacion",
                table: "Usuario");

            migrationBuilder.DropColumn(
                name: "ProcesoCreacion",
                table: "Usuario");

            migrationBuilder.DropColumn(
                name: "UsuarioActualizacion",
                table: "Usuario");

            migrationBuilder.DropColumn(
                name: "UsuarioCreacion",
                table: "Usuario");

            migrationBuilder.DropColumn(
                name: "FechaActualizacion",
                table: "TipoNotificacion");

            migrationBuilder.DropColumn(
                name: "FechaCreacion",
                table: "TipoNotificacion");

            migrationBuilder.DropColumn(
                name: "ProcesoActualizacion",
                table: "TipoNotificacion");

            migrationBuilder.DropColumn(
                name: "ProcesoCreacion",
                table: "TipoNotificacion");

            migrationBuilder.DropColumn(
                name: "UsuarioActualizacion",
                table: "TipoNotificacion");

            migrationBuilder.DropColumn(
                name: "UsuarioCreacion",
                table: "TipoNotificacion");

            migrationBuilder.DropColumn(
                name: "FechaActualizacion",
                table: "TipoExtraCV");

            migrationBuilder.DropColumn(
                name: "FechaCreacion",
                table: "TipoExtraCV");

            migrationBuilder.DropColumn(
                name: "ProcesoActualizacion",
                table: "TipoExtraCV");

            migrationBuilder.DropColumn(
                name: "ProcesoCreacion",
                table: "TipoExtraCV");

            migrationBuilder.DropColumn(
                name: "UsuarioActualizacion",
                table: "TipoExtraCV");

            migrationBuilder.DropColumn(
                name: "UsuarioCreacion",
                table: "TipoExtraCV");

            migrationBuilder.DropColumn(
                name: "FechaActualizacion",
                table: "TipoEntrada");

            migrationBuilder.DropColumn(
                name: "FechaCreacion",
                table: "TipoEntrada");

            migrationBuilder.DropColumn(
                name: "ProcesoActualizacion",
                table: "TipoEntrada");

            migrationBuilder.DropColumn(
                name: "ProcesoCreacion",
                table: "TipoEntrada");

            migrationBuilder.DropColumn(
                name: "UsuarioActualizacion",
                table: "TipoEntrada");

            migrationBuilder.DropColumn(
                name: "UsuarioCreacion",
                table: "TipoEntrada");

            migrationBuilder.DropColumn(
                name: "FechaActualizacion",
                table: "Rol");

            migrationBuilder.DropColumn(
                name: "FechaCreacion",
                table: "Rol");

            migrationBuilder.DropColumn(
                name: "ProcesoActualizacion",
                table: "Rol");

            migrationBuilder.DropColumn(
                name: "ProcesoCreacion",
                table: "Rol");

            migrationBuilder.DropColumn(
                name: "UsuarioActualizacion",
                table: "Rol");

            migrationBuilder.DropColumn(
                name: "UsuarioCreacion",
                table: "Rol");

            migrationBuilder.DropColumn(
                name: "FechaActualizacion",
                table: "Respuesta");

            migrationBuilder.DropColumn(
                name: "ProcesoActualizacion",
                table: "Respuesta");

            migrationBuilder.DropColumn(
                name: "ProcesoCreacion",
                table: "Respuesta");

            migrationBuilder.DropColumn(
                name: "UsuarioActualizacion",
                table: "Respuesta");

            migrationBuilder.DropColumn(
                name: "UsuarioCreacion",
                table: "Respuesta");

            migrationBuilder.DropColumn(
                name: "FechaActualizacion",
                table: "Proyecto");

            migrationBuilder.DropColumn(
                name: "FechaCreacion",
                table: "Proyecto");

            migrationBuilder.DropColumn(
                name: "ProcesoActualizacion",
                table: "Proyecto");

            migrationBuilder.DropColumn(
                name: "ProcesoCreacion",
                table: "Proyecto");

            migrationBuilder.DropColumn(
                name: "UsuarioActualizacion",
                table: "Proyecto");

            migrationBuilder.DropColumn(
                name: "UsuarioCreacion",
                table: "Proyecto");

            migrationBuilder.DropColumn(
                name: "FechaActualizacion",
                table: "Notificacion");

            migrationBuilder.DropColumn(
                name: "ProcesoActualizacion",
                table: "Notificacion");

            migrationBuilder.DropColumn(
                name: "ProcesoCreacion",
                table: "Notificacion");

            migrationBuilder.DropColumn(
                name: "UsuarioActualizacion",
                table: "Notificacion");

            migrationBuilder.DropColumn(
                name: "UsuarioCreacion",
                table: "Notificacion");

            migrationBuilder.DropColumn(
                name: "Titulo",
                table: "NotasUsuario");

            migrationBuilder.DropColumn(
                name: "FechaActualizacion",
                table: "IdiomaCV");

            migrationBuilder.DropColumn(
                name: "FechaCreacion",
                table: "IdiomaCV");

            migrationBuilder.DropColumn(
                name: "ProcesoActualizacion",
                table: "IdiomaCV");

            migrationBuilder.DropColumn(
                name: "ProcesoCreacion",
                table: "IdiomaCV");

            migrationBuilder.DropColumn(
                name: "UsuarioActualizacion",
                table: "IdiomaCV");

            migrationBuilder.DropColumn(
                name: "UsuarioCreacion",
                table: "IdiomaCV");

            migrationBuilder.DropColumn(
                name: "FechaActualizacion",
                table: "Idioma");

            migrationBuilder.DropColumn(
                name: "FechaCreacion",
                table: "Idioma");

            migrationBuilder.DropColumn(
                name: "ProcesoActualizacion",
                table: "Idioma");

            migrationBuilder.DropColumn(
                name: "ProcesoCreacion",
                table: "Idioma");

            migrationBuilder.DropColumn(
                name: "UsuarioActualizacion",
                table: "Idioma");

            migrationBuilder.DropColumn(
                name: "UsuarioCreacion",
                table: "Idioma");

            migrationBuilder.DropColumn(
                name: "FechaActualizacion",
                table: "Grupo");

            migrationBuilder.DropColumn(
                name: "FechaCreacion",
                table: "Grupo");

            migrationBuilder.DropColumn(
                name: "ProcesoActualizacion",
                table: "Grupo");

            migrationBuilder.DropColumn(
                name: "ProcesoCreacion",
                table: "Grupo");

            migrationBuilder.DropColumn(
                name: "UsuarioActualizacion",
                table: "Grupo");

            migrationBuilder.DropColumn(
                name: "UsuarioCreacion",
                table: "Grupo");

            migrationBuilder.DropColumn(
                name: "FechaActualizacion",
                table: "FormacionCV");

            migrationBuilder.DropColumn(
                name: "FechaCreacion",
                table: "FormacionCV");

            migrationBuilder.DropColumn(
                name: "ProcesoActualizacion",
                table: "FormacionCV");

            migrationBuilder.DropColumn(
                name: "ProcesoCreacion",
                table: "FormacionCV");

            migrationBuilder.DropColumn(
                name: "UsuarioActualizacion",
                table: "FormacionCV");

            migrationBuilder.DropColumn(
                name: "UsuarioCreacion",
                table: "FormacionCV");

            migrationBuilder.DropColumn(
                name: "FechaActualizacion",
                table: "ExtraEntradasCV");

            migrationBuilder.DropColumn(
                name: "FechaCreacion",
                table: "ExtraEntradasCV");

            migrationBuilder.DropColumn(
                name: "ProcesoActualizacion",
                table: "ExtraEntradasCV");

            migrationBuilder.DropColumn(
                name: "ProcesoCreacion",
                table: "ExtraEntradasCV");

            migrationBuilder.DropColumn(
                name: "UsuarioActualizacion",
                table: "ExtraEntradasCV");

            migrationBuilder.DropColumn(
                name: "UsuarioCreacion",
                table: "ExtraEntradasCV");

            migrationBuilder.DropColumn(
                name: "FechaActualizacion",
                table: "ExtraCV");

            migrationBuilder.DropColumn(
                name: "FechaCreacion",
                table: "ExtraCV");

            migrationBuilder.DropColumn(
                name: "ProcesoActualizacion",
                table: "ExtraCV");

            migrationBuilder.DropColumn(
                name: "ProcesoCreacion",
                table: "ExtraCV");

            migrationBuilder.DropColumn(
                name: "UsuarioActualizacion",
                table: "ExtraCV");

            migrationBuilder.DropColumn(
                name: "UsuarioCreacion",
                table: "ExtraCV");

            migrationBuilder.DropColumn(
                name: "FechaActualizacion",
                table: "EventosUsuario");

            migrationBuilder.DropColumn(
                name: "ProcesoActualizacion",
                table: "EventosUsuario");

            migrationBuilder.DropColumn(
                name: "ProcesoCreacion",
                table: "EventosUsuario");

            migrationBuilder.DropColumn(
                name: "UsuarioActualizacion",
                table: "EventosUsuario");

            migrationBuilder.DropColumn(
                name: "UsuarioCreacion",
                table: "EventosUsuario");

            migrationBuilder.DropColumn(
                name: "FechaActualizacion",
                table: "EntradaCV");

            migrationBuilder.DropColumn(
                name: "FechaCreacion",
                table: "EntradaCV");

            migrationBuilder.DropColumn(
                name: "ProcesoActualizacion",
                table: "EntradaCV");

            migrationBuilder.DropColumn(
                name: "ProcesoCreacion",
                table: "EntradaCV");

            migrationBuilder.DropColumn(
                name: "UsuarioActualizacion",
                table: "EntradaCV");

            migrationBuilder.DropColumn(
                name: "UsuarioCreacion",
                table: "EntradaCV");

            migrationBuilder.DropColumn(
                name: "FechaActualizacion",
                table: "Entrada");

            migrationBuilder.DropColumn(
                name: "ProcesoActualizacion",
                table: "Entrada");

            migrationBuilder.DropColumn(
                name: "ProcesoCreacion",
                table: "Entrada");

            migrationBuilder.DropColumn(
                name: "UsuarioActualizacion",
                table: "Entrada");

            migrationBuilder.DropColumn(
                name: "UsuarioCreacion",
                table: "Entrada");

            migrationBuilder.DropColumn(
                name: "FechaActualizacion",
                table: "Departamento");

            migrationBuilder.DropColumn(
                name: "FechaCreacion",
                table: "Departamento");

            migrationBuilder.DropColumn(
                name: "ProcesoActualizacion",
                table: "Departamento");

            migrationBuilder.DropColumn(
                name: "ProcesoCreacion",
                table: "Departamento");

            migrationBuilder.DropColumn(
                name: "UsuarioActualizacion",
                table: "Departamento");

            migrationBuilder.DropColumn(
                name: "UsuarioCreacion",
                table: "Departamento");

            migrationBuilder.AlterColumn<DateTime>(
                name: "FechaCreacion",
                table: "Respuesta",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "FechaCreacion",
                table: "Notificacion",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Descripcion",
                table: "NotasUsuario",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100,
                oldNullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "FechaCreacion",
                table: "NotasUsuario",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AlterColumn<DateTime>(
                name: "FechaCreacion",
                table: "EventosUsuario",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "FechaCreacion",
                table: "Entrada",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);
        }
    }
}
