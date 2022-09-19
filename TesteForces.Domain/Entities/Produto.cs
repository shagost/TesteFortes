using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TesteFortes.Domain.Entities
{
    public class Produto
    {
        public int ProdutoId { get; set; }
        public string Codigo { get; set; }
        public string Descricao { get; set; }
        public DateTime DataCadastro { get; set; }
        public decimal Valor { get; set; }
        public virtual ICollection<ItensPedido> ItensPedido { get; set; }
    }
}
