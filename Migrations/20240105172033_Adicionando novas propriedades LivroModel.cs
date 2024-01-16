using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BibliotecaAPI.Migrations
{
    /// <inheritdoc />
    public partial class AdicionandonovaspropriedadesLivroModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "usuario_ultima_alteracao",
                table: "Livros",
                newName: "usuario_edicao");

            migrationBuilder.RenameColumn(
                name: "data_ultima_alteracao",
                table: "Livros",
                newName: "data_edicao");

            migrationBuilder.AddColumn<DateTime>(
                name: "data_cadastro",
                table: "Livros",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "usuario_cadastro",
                table: "Livros",
                type: "text",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "data_cadastro",
                table: "Livros");

            migrationBuilder.DropColumn(
                name: "usuario_cadastro",
                table: "Livros");

            migrationBuilder.RenameColumn(
                name: "usuario_edicao",
                table: "Livros",
                newName: "usuario_ultima_alteracao");

            migrationBuilder.RenameColumn(
                name: "data_edicao",
                table: "Livros",
                newName: "data_ultima_alteracao");
        }
    }
}
