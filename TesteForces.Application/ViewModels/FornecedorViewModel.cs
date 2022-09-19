using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TesteFortes.Application.ViewModels
{
    public class FornecedorViewModel
    {
        public int FornecedorId { get; set; }

        [Required]
        public string RazaoSocial { get; set; }
        [Required]
        public string CNPJ { get; set; }
        [Required]
        public string UF { get; set; }
        [Required]
        public string EmailContato { get; set; }
        [Required]
        public string NomeContato { get; set; }
    }
}
