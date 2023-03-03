using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using APIVenda_BD.Models;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;


namespace APIVenda_BD.Application.Security
{
    public class TokenManager
    {
        private readonly AuthSettings _authSettings;

        public TokenManager(IOptions<AuthSettings> authSettings)
        {
            _authSettings = authSettings.Value;
        }

        public Task<AuthResponse> GenerateTokenAsync(User user)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var date = DateTime.UtcNow;
            var expire = date.AddHours(_authSettings.ExpireIn);
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_authSettings.Secret));

            var securityToken = tokenHandler.CreateToken(new SecurityTokenDescriptor()
            {
                Issuer = "vendas",
                IssuedAt = date,
                NotBefore = date,
                Expires = expire,
                SigningCredentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256Signature),
                Subject = new ClaimsIdentity(new GenericIdentity(user.Senha, JwtBearerDefaults.AuthenticationScheme), new[]
                {
                    new Claim(ClaimTypes.NameIdentifier, user.Codigo)
                })
            });

            var response = new AuthResponse()
            {
                Token = tokenHandler.WriteToken(securityToken),
                ExpireIn = _authSettings.ExpireIn,
                Type = JwtBearerDefaults.AuthenticationScheme
            };

            return Task.FromResult(response);
        }
    }
}