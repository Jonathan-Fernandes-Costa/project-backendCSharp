using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BibliotecaAPI.Migrations
{
    /// <inheritdoc />
    public partial class _9Migration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Livros_LivroCategorias_LivroCategoriaModelId",
                table: "Livros");

            migrationBuilder.DropForeignKey(
                name: "FK_Livros_LivroCategorias_livro_categoria_id",
                table: "Livros");

            migrationBuilder.DropIndex(
                name: "IX_Livros_LivroCategoriaModelId",
                table: "Livros");

            migrationBuilder.DropColumn(
                name: "LivroCategoriaModelId",
                table: "Livros");

            migrationBuilder.DropColumn(
                name: "livro_categoria_id1",
                table: "Livros");

            migrationBuilder.RenameColumn(
                name: "livro_categoria_id",
                table: "Livros",
                newName: "id_livro_categoria");

            migrationBuilder.RenameIndex(
                name: "IX_Livros_livro_categoria_id",
                table: "Livros",
                newName: "IX_Livros_id_livro_categoria");

            migrationBuilder.AddForeignKey(
                name: "FK_Livros_LivroCategorias_id_livro_categoria",
                table: "Livros",
                column: "id_livro_categoria",
                principalTable: "LivroCategorias",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Livros_LivroCategorias_id_livro_categoria",
                table: "Livros");

            migrationBuilder.RenameColumn(
                name: "id_livro_categoria",
                table: "Livros",
                newName: "livro_categoria_id");

            migrationBuilder.RenameIndex(
                name: "IX_Livros_id_livro_categoria",
                table: "Livros",
                newName: "IX_Livros_livro_categoria_id");

            migrationBuilder.AddColumn<int>(
                name: "LivroCategoriaModelId",
                table: "Livros",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "livro_categoria_id1",
                table: "Livros",
                type: "integer",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Livros_LivroCategoriaModelId",
                table: "Livros",
                column: "LivroCategoriaModelId");

            migrationBuilder.AddForeignKey(
                name: "FK_Livros_LivroCategorias_LivroCategoriaModelId",
                table: "Livros",
                column: "LivroCategoriaModelId",
                principalTable: "LivroCategorias",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_Livros_LivroCategorias_livro_categoria_id",
                table: "Livros",
                column: "livro_categoria_id",
                principalTable: "LivroCategorias",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
