using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TesteFortes.Application.ViewModels;

namespace TesteFortes.Application.Interfaces
{
    public interface IItensPedidoService
    {
        List<ItensPedidoViewModel> Get();
        bool Post(ItensPedidoViewModel itensPedidoViewModel);
        ItensPedidoViewModel GetById(int id);
        bool Put(ItensPedidoViewModel itensPedidoViewModel);
        bool Delete(int id);
        List<ItensPedidoViewModel> FindByOrder(int id);
    }
}
