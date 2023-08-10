using FetchFood.Entities;
using FetchFood.Entities.Interfaces;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FetchFood.Data.Repositories
{
    public class AuthRepository : IAuthRepository
    {
        private SignInManager<CustomIdentityUser> _signInManager;

        public AuthRepository(SignInManager<CustomIdentityUser> signInManager)
        {
            _signInManager = signInManager;
        }

        public async Task<CustomIdentityUser?> Login(string username, string password)
        {
            SignInResult? identityResult = await _signInManager
                .PasswordSignInAsync(username, password, false, false);
            if (!identityResult.Succeeded)
                return null;

            CustomIdentityUser? user = _signInManager.UserManager
                .Users.FirstOrDefault(u => u.NormalizedUserName
                == username.ToUpper());

            return user;
        }

        public async Task<IEnumerable<string>> GetRoles(CustomIdentityUser user)
        {
            return await _signInManager.UserManager.GetRolesAsync(user);
        }
    }
}
