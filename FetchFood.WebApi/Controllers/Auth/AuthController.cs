using FetchFood.UseCases.DTOs;
using FetchFood.UseCases.Services.Interfaces;
using FluentResults;
using Microsoft.AspNetCore.Mvc;

namespace FetchFood.WebApi.Controllers.Auth
{
    [ApiController]
    [Route("[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost("login")]
        public async Task<IActionResult> LoginAsync([FromBody] LoginRequestDto loginRequestDto)
        {
            Result result = await _authService.LoginAsync(loginRequestDto);
            if(result.IsSuccess)
                return Ok(result);
            return Unauthorized(result);
        }
    }
}
