using System.ComponentModel.DataAnnotations;

namespace FrontDeskApp.Domain.Entities
{
    public class Clinic : BaseEntity
    {
        [Required]
        [MaxLength(200)]
        public required string Name { get; set; }
        public string Location { get; set; }

        public ICollection<Appointment> Appointments { get; set; } = new List<Appointment>();
    }
}