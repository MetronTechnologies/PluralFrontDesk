using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using FrontDeskApp.Domain.Enums;

namespace FrontDeskApp.Domain.Entities
{

    public class AuditTrail : BaseEntity
    {
        [Required(ErrorMessage = "The audit action is compulsory")]
        [Column(TypeName = "nvarchar(24)")]
        public required AuditAction AuditAction { get; set; }
        public string? Description { get; set; }

        [Required(ErrorMessage = "The email of the user is compulsory")]
        public required string Actor { get; set; }
        public string? InitialData { get; set; }

        [Required(ErrorMessage = "The final data is compulsory")]
        public required string FinalData { get; set; }
    }
}