﻿

namespace BibliotecaAPI.Models
{   
    public class UsuarioModel
    {
        public int Id {  get; set; }
        public string Nome { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;

    }
}