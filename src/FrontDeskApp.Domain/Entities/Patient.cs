using FrontDeskApp.Domain.Enums;

namespace FrontDeskApp.Domain.Entities
{
    public class Patient : Users
    {
        public required string Code { get; set; }

        public PatientStatus Status { get; set; }

        public Wallet Wallet { get; set; } = null!;
    }
}