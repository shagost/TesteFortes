using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TesteFortes.Application.ViewModels;

namespace TesteFortes.Application.Interfaces
{
    public interface IPedidoService
    {
        List<PedidoViewModel> Get();
        bool Post(PedidoCreateViewModel pedidoViewModel);
        PedidoViewModel GetById(int id);
        bool Put(PedidoViewModel pedidoViewModel);
        bool Delete(int id);
    }
}
