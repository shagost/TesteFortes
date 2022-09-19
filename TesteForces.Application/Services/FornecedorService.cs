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
    public class FornecedorService : IFornecedorService
    {
        protected readonly IFornecedorRepository _fornecedorRepository;
        protected readonly IPedidoRepository _pedidoRepository;
        private readonly IMapper _mapper;

        public FornecedorService(IFornecedorRepository fornecedorRepository, IMapper mapper, IPedidoRepository pedidoRepository)
        {
            _fornecedorRepository = fornecedorRepository;
            _mapper = mapper;
            _pedidoRepository = pedidoRepository;
        }

        public List<FornecedorViewModel> Get()
        {
            List<FornecedorViewModel> viewModel = new List<FornecedorViewModel>();
            IEnumerable<Fornecedor> fornecedor = _fornecedorRepository.GetAll();
            viewModel = _mapper.Map<List<FornecedorViewModel>>(fornecedor); 

            return viewModel;
        }

        public bool Post(FornecedorViewModel userViewModel)
        {
            if (userViewModel.FornecedorId != 0)
                throw new Exception("Id is not empty!");

            Validator.ValidateObject(userViewModel, new ValidationContext(userViewModel), true);

            Fornecedor fornecedor = _mapper.Map<Fornecedor>(userViewModel);
            _fornecedorRepository.Create(fornecedor);
            return true;
        }

        public FornecedorViewModel GetById(int id)
        {
            if(id <= 0)
                throw new Exception("Id is not valid!");

            var fornecedor = _fornecedorRepository.Find(x => x.FornecedorId == id);
            if (fornecedor == null)
                throw new Exception("Fornecedor not found!");
            return _mapper.Map<FornecedorViewModel>(fornecedor);
        }

        public bool Put(FornecedorViewModel fornecedorViewModel)
        {
            if(fornecedorViewModel.FornecedorId == 0)
                throw new Exception("Fornecedor not found!");

            var fornecedor = _fornecedorRepository.Find(x => x.FornecedorId == fornecedorViewModel.FornecedorId);
            if (fornecedor == null)
                throw new Exception("Fornecedor not found!");

            fornecedor = _mapper.Map<Fornecedor>(fornecedorViewModel);
            _fornecedorRepository.Update(fornecedor);
            return true;
        }

        public bool Delete(int id)
        {
            var fornecedor = _fornecedorRepository.Find(x => x.FornecedorId == id);
            if (fornecedor == null)
                throw new Exception("Fornecedor not found!");

            if (_pedidoRepository.Find(x => x.FornecedorId == id) != null)
                return false;

            return _fornecedorRepository.Delete(fornecedor);
        }
    }
}
