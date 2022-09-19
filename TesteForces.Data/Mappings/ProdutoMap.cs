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
    public class ProdutoMap : IEntityTypeConfiguration<Produto>
    {
        public void Configure(EntityTypeBuilder<Produto> builder)
        {
            builder.HasKey(p => p.ProdutoId);
            builder.Property(p => p.ProdutoId).IsRequired();
            builder.Property(p => p.Codigo)
                .HasMaxLength(10)
                .HasColumnType("varchar")
                .IsRequired();
            builder.Property(p => p.Descricao)
                .HasMaxLength(150)
                .HasColumnType("varchar")
                .IsRequired();
            builder.Property(p => p.Valor)
                .HasColumnType("decimal")
                .HasPrecision(18,2)
                .IsRequired();
        }
    }
}
