using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SistemaProcessos.Data.Extensions;
using SistemaProcessos.Domain.Entidades;

namespace SistemaProcessos.Data.Mapeamentos
{
    public class EmpresaMap : EntityTypeConfiguration<Empresa>
    {
        public override void Map(EntityTypeBuilder<Empresa> builder)
        {

            builder.Property(e => e.Cnpj)
                .HasColumnType("varchar(15)")
                .IsRequired();

            builder.Property(e => e.Nome)
                .HasColumnType("varchar(150)")
                .IsRequired();

            builder.Property(e => e.Estado)
                .HasColumnType("varchar(30)")
                .IsRequired();

            builder.ToTable("Empresa");
        }
    }
}
