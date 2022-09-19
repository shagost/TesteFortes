using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TesteFortes.Application.ViewModels
{
    public class PedidoViewModel
    {
        public int PedidoId { get; set; }
        [Required]
        public int Codigo { get; set; }
        public DateTime DataPedido { get; set; }
        public virtual ICollection<ItensPedidoViewModel> ItensPedido { get; set; }
        [Required]
        public int Quantidade { get; set; }
        public FornecedorViewModel Fornecedor { get; set; }
        public decimal ValorTotal
        {
            get
            {
                decimal total = 0;
                foreach (var item in ItensPedido)
                {
                    total += (item.Quantidade * item.ValorUnitario);
                }
                return total;
            }
        }
    }
}
