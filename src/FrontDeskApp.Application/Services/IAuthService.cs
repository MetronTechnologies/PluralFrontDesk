using FrontDeskApp.Application.Common;
using FrontDeskApp.Application.DTOs;
using FrontDeskApp.Domain.Entities;

namespace FrontDeskApp.Application.Services
{
    public interface IAuthService
    {
         Task<ResponseInfo<LoginResponseDto?>> LoginAsync(LoginRequestDto dto);
         Task<ResponseInfo<Users?>> RegisterAsync(RegisterUserDto dto);
    }
}