using FrontDeskApp.Application.Common;
using FrontDeskApp.Application.DTOs;
using FrontDeskApp.Application.RepositoryInterfaces;
using FrontDeskApp.Application.Services;
using FrontDeskApp.Application.Services.Security;
using FrontDeskApp.Domain.Entities;

namespace FrontDeskApp.Infrastructure.Services
{
    public class AuthService : IAuthService
    {
        private readonly IUsersRepository _usersRepository;
        private readonly IJwtTokenService _jwtTokenService;

        public AuthService(IUsersRepository usersRepository, IJwtTokenService jwtTokenService)
        {
            _usersRepository = usersRepository;
            _jwtTokenService = jwtTokenService;
        }

        public async Task<ResponseInfo<LoginResponseDto?>> LoginAsync(LoginRequestDto dto)
        {
            ResponseInfo<LoginResponseDto?> responseInfo = new();
            Users? user = await _usersRepository.GetSingleAsync(x => x.Email == dto.Email);

            if (user == null || !user.IsActive) return responseInfo.MarkFail("User is not in the system or user is not active");

            if (!BCrypt.Net.BCrypt.Verify(dto.Password, user.PasswordHash))
                return responseInfo.MarkFail("Invalid credentials");

            var token = _jwtTokenService.GenerateToken(user);

            return responseInfo.MarkSuccess(
                new()
                {
                    Token = token,
                    Email = user.Email,
                    Roles = user.Roles
                }
            );

        }

        public async Task<ResponseInfo<Users?>> RegisterAsync(RegisterUserDto dto)
        {
            ResponseInfo<Users?> responseInfo = new();

            // Check if email exists
            Users? existingUser = await _usersRepository.GetSingleAsync(x => x.Email == dto.Email);
            if (existingUser != null) return responseInfo.MarkFail("Email is already registered");

            // Hash password
            string passwordHash = BCrypt.Net.BCrypt.HashPassword(dto.Password);

            // Create new user
            var user = new Users
            {
                FirstName = dto.FirstName,
                LastName = dto.LastName,
                Email = dto.Email,
                PhoneNumber = dto.PhoneNumber,
                PasswordHash = passwordHash,
                Roles = dto.Roles
            };

            await _usersRepository.AddAsync(user);

            return responseInfo.MarkSuccess(user, "User registered successfully");
        }

    }
}