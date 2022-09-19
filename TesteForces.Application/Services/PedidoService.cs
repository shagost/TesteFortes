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
    public class PedidoService : IPedidoService
    {
        protected readonly IPedidoRepository _pedidoRepository;
        private readonly IMapper _mapper;

        public PedidoService(IPedidoRepository pedidoRepository, IMapper mapper)
        {
            _pedidoRepository = pedidoRepository;
            _mapper = mapper;
        }

        public List<PedidoViewModel> Get()
        {
            List<PedidoViewModel> viewModel = new List<PedidoViewModel>();
            IEnumerable<Pedido> Pedido = _pedidoRepository.GetAll();
            viewModel = _mapper.Map<List<PedidoViewModel>>(Pedido); 

            return viewModel;
        }

        public bool Post(PedidoCreateViewModel pedidoViewModel)
        {
            //if (pedidoViewModel.PedidoId != 0)
            //    throw new Exception("Id is not empty!");

            Validator.ValidateObject(pedidoViewModel, new ValidationContext(pedidoViewModel), true);

            Pedido pedido = _mapper.Map<Pedido>(pedidoViewModel);
            _pedidoRepository.Create(pedido);
            return true;
        }

        public PedidoViewModel GetById(int id)
        {
            if(id <= 0)
                throw new Exception("Id is not valid!");

            var pedido = _pedidoRepository.GetById(id);
            //var pedido = _pedidoRepository.Find(x => x.PedidoId == id);
            if (pedido == null)
                throw new Exception("Pedido not found!");
            return _mapper.Map<PedidoViewModel>(pedido);
        }

        public bool Put(PedidoViewModel pedidoViewModel)
        {
            if(pedidoViewModel.PedidoId == 0)
                throw new Exception("Pedido not found!");

            var pedido = _pedidoRepository.Find(x => x.PedidoId == pedidoViewModel.PedidoId);
            if (pedido == null)
                throw new Exception("Pedido not found!");

            pedido = _mapper.Map<Pedido>(pedidoViewModel);
            _pedidoRepository.Update(pedido);
            return true;
        }

        public bool Delete(int id)
        {
            var pedido = _pedidoRepository.Find(x => x.PedidoId == id);
            if (pedido == null)
                throw new Exception("Pedido not found!");
            return _pedidoRepository.Delete(pedido);
        }
    }
}
