using CIP.API.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CIP.API.Infrastructure.EntityConfigurations
{
    public class EmissorEntityTypeConfiguration
        : IEntityTypeConfiguration<Emissor>
    {
        public void Configure(EntityTypeBuilder<Emissor> builder)
        {
            builder.ToTable("Emissor");

            builder.HasKey(ci => ci.EmissorId);

            builder.Property(ci => ci.EmissorId)
               .IsRequired();

        }
    }
}
