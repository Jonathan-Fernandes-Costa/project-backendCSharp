using BibliotecaAPI.Models;

namespace BibliotecaAPI.Repositories.Interfaces
{
    public interface ILivroCategoriasRepository
    {
        public Task<List<LivroCategoriaModel>> GetLivroCategoriasAsync();
        public Task<LivroCategoriaModel> PostLivroCategoriaAsync(LivroCategoriaModel categoria);
        public Task DeleteLivroCategoriaAsync(int id);
    
    }
}
