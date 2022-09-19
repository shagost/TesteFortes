using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TesteFortes.Domain.Entities
{
    public class Pedido
    {
        public int PedidoId { get; set; }
        public int Codigo { get; set; }
        public DateTime DataPedido { get; set; }
        public ICollection<ItensPedido> ItensPedido { get; set; }
        //public int Quantidade { get; set; }
        public int FornecedorId { get; set; }
        public Fornecedor Fornecedor { get; set; }
        //public decimal ValorTotal { get; set; }

    }
}
