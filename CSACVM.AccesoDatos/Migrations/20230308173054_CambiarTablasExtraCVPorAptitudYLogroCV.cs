using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CSACVM.AccesoDatos.Migrations
{
    public partial class CambiarTablasExtraCVPorAptitudYLogroCV : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ExtraEntradasCV");

            migrationBuilder.DropTable(
                name: "ExtraCV");

            migrationBuilder.DropTable(
                name: "TipoExtraCV");

            migrationBuilder.CreateTable(
                name: "AptitudCV",
                columns: table => new
                {
                    IdAptitudCV = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdUsuario = table.Column<int>(type: "int", nullable: false),
                    Descripcion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IdCurriculum = table.Column<int>(type: "int", nullable: true),
                    UsuarioCreacion = table.Column<int>(type: "int", nullable: true),
                    FechaCreacion = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ProcesoCreacion = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    UsuarioActualizacion = table.Column<int>(type: "int", nullable: true),
                    FechaActualizacion = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ProcesoActualizacion = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AptitudCV", x => x.IdAptitudCV);
                    table.ForeignKey(
                        name: "FK_AptitudCV_Curriculum_IdCurriculum",
                        column: x => x.IdCurriculum,
                        principalTable: "Curriculum",
                        principalColumn: "IdCurriculum");
                    table.ForeignKey(
                        name: "FK_AptitudCV_Usuario_IdUsuario",
                        column: x => x.IdUsuario,
                        principalTable: "Usuario",
                        principalColumn: "IdUsuario",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "LogroCV",
                columns: table => new
                {
                    IdLogroCV = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descripcion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IdCurriculum = table.Column<int>(type: "int", nullable: true),
                    UsuarioCreacion = table.Column<int>(type: "int", nullable: true),
                    FechaCreacion = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ProcesoCreacion = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    UsuarioActualizacion = table.Column<int>(type: "int", nullable: true),
                    FechaActualizacion = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ProcesoActualizacion = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LogroCV", x => x.IdLogroCV);
                    table.ForeignKey(
                        name: "FK_LogroCV_Curriculum_IdCurriculum",
                        column: x => x.IdCurriculum,
                        principalTable: "Curriculum",
                        principalColumn: "IdCurriculum");
                });

            migrationBuilder.CreateIndex(
                name: "IX_AptitudCV_IdCurriculum",
                table: "AptitudCV",
                column: "IdCurriculum");

            migrationBuilder.CreateIndex(
                name: "IX_AptitudCV_IdUsuario",
                table: "AptitudCV",
                column: "IdUsuario");

            migrationBuilder.CreateIndex(
                name: "IX_LogroCV_IdCurriculum",
                table: "LogroCV",
                column: "IdCurriculum");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AptitudCV");

            migrationBuilder.DropTable(
                name: "LogroCV");

            migrationBuilder.CreateTable(
                name: "TipoExtraCV",
                columns: table => new
                {
                    IdTipoExtraCV = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descripcion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FechaActualizacion = table.Column<DateTime>(type: "datetime2", nullable: true),
                    FechaCreacion = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ProcesoActualizacion = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    ProcesoCreacion = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    UsuarioActualizacion = table.Column<int>(type: "int", nullable: true),
                    UsuarioCreacion = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipoExtraCV", x => x.IdTipoExtraCV);
                });

            migrationBuilder.CreateTable(
                name: "ExtraCV",
                columns: table => new
                {
                    IdExtraCV = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdCurriculum = table.Column<int>(type: "int", nullable: true),
                    IdTipoExtraCV = table.Column<int>(type: "int", nullable: false),
                    IdUsuario = table.Column<int>(type: "int", nullable: false),
                    FechaActualizacion = table.Column<DateTime>(type: "datetime2", nullable: true),
                    FechaCreacion = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ProcesoActualizacion = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    ProcesoCreacion = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    UsuarioActualizacion = table.Column<int>(type: "int", nullable: true),
                    UsuarioCreacion = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExtraCV", x => x.IdExtraCV);
                    table.ForeignKey(
                        name: "FK_ExtraCV_Curriculum_IdCurriculum",
                        column: x => x.IdCurriculum,
                        principalTable: "Curriculum",
                        principalColumn: "IdCurriculum");
                    table.ForeignKey(
                        name: "FK_ExtraCV_TipoExtraCV_IdTipoExtraCV",
                        column: x => x.IdTipoExtraCV,
                        principalTable: "TipoExtraCV",
                        principalColumn: "IdTipoExtraCV",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ExtraCV_Usuario_IdUsuario",
                        column: x => x.IdUsuario,
                        principalTable: "Usuario",
                        principalColumn: "IdUsuario",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ExtraEntradasCV",
                columns: table => new
                {
                    IdExtraEntradaCV = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdExtraCV = table.Column<int>(type: "int", nullable: false),
                    Descripcion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FechaActualizacion = table.Column<DateTime>(type: "datetime2", nullable: true),
                    FechaCreacion = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ProcesoActualizacion = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    ProcesoCreacion = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    UsuarioActualizacion = table.Column<int>(type: "int", nullable: true),
                    UsuarioCreacion = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExtraEntradasCV", x => x.IdExtraEntradaCV);
                    table.ForeignKey(
                        name: "FK_ExtraEntradasCV_ExtraCV_IdExtraCV",
                        column: x => x.IdExtraCV,
                        principalTable: "ExtraCV",
                        principalColumn: "IdExtraCV",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ExtraCV_IdCurriculum",
                table: "ExtraCV",
                column: "IdCurriculum");

            migrationBuilder.CreateIndex(
                name: "IX_ExtraCV_IdTipoExtraCV",
                table: "ExtraCV",
                column: "IdTipoExtraCV");

            migrationBuilder.CreateIndex(
                name: "IX_ExtraCV_IdUsuario",
                table: "ExtraCV",
                column: "IdUsuario");

            migrationBuilder.CreateIndex(
                name: "IX_ExtraEntradasCV_IdExtraCV",
                table: "ExtraEntradasCV",
                column: "IdExtraCV");
        }
    }
}
