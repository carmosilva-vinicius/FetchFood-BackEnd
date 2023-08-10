using FetchFood.UseCases.DTOs;
using FluentResults;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FetchFood.UseCases.Services.Interfaces
{
    public interface IAuthService
    {
        Task<Result> LoginAsync(LoginRequestDto loginRequestDto);
    }
}
