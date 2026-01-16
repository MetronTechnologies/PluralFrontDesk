using FrontDeskApp.Application.Common;
using FrontDeskApp.Application.DTOs;
using FrontDeskApp.Application.Services;
using Microsoft.AspNetCore.Mvc;

namespace FrontDeskApp.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginRequestDto dto)
        {
            ResponseInfo<LoginResponseDto?> result = await _authService.LoginAsync(dto);
            return Ok(result);
        }
        

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterUserDto dto)
        {
            var response = await _authService.RegisterAsync(dto);
            return Ok(response);
        }

        
    }
}