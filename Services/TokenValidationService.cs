using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using BibliotecaAPI.Repositories.Interfaces;
using Microsoft.IdentityModel.Tokens;

namespace BibliotecaAPI.Services
{
    public class TokenValidationService
    {
        private readonly IUsuarioRepository _usuarioRepository;

        public TokenValidationService(IUsuarioRepository usuarioRepository)
        {
            _usuarioRepository = usuarioRepository;
        }
        public class TokenValidationResult
        {
            public bool Sucesso { get; set; }
            public TokenData? Dados { get; set; }
        }

        public class TokenData
        {
            public string Nome { get; set; } = string.Empty;
            public string Email { get; set; } = string.Empty;
            public string Token { get; set; } = string.Empty;
        }
        public  TokenValidationResult ValidateToken(string token)
        {
            try
            {
                var tokenHandler = new JwtSecurityTokenHandler();
                var key = Encoding.ASCII.GetBytes(Key.key);

                // Configuração da validação do token
                var tokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateIssuer = false, 
                    ValidateAudience = false, 
                    ClockSkew = TimeSpan.Zero 
                };
                var claimsPrincipal = tokenHandler.ValidateToken(token, tokenValidationParameters, out _);

                var usuarioIdClaim = claimsPrincipal.FindFirst("UsuarioId");
                var nomeClaim = claimsPrincipal.FindFirst("UsuarioNome");
                var emailClaim = claimsPrincipal.FindFirst("UsuarioEmail");

                var tokenData = new TokenData
                {
                    Nome = nomeClaim?.Value,
                    Email = emailClaim?.Value,
                    Token = token
                };

                return new TokenValidationResult
                {
                    Sucesso = true,
                    Dados = tokenData
                };

            }
            catch (SecurityTokenExpiredException)
            {

                var newTokenData =  GetNewTokenData(token);
                

                return new TokenValidationResult
                {
                    Sucesso = true,
                    Dados = newTokenData
                };
            }
            catch (Exception)
            {
                return new TokenValidationResult
                {
                    Sucesso = false,
                    Dados = null
                };
            }
        }

        private TokenData GetNewTokenData(string token)
        {
            try
            {
                var tokenHandler = new JwtSecurityTokenHandler();
                var key = Encoding.ASCII.GetBytes(Key.key);

                
                var tokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateIssuer = false,
                    ValidateAudience = false,
                    ValidateLifetime = false  //validação expiração
                };

                var claimsPrincipal = tokenHandler.ValidateToken(token, tokenValidationParameters, out _);

                var usuarioIdClaim = claimsPrincipal.FindFirst("UsuarioId");
                var nomeClaim = claimsPrincipal.FindFirst("UsuarioNome");
                var emailClaim = claimsPrincipal.FindFirst("UsuarioEmail");
                var passwordClaim = claimsPrincipal.FindFirst("Password");

                var usuarioId = usuarioIdClaim?.Value;
                var usuario = new Models.UsuarioModel
                {
                    Id = int.Parse(usuarioIdClaim?.Value),
                    Nome = nomeClaim?.Value,
                    Email = emailClaim?.Value,
                    Password = passwordClaim?.Value,

                };

                var novoToken = TokensService.GenerateToken(usuario);

                return new TokenData
                {
                    Nome = usuario.Nome,
                    Email = usuario.Email,
                    Token = novoToken.token
                };
            }
            catch (Exception)
            {
                // Se houver qualquer exceção, o token é inválido
                return null;
            }
        }
    }
}
