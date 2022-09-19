using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TesteFortes.Data.Context;
using TesteFortes.Domain.Entities;
using TesteFortes.Domain.Interfaces;

namespace TesteFortes.Data.Repositories
{
    public class PedidoRepository : Repository<Pedido>, IPedidoRepository
    {
        public PedidoRepository(AppDbContext context) : base(context)
        {
        }

        public IEnumerable<Pedido> GetAll()
        {
            var all = DbSet.AsNoTracking().Include("ItensPedido").Include(y => y.Fornecedor);
            return all;
        }

        public new bool Delete(Pedido pedido)
        {
            return this.Delete(pedido);
        }

        public Pedido GetById(int id)
        {
            var pedido = GetAll().FirstOrDefault(x => x.PedidoId == id);
            return pedido;
        }
    }
}
