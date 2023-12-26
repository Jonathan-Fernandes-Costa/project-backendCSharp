using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BibliotecaAPI.Migrations
{
    /// <inheritdoc />
    public partial class _8Migration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Livros_LivroCategorias_livro_categoria_id1",
                table: "Livros");

            migrationBuilder.DropIndex(
                name: "IX_Livros_livro_categoria_id1",
                table: "Livros");

            migrationBuilder.AddColumn<int>(
                name: "LivroCategoriaModelId",
                table: "Livros",
                type: "integer",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Livros_livro_categoria_id",
                table: "Livros",
                column: "livro_categoria_id");

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Livros_LivroCategorias_LivroCategoriaModelId",
                table: "Livros");

            migrationBuilder.DropForeignKey(
                name: "FK_Livros_LivroCategorias_livro_categoria_id",
                table: "Livros");

            migrationBuilder.DropIndex(
                name: "IX_Livros_livro_categoria_id",
                table: "Livros");

            migrationBuilder.DropIndex(
                name: "IX_Livros_LivroCategoriaModelId",
                table: "Livros");

            migrationBuilder.DropColumn(
                name: "LivroCategoriaModelId",
                table: "Livros");

            migrationBuilder.CreateIndex(
                name: "IX_Livros_livro_categoria_id1",
                table: "Livros",
                column: "livro_categoria_id1");

            migrationBuilder.AddForeignKey(
                name: "FK_Livros_LivroCategorias_livro_categoria_id1",
                table: "Livros",
                column: "livro_categoria_id1",
                principalTable: "LivroCategorias",
                principalColumn: "id");
        }
    }
}
