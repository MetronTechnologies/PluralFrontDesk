using FrontDeskApp.Domain.Entities;

namespace FrontDeskApp.Application.Services.Security
{
    public interface IJwtTokenService
    {
        string GenerateToken(Users user);
    }
}