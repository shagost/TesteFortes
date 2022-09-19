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
    public class PedidoMap : IEntityTypeConfiguration<Pedido>
    {
        public void Configure(EntityTypeBuilder<Pedido> builder)
        {
            builder.HasKey(p => p.PedidoId);
            builder.Property(p => p.PedidoId).IsRequired();
            builder.Property(p => p.Codigo).IsRequired();
            //builder.Property(p => p.Quantidade).IsRequired();
            //builder.Property(p => p.ValorTotal)
            //    .HasColumnType("decimal")
            //    .HasPrecision(18, 2)
            //    .IsRequired();
            builder.HasMany(c => c.ItensPedido)
                .WithOne()
                .HasForeignKey(f => f.PedidoId)
                .IsRequired();
            builder.HasOne(c => c.Fornecedor)
                .WithMany()
                .HasForeignKey(k => k.FornecedorId)
                .IsRequired();
            builder.Navigation(x => x.ItensPedido).AutoInclude();
            builder.Navigation(x => x.Fornecedor).AutoInclude();




        }
    }
}
