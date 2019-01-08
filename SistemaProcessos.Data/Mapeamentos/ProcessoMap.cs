using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SistemaProcessos.Data.Extensions;
using SistemaProcessos.Domain.Entidades;
using System;
using System.Collections.Generic;
using System.Text;

namespace SistemaProcessos.Data.Mapeamentos
{
    public class ProcessoMap : EntityTypeConfiguration<Processo>
    {
        public override void Map(EntityTypeBuilder<Processo> builder)
        {
            builder.Property(e => e.NumProcesso)
                .HasColumnType("varchar(15)")
                .IsRequired();

            builder.Property(e => e.Estado)
                .HasColumnType("varchar(30)")
                .IsRequired();

            builder.Property(e => e.Valor)
                .HasColumnType("decimal(10,2)")
                .IsRequired();

            builder.Property(e => e.Ativo)
                .HasColumnType("bit")
                .IsRequired();

            builder
                .HasOne(e => e.Empresa)
                .WithMany(o => o.ProcessosEmpresa)
                .HasForeignKey(e => e.IdEmpresa)
                .IsRequired();

            builder.ToTable("Processo");
        }
    }
}