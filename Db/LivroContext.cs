using BibliotecaAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace BibliotecaAPI.Db
{
    public class LivroContext : DbContext
    {
        public LivroContext(DbContextOptions<LivroContext> options) : base(options) { }
        public DbSet<LivroModel> Livros { get; set; }
        public DbSet<UsuarioModel> Usuarios { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            => optionsBuilder.UseNpgsql(
            "Server=localhost;" +
            "Port=5432;Database=Biblioteca;" +
            "User Id=postgres;" +
            "Password=022004;");
        public DbSet<BibliotecaAPI.Models.UsuarioModel> UsuarioModel { get; set; } = default!;

    }
}
