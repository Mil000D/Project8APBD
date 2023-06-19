using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Zadanie8.DTO;
using Zadanie8.Models;
using Zadanie8.PasswordHandlers;
using Zadanie8.TokenCreator;

namespace Zadanie8.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountsController : ControllerBase
    {
        public readonly MainDbContext _context;
        public readonly ITokenCreator _tokenCreator;
        public AccountsController(MainDbContext context, ITokenCreator tokenCreator)
        {
            _context = context;
            _tokenCreator = tokenCreator;
        }
        [HttpPost("/register")]
        public async Task<IActionResult> Register(LoginRegisterDTO register)
        {
            var userQuery = await _context.Users.Where(u => u.Username == register.Username)
                                           .FirstOrDefaultAsync();
            if (userQuery != null)
            {
                return BadRequest("User with specified name already exists");
            }
            var user = new User
            {
                Username = register.Username,
                Password = PasswordHandler.HashPassword(register.Username, register.Password),
            };
            await _context.Users.AddAsync(user);
            await _context.SaveChangesAsync();
            return Ok(await _tokenCreator.CreateToken(user));
        }

        [HttpPost("/login")]
        public async Task<IActionResult> Login(LoginRegisterDTO login)
        {
            var user = await _context.Users
                             .Where(u => u.Username == login.Username)
                             .FirstOrDefaultAsync();
            if (user != null)
            {
                if (PasswordHandler.VerifyPassword(user.Username, user.Password, login.Password))
                {
                    return Ok(await _tokenCreator.CreateToken(user));
                }
            }
            return BadRequest("Provided username or/and password are invalid, try again");
        }

        [HttpGet("{refreshToken}")]
        public async Task<IActionResult> GetToken(string refreshToken)
        {
            var user = await _context.Users.Where(u => u.RefreshToken == refreshToken && u.RefreshTokenExpirationDate >= DateTime.Now)
                                           .FirstOrDefaultAsync();
            if (user == null) 
            {
                return BadRequest("Such refresh token doesn't exist");
            }

            return Ok(await _tokenCreator.CreateToken(user));
        }
    }
}
