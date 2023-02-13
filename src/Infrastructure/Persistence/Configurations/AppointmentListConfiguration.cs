using CleanArchitecture.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CleanArchitecture.Infrastructure.Persistence.Configurations;

public class AppointmentListConfiguration : IEntityTypeConfiguration<AppointmentList>
{
    public void Configure(EntityTypeBuilder<AppointmentList> builder)
    {
        builder.Property(t => t.Name)
            .HasMaxLength(200)
            .IsRequired();

        
    }
}
