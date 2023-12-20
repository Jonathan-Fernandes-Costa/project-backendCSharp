﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BibliotecaAPI.Db;
using BibliotecaAPI.Models;
using BibliotecaAPI.Repositories.Interfaces;
using BibliotecaAPI.Repositories.Implementations;
using BibliotecaAPI.Services;

namespace BibliotecaAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly IUsuarioRepository _usuarioRepository;

        public UsuarioController(IUsuarioRepository usuarioRepository)
        {
            _usuarioRepository = usuarioRepository;
        }

        // GET: api/Usuario
        [HttpGet]
        public async Task<ActionResult> GetUsuario()
        {
            try
            {
                var response = await _usuarioRepository.GetUsuariosAsync();
                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // GET: api/Usuario/5
        [HttpGet("{id}")]
        public async Task<ActionResult<UsuarioModel>> GetUsuario(int id)
        {
            try
            {
                var response = await _usuarioRepository.GetUsuarioAsync(id);
                return Ok(response);
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }
        [HttpPost]
        public async Task<ActionResult<UsuarioModel>> PostUsuario(UsuarioModel usuario)
        {
            try
            {
                var response = await _usuarioRepository.PostUsuarioAsync(usuario);
                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
        public class LoginModel
        {
            public string Email { get; set; } = string.Empty;
            public string Password { get; set; } = string.Empty;
        }
        [HttpPost("/api/login")]
        public async Task<ActionResult<UsuarioModel>> LoginUsuario(LoginModel login)
        {
            try
            {
                var response = await _usuarioRepository.LoginUsuarioAsync(login.Email, login.Password);
                if(response != null)
                {
                    var token = TokensService.GenerateToken(response);
                    return Ok(token);
                }
                return BadRequest("Sem retorno");

            }
            catch(Exception ex)
            {
                return BadRequest("Email ou senha inválidos" + ex);
            }

        }
        [HttpGet("/api/sessao/validar")]
        public ActionResult ValidaToken(string token)
        {
            try
            {
                var tokenValidationService = HttpContext.RequestServices.GetRequiredService<TokenValidationService>();
                if (tokenValidationService.ValidateToken(token))
                {
                    //var newToken = TokensService.GenerateToken();
                    return Ok(token);
                }
                else
                {
                    return Unauthorized("Token inválido");
                }
            }catch(Exception ex)
            {
                return BadRequest("TESTE"+ex);
            }

        }
        // PUT: api/Usuario/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        /*[HttpPut("{id}")]
        public async Task<IActionResult> PutUsuarioModel(int id, UsuarioModel usuarioModel)
        {
            try
            {
                var response = await _usuarioRepository.Put(id, livro);
                return Ok(response);
            }
            catch (Exception ex)
            {
                return NotFound(ex);
            }
        }
        */
        // POST: api/Usuario
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754

        // DELETE: api/Usuario/5
        /*[HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUsuarioModel(int id)
        {
            if (_context.UsuarioModel == null)
            {
                return NotFound();
            }
            var usuarioModel = await _context.UsuarioModel.FindAsync(id);
            if (usuarioModel == null)
            {
                return NotFound();
            }

            _context.UsuarioModel.Remove(usuarioModel);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool UsuarioModelExists(int id)
        {
            return (_context.UsuarioModel?.Any(e => e.id == id)).GetValueOrDefault();
        }*/
    }
}