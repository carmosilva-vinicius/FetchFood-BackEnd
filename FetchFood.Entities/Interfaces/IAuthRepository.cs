using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FetchFood.Entities.Interfaces
{
    public interface IAuthRepository
    {
        Task<CustomIdentityUser?> Login(string username, string password);
        Task<IEnumerable<string>> GetRoles(CustomIdentityUser user);
    }
}
