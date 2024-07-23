using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Projeto_Elite.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddAtualizacaoContadorDownload : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ContadorDownload",
                table: "Arquivo");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ContadorDownload",
                table: "Arquivo",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
