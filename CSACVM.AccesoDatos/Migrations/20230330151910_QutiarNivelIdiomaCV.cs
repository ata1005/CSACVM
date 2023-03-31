using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CSACVM.AccesoDatos.Migrations
{
    public partial class QutiarNivelIdiomaCV : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Nivel",
                table: "IdiomaCV");

            migrationBuilder.AlterColumn<string>(
                name: "Centro",
                table: "IdiomaCV",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Centro",
                table: "IdiomaCV",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50);

            migrationBuilder.AddColumn<string>(
                name: "Nivel",
                table: "IdiomaCV",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");
        }
    }
}
