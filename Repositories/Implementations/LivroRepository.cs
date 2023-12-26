using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BibliotecaAPI.Models;
using BibliotecaAPI.Repositories.Interfaces;
using System.Security.Cryptography.X509Certificates;
using BibliotecaAPI.Db;
using Microsoft.AspNetCore.Http.HttpResults;

namespace BibliotecaAPI.Repositories.Implementations
{
    public class LivroRepository: ILivroRepository
    {
        private readonly LivroContext _context;

        public LivroRepository(LivroContext context)
        {
            _context = context;
        }

        public async Task<List<LivroModel>> GetLivrosAsync(int pageSize, int currentPage)
        {
            var livros = await _context.Livros.Include(x => x.livroCategoria).Skip(currentPage * pageSize).Take(pageSize).ToListAsync();
            return livros;
        }
        public async Task<LivroModel> GetLivroAsync(int id)
        {
            var livro = await _context.Livros.Include(x => x.livroCategoria).Where(x => x.id == id).FirstOrDefaultAsync();
            if (livro == null) throw new Exception("Livro não encontrado");
            return livro;
        }

        public async Task<int> PutLivroAsync(int id, LivroModel livro)
        {
            var livroDB = await _context.Livros.Where(x => x.id == id).FirstOrDefaultAsync();
            if (livroDB == null) throw new Exception("Livro não encontrado");

            livroDB.Titulo = livro.Titulo;
            livroDB.Subtitulo = livro.Subtitulo;
            livroDB.Autor = livro.Autor;
            livroDB.AnoEdicao = livro.AnoEdicao;
            livroDB.Editora = livro.Editora;
            livroDB.Codigo = livro.Codigo;
            livroDB.livroCategoriaId = livro.livroCategoriaId;
            livroDB.FotoPath = livro.FotoPath;
            await _context.SaveChangesAsync();
            return livroDB.id;
        }

        public async Task<LivroModel> PostLivroAsync(LivroModel livro)
        {
            LivroModel livroDB = new LivroModel();
            livroDB.Titulo = livro.Titulo;
            livroDB.Subtitulo = livro.Subtitulo;
            livroDB.Autor = livro.Autor;
            livroDB.AnoEdicao = livro.AnoEdicao;
            livroDB.Editora = livro.Editora;
            livroDB.Codigo = livro.Codigo;
            livroDB.livroCategoriaId = livro.livroCategoriaId;
            livroDB.FotoPath = livro.FotoPath;

            _context.Livros.Add(livroDB);
            await _context.SaveChangesAsync();

            return livro;
          
        }

        public async Task DeleteLivroAsync(int id)
        {
            var livro = await _context.Livros.Where(x => x.id == id).FirstOrDefaultAsync();
            if (livro == null) throw new Exception("Livro não encontrado");
            _context.Livros.Remove(livro);
            await _context.SaveChangesAsync();
        }


    }
}
