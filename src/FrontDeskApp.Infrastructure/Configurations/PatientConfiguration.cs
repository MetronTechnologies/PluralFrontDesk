using FrontDeskApp.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FrontDeskApp.Infrastructure.Configurations
{
    public class PatientConfiguration : IEntityTypeConfiguration<Patient>
    {
        public void Configure(EntityTypeBuilder<Patient> builder)
        {
            builder.Property(p => p.Code)
                   .IsRequired()
                   .HasMaxLength(50);

            builder.HasIndex(p => p.Code)
                   .IsUnique();

            builder.Property(p => p.Status)
                   .HasConversion<string>()
                   .IsRequired()
                   .HasMaxLength(20);

            builder.HasOne(p => p.Wallet)
                   .WithOne(w => w.Patient)
                   .HasForeignKey<Wallet>(w => w.PatientId)
                   .OnDelete(DeleteBehavior.Cascade);
        }
    }
}