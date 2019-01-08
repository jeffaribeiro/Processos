using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using SistemaProcessos.Data.Extensions;
using SistemaProcessos.Data.Mapeamentos;
using SistemaProcessos.Domain.Entidades;
using System.IO;

namespace SistemaProcessos.Data.Context
{
    public class MyContext : DbContext
    {
        public DbSet<Empresa> Empresa { get; set; }
        public DbSet<Processo> Processo { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.AddConfiguration(new EmpresaMap());
            modelBuilder.AddConfiguration(new ProcessoMap());
            base.OnModelCreating(modelBuilder);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var config = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            optionsBuilder.UseSqlServer(config.GetConnectionString("DefaultConnection"));
        }
    }
}
