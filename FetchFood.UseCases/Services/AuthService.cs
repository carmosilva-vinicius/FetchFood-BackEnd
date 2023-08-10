using FetchFood.Entities;
using FetchFood.Entities.Interfaces;
using FetchFood.UseCases.DTOs;
using FetchFood.UseCases.Services.Interfaces;
using FluentResults;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FetchFood.UseCases.Services
{
    public class AuthService : IAuthService
    {
        private readonly IAuthRepository _authRepository;
        private readonly ITokenService _tokenService;

        public AuthService(IAuthRepository authRepository, ITokenService tokenService)
        {
            _authRepository = authRepository;
            _tokenService = tokenService;
        }

        public async Task<Result> LoginAsync(LoginRequestDto loginRequestDto)
        {
            CustomIdentityUser? user = await _authRepository.Login(
                loginRequestDto.Username, loginRequestDto.Password);
            if (user != null)
            {
                IEnumerable<string> roles = await _authRepository
                    .GetRoles(user).ConfigureAwait(false);

                Token token = _tokenService.CreateToken(user, roles);

                return Result.Ok().WithSuccess(token.Value);
            }
            return Result.Fail("Login falhou");
        }
    }
}
