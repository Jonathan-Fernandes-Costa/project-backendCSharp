using BibliotecaAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace BibliotecaAPI.Db
{
    public class LivroContext : DbContext
    {
        public LivroContext(DbContextOptions<LivroContext> options) : base(options) { }
        public DbSet<LivroModel> Livros { get; set; }
        public DbSet<UsuarioModel> Usuarios { get; set; }
        public DbSet<LivroCategoriaModel> LivroCategorias { get; set;  }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<LivroModel>()
                .HasOne(l => l.livroCategoria)
                .WithMany()
                .HasForeignKey(l => l.livroCategoriaId);

            base.OnModelCreating(modelBuilder);
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            => optionsBuilder.UseNpgsql(
            "Server=localhost;" +
            "Port=5432;Database=Biblioteca;" +
            "User Id=postgres;" +
            "Password=022004;");

    }
}
