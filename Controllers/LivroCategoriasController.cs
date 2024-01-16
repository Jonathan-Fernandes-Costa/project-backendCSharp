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
using BibliotecaAPI.DTO;
using BibliotecaAPI.Repositories.Implementations;
namespace BibliotecaAPI.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class LivroCategoriaController : ControllerBase
    {
        private readonly ILivroCategoriasRepository _livroCategoriasRepository;

        public LivroCategoriaController(ILivroCategoriasRepository livroCategoriasRepository)
        {
            _livroCategoriasRepository = livroCategoriasRepository;
        }

        [HttpGet]
        public async Task<ActionResult> GetLivroCategorias()
        {
            try
            {
                var response = await _livroCategoriasRepository.GetLivroCategoriasAsync();
                return Ok(response);
            }catch (Exception ex) 
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public async Task<ActionResult<LivroCategoriaModel>> PostCategoria(LivroCategoriaModel categoria)
        {
            try
            {
                var response = await _livroCategoriasRepository.PostLivroCategoriaAsync(categoria);
                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteLivroCategoria(int id)
        {
            try
            {
                await _livroCategoriasRepository.DeleteLivroCategoriaAsync(id);
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }

        }
    }
}
