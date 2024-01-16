using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BibliotecaAPI.Migrations
{
    /// <inheritdoc />
    public partial class NewmodellivroCategorias : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ativo",
                table: "LivroCategorias");

            migrationBuilder.DropColumn(
                name: "data_cadastro",
                table: "LivroCategorias");

            migrationBuilder.DropColumn(
                name: "data_edicao",
                table: "LivroCategorias");

            migrationBuilder.DropColumn(
                name: "usuario_cadastro",
                table: "LivroCategorias");

            migrationBuilder.DropColumn(
                name: "usuario_edicao",
                table: "LivroCategorias");

            migrationBuilder.RenameColumn(
                name: "descricao",
                table: "LivroCategorias",
                newName: "nome");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "nome",
                table: "LivroCategorias",
                newName: "descricao");

            migrationBuilder.AddColumn<bool>(
                name: "ativo",
                table: "LivroCategorias",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "data_cadastro",
                table: "LivroCategorias",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "data_edicao",
                table: "LivroCategorias",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "usuario_cadastro",
                table: "LivroCategorias",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "usuario_edicao",
                table: "LivroCategorias",
                type: "text",
                nullable: true);
        }
    }
}
