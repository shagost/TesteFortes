using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TesteFortes.Application.ViewModels
{
    public class PedidoCreateViewModel
    {
        [Required]
        public int Codigo { get; set; }
        [Required]
        public int FornecedorId { get; set; }
        public DateTime DataPedido => DateTime.Now;
    }
}
