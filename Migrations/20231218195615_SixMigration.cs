using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BibliotecaAPI.Migrations
{
    /// <inheritdoc />
    public partial class SixMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Password",
                table: "UsuarioModel",
                newName: "password");

            migrationBuilder.RenameColumn(
                name: "Nome",
                table: "UsuarioModel",
                newName: "nome");

            migrationBuilder.RenameColumn(
                name: "Email",
                table: "UsuarioModel",
                newName: "email");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "UsuarioModel",
                newName: "id");
        }
    }
}
