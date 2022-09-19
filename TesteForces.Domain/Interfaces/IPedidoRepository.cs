using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TesteFortes.Domain.Entities;

namespace TesteFortes.Domain.Interfaces
{
    public interface IPedidoRepository : IRepository<Pedido>
    {
        IEnumerable<Pedido> GetAll();
        Pedido GetById(int id);
    }
}
