using BibliotecaAPI.Db;
using BibliotecaAPI.Models;
using BibliotecaAPI.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace BibliotecaAPI.Repositories.Implementations
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly LivroContext _context;
        public UsuarioRepository(LivroContext context)
        {
            _context = context;
        }

        public async Task<UsuarioModel> GetUsuarioAsync(int id)
        {
            var usuario = await _context.Usuarios.Where(x => x.Id == id).FirstOrDefaultAsync();
            if (usuario == null) throw new Exception("Usuário não encontrado");
            return usuario;
        }

        public async Task<List<UsuarioModel>> GetUsuariosAsync()
        {
            var usuarios = await _context.Usuarios.ToListAsync();
            return usuarios;
        }

        public async Task<UsuarioModel> PostUsuarioAsync(UsuarioModel usuario)
        {
            UsuarioModel novoUser = new UsuarioModel();
            novoUser.Password = usuario.Password;
            novoUser.Email = usuario.Email;
            novoUser.Nome = usuario.Nome;

            _context.Usuarios.Add(novoUser);
            await _context.SaveChangesAsync();
            return novoUser;
        }
        public async Task<UsuarioModel> LoginUsuarioAsync(string email, string password)
        {
            var usuario = await _context.Usuarios.Where(u => u.Email == email && u.Password == password).FirstOrDefaultAsync();
            if (usuario == null) throw new Exception("Login não encontrado");
            return usuario;
        }
    }
}
