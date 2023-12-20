using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BibliotecaAPI.Models;
using BibliotecaAPI.Repositories.Interfaces;
using Microsoft.AspNetCore.Authorization;

namespace BibliotecaAPI.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class LivrosController : ControllerBase
    {
        private readonly ILivroRepository _livroRepository;

        public LivrosController(ILivroRepository livroRepository)
        {
            _livroRepository = livroRepository;
        }

        // GET: api/Livros
        [HttpGet]
        public async Task<ActionResult> GetLivros()
        {
            try
            {
                var response = await _livroRepository.GetLivrosAsync();
                return Ok(response);
            }catch (Exception ex) 
            {
                return BadRequest(ex.Message);
            }
        }

        // GET: api/Livros/5
        
        [HttpGet("{id}")]
        public async Task<ActionResult<LivroModel>> GetLivro(int id)
        {
            try
            {
                var response = await _livroRepository.GetLivroAsync(id);
                return Ok(response);
            }catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }

        // PUT: api/Livros/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutLivro(int id,[FromBody] LivroModel livro)
        {
            try
            {
                var response = await _livroRepository.PutLivroAsync(id, livro);
                return Ok(response);
            }
            catch (Exception ex)
            {
                return NotFound(ex);
            }

        }
        // POST: api/Livros
        [HttpPost]
        public async Task<ActionResult<LivroModel>> PostLivro([FromForm] LivroModel livro)
        {
                try
                {
                    if (livro.Foto != null) {
                       var filePath = Path.Combine("Storage", livro.Foto.FileName); //Pegando o nome do arquivo
                        using (Stream fileStream = new FileStream(filePath, FileMode.Create))
                        {
                            livro.Foto.CopyTo(fileStream);
                        }
                        livro.FotoPath = filePath;}
                
                    
                    var response  = await _livroRepository.PostLivroAsync(livro);
                    return Ok(response);
                }catch (Exception ex)
                {
                    return BadRequest(ex);
                }
        }

        // DELETE: api/Livros/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteLivro(int id)
        {
                try
                {
                    await _livroRepository.DeleteLivroAsync(id);
                    return NoContent();
                }catch(Exception ex)
                {
                    return BadRequest(ex);
                }
                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                         
        }
        [HttpPost("{id}/foto")]
        public async Task<IActionResult> GetFoto(int id)
        {
            try
            {
                var livro = await _livroRepository.GetLivroAsync(id);
                var foto = System.IO.File.ReadAllBytes(livro.FotoPath);

                return File(foto, "image/png");
            }catch(Exception ex)
            {
                return NotFound(ex);
            }
            
        }
    }
}
