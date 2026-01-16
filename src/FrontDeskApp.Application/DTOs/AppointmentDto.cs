using FrontDeskApp.Domain.Enums;

namespace FrontDeskApp.Application.DTOs
{
    public class AppointmentDto
    {
        public int Id { get; set; }

        public int PatientId { get; set; }

        public int ClinicId { get; set; }

        public DateTime AppointmentTime { get; set; }

        public AppointmentStatus AppointmentStatus { get; set; }

        public decimal AmountPaid { get; set; }

        public decimal DiscountAllowed { get; set; }
    }

}