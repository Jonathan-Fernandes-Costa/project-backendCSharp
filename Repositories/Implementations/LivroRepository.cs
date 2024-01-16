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
using BibliotecaAPI.DTO;
using Microsoft.IdentityModel.Tokens;
using System.Runtime.Serialization;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using System.Text;

namespace BibliotecaAPI.Repositories.Implementations
{
    public class LivroRepository : ILivroRepository
    {
        private readonly LivroContext _context;

        public LivroRepository(LivroContext context)
        {
            _context = context;
        }

        public async Task<object> GetLivrosAsync(ListagemDTO listagem)
        {
            var query = _context.Livros.Include(x => x.LivroCategoria).AsQueryable();

            if (!string.IsNullOrEmpty(listagem.Pesquisa))
            {
                query = query.Where(l => l.Titulo.Contains(listagem.Pesquisa) || l.Subtitulo.Contains(listagem.Pesquisa) || l.Autor.Contains(listagem.Pesquisa)) ;
            }

            if (listagem.LivroCategoriaId.HasValue)
            {
                query = query.Where(l => l.LivroCategoriaId == listagem.LivroCategoriaId.Value);
            }

            var totalRegisters = await query.CountAsync();
            var totalPages = (int)Math.Ceiling((double)totalRegisters / listagem.PageSize);
            var currentPageClamped = Math.Clamp(listagem.CurrentPage, 0, totalPages); 
            var livros = await query.Skip(currentPageClamped * listagem.PageSize).Take(listagem.PageSize).ToListAsync();

            ResultListagemDTO result = new ResultListagemDTO();
            result.Dados = livros;
            result.TotalPages = totalPages;
            result.CurrentPage = currentPageClamped;
            result.PageSize = listagem.PageSize;
            result.TotalRegister = totalRegisters;
            
            
            return result;
            
            
        }
            
        

        public async Task<LivroModel> GetLivroAsync(int id)
        {
            var livro = await _context.Livros.Include(x => x.LivroCategoria).Where(x => x.id == id).FirstOrDefaultAsync();
            if (livro == null) throw new Exception("Livro não encontrado");
            return livro;
        }

        public async Task<LivroModel> PutLivroAsync(int id, LivroModel livro, string user)
       {
            VerificaCampos(livro);
            var livroDB = await _context.Livros.Where(x => x.id == id).FirstOrDefaultAsync();
            if (livroDB == null) throw new Exception("Livro não encontrado");


            livroDB.Titulo = livro.Titulo.ToUpper();
            livroDB.Subtitulo = livro.Subtitulo;
            livroDB.Autor = livro.Autor.ToUpper();
            livroDB.AnoEdicao = livro.AnoEdicao;
            livroDB.Editora = livro.Editora.ToUpper();
            livroDB.Codigo = livro.Codigo;
            livroDB.LivroCategoriaId = livro.LivroCategoriaId;
            livroDB.FotoPath = livro.FotoPath;
            livroDB.Sinopse = livro.Sinopse.ToUpper();
            livroDB.DataEdicao = DateTime.UtcNow;
            livroDB.UsuarioEdicao = user;

            await _context.SaveChangesAsync();
            return livroDB;
        }

        public async Task<LivroModel> PostLivroAsync(LivroModel livro, string user)
        {
            VerificaCampos(livro);
            LivroModel livroDB = new LivroModel();
            livroDB.Titulo = livro.Titulo.ToUpper();
            livroDB.Subtitulo = livro.Subtitulo.ToUpper();
            livroDB.Autor = livro.Autor.ToUpper();
            livroDB.AnoEdicao = livro.AnoEdicao;
            livroDB.Editora = livro.Editora.ToUpper();
            livroDB.Codigo = livro.Codigo;
            livroDB.LivroCategoriaId = livro.LivroCategoriaId;
            livroDB.FotoPath = livro.FotoPath;
            livroDB.Sinopse = livro.Sinopse.ToUpper();
            livroDB.DataCadastro = DateTime.UtcNow;
            livroDB.UsuarioCadastro = user;


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

        public async void VerificaCampos(LivroModel livro)
        {
            StringBuilder erros = new StringBuilder();

            if (string.IsNullOrEmpty(livro.Titulo))
            {
                erros.AppendLine("O campo Título deve ser preenchido");
            }

            if (string.IsNullOrEmpty(livro.Subtitulo))
            {
                erros.AppendLine("O campo Subtítulo deve ser preenchido");
            }

            if (string.IsNullOrEmpty(livro.Autor))
            {
                erros.AppendLine("O campo Autor deve ser preenchido");
            }

            if (livro.AnoEdicao == 0 && livro.AnoEdicao < DateTime.Now.Year)
            {
                erros.AppendLine("O campo Ano de Edição deve ser preenchido");
            }

            if (string.IsNullOrEmpty(livro.Editora))
            {
                erros.AppendLine("O campo Editora deve ser preenchido");
            }

            if (livro.Codigo == 0)
            {
                erros.AppendLine("O campo Código deve ser preenchido");
            }
            var categoria = await _context.LivroCategorias.Where(x => x.Id == livro.LivroCategoriaId).FirstOrDefaultAsync();

            if (categoria == null)
            {
                erros.AppendLine("A categoria escolhida é inválida");
            }
            if (livro.LivroCategoriaId == 0)
            {
                erros.AppendLine("O campo Categoria do Livro deve ser preenchido");
            }

            if (string.IsNullOrEmpty(livro.Sinopse))
            {
                erros.AppendLine("O campo Sinopse deve ser preenchido");
            }

            if (erros.Length > 0)
            {
                throw new Exception(erros.ToString());
            }
        }

    }
}
