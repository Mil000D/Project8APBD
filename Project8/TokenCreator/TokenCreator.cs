using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Zadanie8.Models;

namespace Zadanie8.TokenCreator
{
    public class TokenCreator : ITokenCreator
    {
        public readonly MainDbContext _context;
        public TokenCreator(MainDbContext context)
        {
            _context = context;
        }
        public async Task<dynamic> CreateToken(User user)
        {
            user.RefreshToken = Guid.NewGuid().ToString();
            user.RefreshTokenExpirationDate = DateTime.Now.AddDays(1);
            await _context.SaveChangesAsync();

            Claim[] claim = new[]
            {
                new Claim(ClaimTypes.Name, user.Username),
                new Claim(ClaimTypes.Role, "user")
            };

            SymmetricSecurityKey key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("longsecretkeylongsecretkeylongsecretkeylongsecretkeylongsecretkeylongsecretkeylongsecretkey"));
            SigningCredentials credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            JwtSecurityToken token = new JwtSecurityToken(
                issuer: "https://localhost:8888",
                audience: "https://localhost:8888",
                claims: claim,
                expires: DateTime.Now.AddMinutes(5),
                signingCredentials: credentials
             );
            return new { 
                accessToken = new JwtSecurityTokenHandler().WriteToken(token),
                refreshToken = user.RefreshToken
            };
        }
    }
}
