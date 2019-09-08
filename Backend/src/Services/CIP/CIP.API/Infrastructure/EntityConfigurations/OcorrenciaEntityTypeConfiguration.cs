using CIP.API.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CIP.API.Infrastructure.EntityConfigurations
{
    public class OcorrenciaEntityTypeConfiguration
        : IEntityTypeConfiguration<Ocorrencia>
    {
        public void Configure(EntityTypeBuilder<Ocorrencia> builder)
        {
            builder.ToTable("Ocorrencia");

            builder.HasKey(ci => ci.OcorrenciaId);

            builder.Property(ci => ci.OcorrenciaId)
               .IsRequired();

        }
    }
}
