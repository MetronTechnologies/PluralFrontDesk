using System.ComponentModel.DataAnnotations;

namespace FrontDeskApp.Domain.Entities
{
    public class Users : BaseEntity
    {
        [Required]
        [MaxLength(100)]
        public required string FirstName { get; set; }
        
        
        [Required]
        [MaxLength(100)]
        public required string LastName { get; set; }


        [Required]
        [EmailAddress]
        [MaxLength(150)]
        public required string Email { get; set; }

        [Phone]
        [Required]
        [MaxLength(20)]
        public required string PhoneNumber { get; set; }

        public bool IsActive { get; set; } = true;
        [Required]
        public required string PasswordHash { get; set; }
        public List<string> Roles { get; set; } = new List<string>();
    }
}