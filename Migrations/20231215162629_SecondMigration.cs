using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BibliotecaAPI.Migrations
{
    /// <inheritdoc />
    public partial class SecondMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Categoria",
                table: "Livros");

            migrationBuilder.AddColumn<int>(
                name: "Codigo",
                table: "Livros",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "FotoPath",
                table: "Livros",
                type: "text",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Codigo",
                table: "Livros");

            migrationBuilder.DropColumn(
                name: "FotoPath",
                table: "Livros");

            migrationBuilder.AddColumn<string>(
                name: "Categoria",
                table: "Livros",
                type: "text",
                nullable: false,
                defaultValue: "");
        }
    }
}
