using FetchFood.Entities;
using FetchFood.UseCases.Services.Interfaces;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace FetchFood.UseCases.Services
{
    public class TokenService : ITokenService
    {
        private string? _jwtSecret;

        public TokenService(IConfiguration configuration)
        {
            _jwtSecret = configuration.GetSection("JwtConfig")
                .GetSection("secret").Value;
        }

        public Token CreateToken(
            CustomIdentityUser user, 
            IEnumerable<string> roles)
        {
            var roleClaims = roles.Select(
                role => new Claim(ClaimTypes.Role, role)).ToArray();

            var userRights = new List<Claim>
            {
                new Claim("username", user.UserName),
                new Claim("id", user.Id.ToString())
            };

            userRights.AddRange(roleClaims);

            SymmetricSecurityKey key = new SymmetricSecurityKey(Encoding.UTF8
                .GetBytes(_jwtSecret));
            SigningCredentials credentials = new SigningCredentials(key,
                SecurityAlgorithms.HmacSha256);

            JwtSecurityToken token = new JwtSecurityToken(
                claims: userRights,
                signingCredentials: credentials,
                expires: DateTime.UtcNow.AddHours(8));

            string tokenString = new JwtSecurityTokenHandler().WriteToken(token);
            return new Token(tokenString);
        }
    }
}
