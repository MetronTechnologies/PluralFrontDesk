using FrontDeskApp.Domain.Enums;

namespace FrontDeskApp.Application.DTOs
{
    public class CreatePatientDto
    {
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string PhoneNumber { get; set; } = null!;
        public string Password { get; set; } = null!;
        public string Code { get; set; } = null!;
        public Currency Currency { get; set; }
    }
}