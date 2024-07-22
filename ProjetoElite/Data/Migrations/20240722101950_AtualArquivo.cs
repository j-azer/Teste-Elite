using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Projeto_Elite.Data.Migrations
{
    /// <inheritdoc />
    public partial class AtualArquivo : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "DataUpload",
                table: "Arquivo",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "PathArquivo",
                table: "Arquivo",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "PathThumbnail",
                table: "Arquivo",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DataUpload",
                table: "Arquivo");

            migrationBuilder.DropColumn(
                name: "PathArquivo",
                table: "Arquivo");

            migrationBuilder.DropColumn(
                name: "PathThumbnail",
                table: "Arquivo");
        }
    }
}
