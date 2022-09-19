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
    public class ProdutoService : IProdutoService
    {
        protected readonly IProdutoRepository _produtoRepository;
        protected readonly IItensPedidoRepository _itensRepository;
        private readonly IMapper _mapper;

        public ProdutoService(IProdutoRepository produtoRepository, IMapper mapper, IItensPedidoRepository itensRepository)
        {
            _produtoRepository = produtoRepository;
            _mapper = mapper;
            _itensRepository = itensRepository;
        }

        public List<ProdutoViewModel> Get()
        {
            List<ProdutoViewModel> viewModel = new List<ProdutoViewModel>();
            IEnumerable<Produto> users = _produtoRepository.GetAll();
            viewModel = _mapper.Map<List<ProdutoViewModel>>(users); 

            return viewModel;
        }

        public bool Post(ProdutoViewModel produtoViewModel)
        {
            if (produtoViewModel.ProdutoId != 0)
                throw new Exception("Id is not empty!");

            Validator.ValidateObject(produtoViewModel, new ValidationContext(produtoViewModel), true);

            Produto produto = _mapper.Map<Produto>(produtoViewModel);
            _produtoRepository.Create(produto);
            return true;
        }

        public ProdutoViewModel GetById(int id)
        {
            if(id <= 0)
                throw new Exception("Id is not valid!");

            var prod = _produtoRepository.Find(x => x.ProdutoId == id);
            if (prod == null)
                throw new Exception("Produto not found!");
            return _mapper.Map<ProdutoViewModel>(prod);
        }

        public bool Put(ProdutoViewModel produtoViewModel)
        {
            if(produtoViewModel.ProdutoId == 0)
                throw new Exception("Produto not found!");

            var prod = _produtoRepository.Find(x => x.ProdutoId == produtoViewModel.ProdutoId);
            if (prod == null)
                throw new Exception("Produto not found!");

            prod = _mapper.Map<Produto>(produtoViewModel);
            _produtoRepository.Update(prod);
            return true;
        }

        public bool Delete(int id)
        {
            var prod = _produtoRepository.Find(x => x.ProdutoId == id);
            if (prod == null)
                throw new Exception("Produto not found!");

            if (_itensRepository.Find(x => x.ProdutoId == id) != null)
                return false;

            return _produtoRepository.Delete(prod);
        }
    }
}
