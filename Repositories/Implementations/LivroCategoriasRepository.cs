using BibliotecaAPI.Db;
using BibliotecaAPI.Models;
using BibliotecaAPI.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace BibliotecaAPI.Repositories.Implementations
{
    public class LivroCategoriasRepository : ILivroCategoriasRepository
    {
        private readonly LivroContext _context;

        public LivroCategoriasRepository(LivroContext context)
        {
            _context = context;
        }

        public async Task<List<LivroCategoriaModel>> GetLivroCategoriasAsync()
        {
            var categorias = await _context.LivroCategorias.ToListAsync();
            return categorias;
        }

        public async Task<LivroCategoriaModel> PostLivroCategoriaAsync(LivroCategoriaModel categoria)
        {
            _context.LivroCategorias.Add(categoria);
            await _context.SaveChangesAsync();

            return categoria;
        }
        public async Task DeleteLivroCategoriaAsync(int id)
        {
            var categoria = await _context.LivroCategorias.Where(x => x.Id == id).FirstOrDefaultAsync();
            if (categoria == null) throw new Exception("Categoria não encontrada");
            _context.LivroCategorias.Remove(categoria);
            await _context.SaveChangesAsync();
        }
    }
}
