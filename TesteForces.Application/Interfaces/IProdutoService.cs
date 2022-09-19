using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TesteFortes.Application.ViewModels;

namespace TesteFortes.Application.Interfaces
{
    public interface IProdutoService
    {
        List<ProdutoViewModel> Get();
        bool Post(ProdutoViewModel produtoViewModel);
        ProdutoViewModel GetById(int id);
        bool Put(ProdutoViewModel produtoViewModel);
        bool Delete(int id);
    }
}
