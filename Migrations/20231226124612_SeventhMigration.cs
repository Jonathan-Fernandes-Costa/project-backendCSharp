using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BibliotecaAPI.Migrations
{
    /// <inheritdoc />
    public partial class SeventhMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Livros_LivroCategoriaModel_livroCategoriaId",
                table: "Livros");

            migrationBuilder.DropIndex(
                name: "IX_Livros_livroCategoriaId",
                table: "Livros");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UsuarioModel",
                table: "UsuarioModel");

            migrationBuilder.DropPrimaryKey(
                name: "PK_LivroCategoriaModel",
                table: "LivroCategoriaModel");

            migrationBuilder.RenameTable(
                name: "UsuarioModel",
                newName: "Usuarios");

            migrationBuilder.RenameTable(
                name: "LivroCategoriaModel",
                newName: "LivroCategorias");

            migrationBuilder.RenameColumn(
                name: "Titulo",
                table: "Livros",
                newName: "titulo");

            migrationBuilder.RenameColumn(
                name: "Subtitulo",
                table: "Livros",
                newName: "subtitulo");

            migrationBuilder.RenameColumn(
                name: "Editora",
                table: "Livros",
                newName: "editora");

            migrationBuilder.RenameColumn(
                name: "Codigo",
                table: "Livros",
                newName: "codigo");

            migrationBuilder.RenameColumn(
                name: "Autor",
                table: "Livros",
                newName: "autor");

            migrationBuilder.RenameColumn(
                name: "livroCategoriaId",
                table: "Livros",
                newName: "livro_categoria_id");

            migrationBuilder.RenameColumn(
                name: "QtdReservas",
                table: "Livros",
                newName: "qtd_reservas");

            migrationBuilder.RenameColumn(
                name: "FotoPath",
                table: "Livros",
                newName: "foto_path");

            migrationBuilder.RenameColumn(
                name: "AnoEdicao",
                table: "Livros",
                newName: "ano_edicao");

            migrationBuilder.RenameColumn(
                name: "Password",
                table: "Usuarios",
                newName: "password");

            migrationBuilder.RenameColumn(
                name: "Nome",
                table: "Usuarios",
                newName: "nome");

            migrationBuilder.RenameColumn(
                name: "Email",
                table: "Usuarios",
                newName: "email");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Usuarios",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "Descricao",
                table: "LivroCategorias",
                newName: "descricao");

            migrationBuilder.RenameColumn(
                name: "Ativo",
                table: "LivroCategorias",
                newName: "ativo");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "LivroCategorias",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "UsuarioEdicao",
                table: "LivroCategorias",
                newName: "usuario_edicao");

            migrationBuilder.RenameColumn(
                name: "UsuarioCadastro",
                table: "LivroCategorias",
                newName: "usuario_cadastro");

            migrationBuilder.RenameColumn(
                name: "DataEdicao",
                table: "LivroCategorias",
                newName: "data_edicao");

            migrationBuilder.RenameColumn(
                name: "DataCadastro",
                table: "LivroCategorias",
                newName: "data_cadastro");

            migrationBuilder.AddColumn<int>(
                name: "livro_categoria_id1",
                table: "Livros",
                type: "integer",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Usuarios",
                table: "Usuarios",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_LivroCategorias",
                table: "LivroCategorias",
                column: "id");

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Livros_LivroCategorias_livro_categoria_id1",
                table: "Livros");

            migrationBuilder.DropIndex(
                name: "IX_Livros_livro_categoria_id1",
                table: "Livros");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Usuarios",
                table: "Usuarios");

            migrationBuilder.DropPrimaryKey(
                name: "PK_LivroCategorias",
                table: "LivroCategorias");

            migrationBuilder.DropColumn(
                name: "livro_categoria_id1",
                table: "Livros");

            migrationBuilder.RenameTable(
                name: "Usuarios",
                newName: "UsuarioModel");

            migrationBuilder.RenameTable(
                name: "LivroCategorias",
                newName: "LivroCategoriaModel");

            migrationBuilder.RenameColumn(
                name: "titulo",
                table: "Livros",
                newName: "Titulo");

            migrationBuilder.RenameColumn(
                name: "subtitulo",
                table: "Livros",
                newName: "Subtitulo");

            migrationBuilder.RenameColumn(
                name: "editora",
                table: "Livros",
                newName: "Editora");

            migrationBuilder.RenameColumn(
                name: "codigo",
                table: "Livros",
                newName: "Codigo");

            migrationBuilder.RenameColumn(
                name: "autor",
                table: "Livros",
                newName: "Autor");

            migrationBuilder.RenameColumn(
                name: "qtd_reservas",
                table: "Livros",
                newName: "QtdReservas");

            migrationBuilder.RenameColumn(
                name: "livro_categoria_id",
                table: "Livros",
                newName: "livroCategoriaId");

            migrationBuilder.RenameColumn(
                name: "foto_path",
                table: "Livros",
                newName: "FotoPath");

            migrationBuilder.RenameColumn(
                name: "ano_edicao",
                table: "Livros",
                newName: "AnoEdicao");

            migrationBuilder.RenameColumn(
                name: "password",
                table: "UsuarioModel",
                newName: "Password");

            migrationBuilder.RenameColumn(
                name: "nome",
                table: "UsuarioModel",
                newName: "Nome");

            migrationBuilder.RenameColumn(
                name: "email",
                table: "UsuarioModel",
                newName: "Email");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "UsuarioModel",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "descricao",
                table: "LivroCategoriaModel",
                newName: "Descricao");

            migrationBuilder.RenameColumn(
                name: "ativo",
                table: "LivroCategoriaModel",
                newName: "Ativo");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "LivroCategoriaModel",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "usuario_edicao",
                table: "LivroCategoriaModel",
                newName: "UsuarioEdicao");

            migrationBuilder.RenameColumn(
                name: "usuario_cadastro",
                table: "LivroCategoriaModel",
                newName: "UsuarioCadastro");

            migrationBuilder.RenameColumn(
                name: "data_edicao",
                table: "LivroCategoriaModel",
                newName: "DataEdicao");

            migrationBuilder.RenameColumn(
                name: "data_cadastro",
                table: "LivroCategoriaModel",
                newName: "DataCadastro");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UsuarioModel",
                table: "UsuarioModel",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_LivroCategoriaModel",
                table: "LivroCategoriaModel",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_Livros_livroCategoriaId",
                table: "Livros",
                column: "livroCategoriaId");

            migrationBuilder.AddForeignKey(
                name: "FK_Livros_LivroCategoriaModel_livroCategoriaId",
                table: "Livros",
                column: "livroCategoriaId",
                principalTable: "LivroCategoriaModel",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
