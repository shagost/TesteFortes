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
    public class ItensPedidoRepository : Repository<ItensPedido>, IItensPedidoRepository
    {
        public ItensPedidoRepository(AppDbContext context) : base(context)
        {
        }

        public IEnumerable<ItensPedido> GetAll()
        {
            return DbSet.Include(x => x.Produto);
        }

        public IEnumerable<ItensPedido> FindByOrder(int pedidoId)
        {
            return DbSet.Where(x => x.PedidoId == pedidoId);
        }

        public new bool Delete(ItensPedido itens)
        {
            return this.Delete(itens);
        }
    }
}
