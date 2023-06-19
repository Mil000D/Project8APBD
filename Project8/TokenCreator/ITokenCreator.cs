using Zadanie8.Models;

namespace Zadanie8.TokenCreator
{
    public interface ITokenCreator
    {
        public Task<dynamic> CreateToken(User user);
    }
}
