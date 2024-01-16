using BibliotecaAPI.DTO;
using BibliotecaAPI.Models;

namespace BibliotecaAPI.Repositories.Interfaces
{
    public interface ILivroRepository
    {
        public Task<object> GetLivrosAsync(ListagemDTO listagem);
        public Task<LivroModel> GetLivroAsync(int id);
        public Task<LivroModel> PutLivroAsync(int id, LivroModel livro, string user);
        public Task<LivroModel> PostLivroAsync(LivroModel livro, string user);
        public Task DeleteLivroAsync(int id);
    }
}
