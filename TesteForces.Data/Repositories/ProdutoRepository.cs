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
    public class ProdutoRepository : Repository<Produto>, IProdutoRepository
    {
        public ProdutoRepository(AppDbContext context) : base(context)
        {
        }

        public IEnumerable<Produto> GetAll()
        {
            return DbSet;
        }

        public new bool Delete(Produto produto)
        {
            return this.Delete(produto);
        }
    }
}
