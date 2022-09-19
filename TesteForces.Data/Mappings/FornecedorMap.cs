using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TesteFortes.Domain.Entities;

namespace TesteFortes.Data.Mappings
{
    public class FornecedorMap : IEntityTypeConfiguration<Fornecedor>
    {
        public void Configure(EntityTypeBuilder<Fornecedor> builder)
        {
            builder.HasKey(p => p.FornecedorId);
            builder.Property(p => p.FornecedorId).IsRequired();
            builder.Property(p => p.RazaoSocial)
                .HasMaxLength(150)
                .HasColumnType("varchar")
                .IsRequired();
            builder.Property(p => p.CNPJ)
                .HasMaxLength(14)
                .HasColumnType("varchar")
                .IsRequired();
            builder.Property(p => p.UF)
                .HasMaxLength(2)
                .HasColumnType("varchar")
                .IsRequired();
            builder.Property(p => p.EmailContato)
                .HasMaxLength(100)
                .HasColumnType("varchar")
                .IsRequired();
            builder.Property(p => p.NomeContato)
                .HasMaxLength(100)
                .HasColumnType("varchar")
                .IsRequired();



        }
    }
}
