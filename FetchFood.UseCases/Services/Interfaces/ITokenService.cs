
using FetchFood.Entities;

namespace FetchFood.UseCases.Services.Interfaces
{
    public interface ITokenService
    {
        Token CreateToken(
            CustomIdentityUser user,
            IEnumerable<string> roles);
    }
}
