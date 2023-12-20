using BibliotecaAPI.Models;

namespace BibliotecaAPI.Repositories.Interfaces
{
    public interface IUsuarioRepository
    {
        public Task<List<UsuarioModel>> GetUsuariosAsync();
        public Task<UsuarioModel> GetUsuarioAsync(int id);
        public Task<UsuarioModel> PostUsuarioAsync(UsuarioModel usuario);
        public Task<UsuarioModel> LoginUsuarioAsync(string email, string password);
    }
}
