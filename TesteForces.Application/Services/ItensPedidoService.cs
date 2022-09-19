using AutoMapper;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TesteFortes.Application.Interfaces;
using TesteFortes.Application.ViewModels;
using TesteFortes.Domain.Entities;
using TesteFortes.Domain.Interfaces;
using ValidationContect = System.ComponentModel.DataAnnotations.ValidationContext;

namespace TesteFortes.Application.Services
{
    public class ItensPedidoService : IItensPedidoService
    {
        protected readonly IItensPedidoRepository _itensPedidoRepository;
        private readonly IMapper _mapper;

        public ItensPedidoService(IItensPedidoRepository itensPedidoRepositor, IMapper mapper)
        {
            _itensPedidoRepository = itensPedidoRepositor;
            _mapper = mapper;
        }

        public List<ItensPedidoViewModel> Get()
        {
            List<ItensPedidoViewModel> viewModel = new List<ItensPedidoViewModel>();
            IEnumerable<ItensPedido> Pedido = _itensPedidoRepository.GetAll();
            viewModel = _mapper.Map<List<ItensPedidoViewModel>>(Pedido); 

            return viewModel;
        }

        public bool Post(ItensPedidoViewModel itensPedidoViewModel)
        {
            if (itensPedidoViewModel.ItensPedidoId != 0)
                throw new Exception("Id is not empty!");

            Validator.ValidateObject(itensPedidoViewModel, new ValidationContext(itensPedidoViewModel), true);

            ItensPedido itens = _mapper.Map<ItensPedido>(itensPedidoViewModel);
            _itensPedidoRepository.Create(itens);
            return true;
        }

        public ItensPedidoViewModel GetById(int id)
        {
            if(id <= 0)
                throw new Exception("Id is not valid!");

            var item = _itensPedidoRepository.Find(x => x.PedidoId == id);
            if (item == null)
                throw new Exception("Item not found!");
            return _mapper.Map<ItensPedidoViewModel>(item);
        }

        public List<ItensPedidoViewModel> FindByOrder(int id)
        {
            if (id <= 0)
                throw new Exception("Id is not valid!");

            var item = _itensPedidoRepository.FindByOrder(id);
            if (item == null)
                throw new Exception("Item not found!");
            return _mapper.Map<List<ItensPedidoViewModel>>(item);
        }

        public bool Put(ItensPedidoViewModel itensPedidoViewModel)
        {
            if(itensPedidoViewModel.ItensPedidoId == 0)
                throw new Exception("Item not found!");

            var item = _itensPedidoRepository.Find(x => x.PedidoId == itensPedidoViewModel.ItensPedidoId);
            if (item == null)
                throw new Exception("Item not found!");

            item = _mapper.Map<ItensPedido>(itensPedidoViewModel);
            _itensPedidoRepository.Update(item);
            return true;
        }

        public bool Delete(int id)
        {
            var pedido = _itensPedidoRepository.Find(x => x.PedidoId == id);
            if (pedido == null)
                throw new Exception("Item not found!");
            return _itensPedidoRepository.Delete(pedido);
        }
    }
}
