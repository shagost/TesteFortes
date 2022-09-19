using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TesteFortes.Application.ViewModels
{
    public class ProdutoViewModel
    {
        public int ProdutoId { get; set; }
        [Required]
        public string Codigo { get; set; }
        [Required]
        public string Descricao { get; set; }
        [Required]
        public decimal Valor { get; set; }
    }
}
