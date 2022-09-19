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
    public class FornecedorRepository : Repository<Fornecedor>, IFornecedorRepository
    {
        public FornecedorRepository(AppDbContext context) : base(context)
        {
        }

        public IEnumerable<Fornecedor> GetAll()
        {
            return DbSet;
        }

        public new bool Delete(Fornecedor fornecedor)
        {
            return this.Delete(fornecedor);
        }
    }
}
