using FrontDeskApp.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FrontDeskApp.Infrastructure.Configurations
{
    public class WalletConfiguration : IEntityTypeConfiguration<Wallet>
    {
        public void Configure(EntityTypeBuilder<Wallet> builder)
        {
            builder.Property(w => w.Balance)
                   .HasPrecision(18, 2);

            builder.Property(w => w.Currency)
                   .HasConversion<string>()
                   .IsRequired()
                   .HasMaxLength(20);

            builder.HasIndex(w => new { w.PatientId, w.Currency })
                   .IsUnique();
        }
    }
    
}