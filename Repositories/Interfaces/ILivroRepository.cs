using BibliotecaAPI.Models;

namespace BibliotecaAPI.Repositories.Interfaces
{
    public interface ILivroRepository
    {
        public Task<List<LivroModel>> GetLivrosAsync();
        public Task<LivroModel> GetLivroAsync(int id);
        public Task<int> PutLivroAsync(int id, LivroModel livro);
        public Task<LivroModel> PostLivroAsync(LivroModel livro);
        public Task DeleteLivroAsync(int id);
    }
}
