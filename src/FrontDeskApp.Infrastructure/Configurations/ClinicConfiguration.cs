using FrontDeskApp.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FrontDeskApp.Infrastructure.Configurations
{
    public class ClinicConfiguration : IEntityTypeConfiguration<Clinic>
    {
        public void Configure(EntityTypeBuilder<Clinic> builder)
        {
            builder.Property(c => c.Name)
                   .IsRequired()
                   .HasMaxLength(200);

            builder.HasIndex(c => c.Name)
                   .IsUnique();

            // ✅ Seed data
            builder.HasData(
                new Clinic
                {
                    Id = Guid.NewGuid(),
                    Name = "Main Clinic",
                    Location = "Main Land",
                    CreatedDate = DateTime.UtcNow
                },
                new Clinic
                {
                    Id = Guid.NewGuid(),
                    Name = "Dental Clinic",
                    Location = "Dental Land",
                    CreatedDate = DateTime.UtcNow
                },
                new Clinic
                {
                    Id = Guid.NewGuid(),
                    Name = "Pediatrics Clinic",
                    Location = "Ped Land",
                    CreatedDate = DateTime.UtcNow
                }
            );
        }
    }
}