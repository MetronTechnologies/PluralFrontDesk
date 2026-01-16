using System.ComponentModel.DataAnnotations.Schema;
using FrontDeskApp.Domain.Enums;

namespace FrontDeskApp.Domain.Entities
{
    public class Appointment : BaseEntity
    {
        public Guid PatientId { get; set; }
        public Patient Patient { get; set; } = null!;

        public Guid ClinicId { get; set; }
        public Clinic Clinic { get; set; } = null!;

        public required DateTime AppointmentTime { get; set; }
        public required AppointmentStatus AppointmentStatus { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public required decimal AmountPaid { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal DiscountAllowed { get; set; }
    }
}