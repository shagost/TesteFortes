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
    public class ItensPedidoMap : IEntityTypeConfiguration<ItensPedido>
    {
        public void Configure(EntityTypeBuilder<ItensPedido> builder)
        {
            builder.HasKey(p => p.ItensPedidoId);
            builder.Property(p => p.ItensPedidoId).IsRequired();
            builder.Property(p => p.Quantidade).IsRequired();
            builder.Property(p => p.ValorUnitario)
                .HasColumnType("decimal")
                .HasPrecision(18, 2)
                .IsRequired();
            builder.HasOne(p => p.Produto)
                .WithMany(c => c.ItensPedido)
                .HasForeignKey(k => k.ProdutoId)
                .IsRequired();

        }
    }
}
