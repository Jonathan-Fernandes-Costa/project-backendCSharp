using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.IdentityModel.Tokens;

namespace BibliotecaAPI.Services
{
    public class TokenValidationService
    {


        public bool ValidateToken(string token)
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

                // Validação do token
                SecurityToken validatedToken;
                tokenHandler.ValidateToken(token, tokenValidationParameters, out validatedToken);
                
                return true;
            }
            catch (Exception)
            {
                // Se houver qualquer exceção, o token é inválido
                return false;
            }
        }
    }
}
