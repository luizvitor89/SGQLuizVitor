using CIP.API.Entities;
using CIP.API.Infrastructure.EntityConfigurations;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace CIP.API.Infrastructure
{

    public class CIPContext : DbContext
    {
        public CIPContext(DbContextOptions<CIPContext> options) : base(options)
        {
        }

        public DbSet<Cronograma> Cronograma { get; set; }
        public DbSet<Emissor> Emissor { get; set; }
        public DbSet<Insumo> Insumo { get; set; }
        public DbSet<Ocorrencia> Ocorrencia { get; set; }
        public DbSet<Setor> Setor { get; set; }
        public DbSet<Status> Status { get; set; }
        public DbSet<TipoOcorrencia> TipoOcorrencia { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new CronogramaEntityTypeConfiguration());
            builder.ApplyConfiguration(new EmissorEntityTypeConfiguration());
            builder.ApplyConfiguration(new InsumoEntityTypeConfiguration());
            builder.ApplyConfiguration(new OcorrenciaEntityTypeConfiguration());
            builder.ApplyConfiguration(new SetorEntityTypeConfiguration());
            builder.ApplyConfiguration(new StatusEntityTypeConfiguration());
            builder.ApplyConfiguration(new TipoOcorrenciaEntityTypeConfiguration());
        }
    }


    public class CIPContextDesignFactory : IDesignTimeDbContextFactory<CIPContext>
    {
        public CIPContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<CIPContext>()
                .UseSqlServer("Server=sql.data;Database=CIP;User Id=sa;Password=Pass@word;");

            return new CIPContext(optionsBuilder.Options);
        }
    }
}
