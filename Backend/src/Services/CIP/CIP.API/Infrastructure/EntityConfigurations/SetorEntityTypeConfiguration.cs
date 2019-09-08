using CIP.API.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CIP.API.Infrastructure.EntityConfigurations
{
    public class SetorEntityTypeConfiguration
        : IEntityTypeConfiguration<Setor>
    {
        public void Configure(EntityTypeBuilder<Setor> builder)
        {
            builder.ToTable("Setor");

            builder.HasKey(ci => ci.SetorId);

            builder.Property(ci => ci.SetorId)
               .IsRequired();

        }
    }
}
