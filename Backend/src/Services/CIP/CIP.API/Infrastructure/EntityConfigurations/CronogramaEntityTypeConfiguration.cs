using CIP.API.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CIP.API.Infrastructure.EntityConfigurations
{
    public class CronogramaEntityTypeConfiguration
        : IEntityTypeConfiguration<Cronograma>
    {
        public void Configure(EntityTypeBuilder<Cronograma> builder)
        {
            builder.ToTable("Cronograma");

            builder.HasKey(ci => ci.CronogramaId);

            builder.Property(ci => ci.CronogramaId)
               .IsRequired();

            builder.Property(cb => cb.OcorrenciaId)
                .IsRequired();
        }
    }
}
