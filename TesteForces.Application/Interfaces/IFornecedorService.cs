using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TesteFortes.Application.ViewModels;

namespace TesteFortes.Application.Interfaces
{
    public interface IFornecedorService
    {
        List<FornecedorViewModel> Get();
        bool Post(FornecedorViewModel fornecedorViewModel);
        FornecedorViewModel GetById(int id);
        bool Put(FornecedorViewModel fornecedorViewModel);
        bool Delete(int id);
    }
}
