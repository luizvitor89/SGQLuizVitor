using CIP.API.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CIP.API.Infrastructure.EntityConfigurations
{
    public class StatusEntityTypeConfiguration
        : IEntityTypeConfiguration<Status>
    {
        public void Configure(EntityTypeBuilder<Status> builder)
        {
            builder.ToTable("Status");

            builder.HasKey(ci => ci.StatusId);

            builder.Property(ci => ci.StatusId)
               .IsRequired();

        }
    }
}
