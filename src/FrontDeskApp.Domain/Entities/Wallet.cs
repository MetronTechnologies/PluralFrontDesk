using System.ComponentModel.DataAnnotations.Schema;
using FrontDeskApp.Domain.Enums;

namespace FrontDeskApp.Domain.Entities
{
    public class Wallet : BaseEntity
    {
        [Column(TypeName = "decimal(18,2)")]
        public decimal Balance { get; set; }

        public required Currency Currency { get; set; }

        // FK
        public Guid PatientId { get; set; }

        // Navigation
        public Patient Patient { get; set; } = null!;
    }
}