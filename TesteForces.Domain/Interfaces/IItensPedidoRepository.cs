using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TesteFortes.Domain.Entities;

namespace TesteFortes.Domain.Interfaces
{
    public interface IItensPedidoRepository : IRepository<ItensPedido>
    {
        IEnumerable<ItensPedido> GetAll();
        IEnumerable<ItensPedido> FindByOrder(int pedidoId);
    }
}
