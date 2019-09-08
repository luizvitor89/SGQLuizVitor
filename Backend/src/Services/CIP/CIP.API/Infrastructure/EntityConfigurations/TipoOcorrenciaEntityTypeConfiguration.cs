using CIP.API.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CIP.API.Infrastructure.EntityConfigurations
{
    public class TipoOcorrenciaEntityTypeConfiguration
        : IEntityTypeConfiguration<TipoOcorrencia>
    {
        public void Configure(EntityTypeBuilder<TipoOcorrencia> builder)
        {
            builder.ToTable("TipoOcorrencia");

            builder.HasKey(ci => ci.TipoOcorrenciaId);

            builder.Property(ci => ci.TipoOcorrenciaId)
               .IsRequired();

        }
    }
}
