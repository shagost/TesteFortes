using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using TesteFortes.Application.ViewModels;
using TesteFortes.Domain.Entities;

namespace TesteFortes.Application.AutoMapper
{
    public class AutoMapperConfig : Profile
    {
        public AutoMapperConfig()
        {
            CreateMap<UserViewModel, User>();
            CreateMap<User, UserViewModel>();
            
            CreateMap<UserUpdateViewModel, User>();
            CreateMap<User, UserUpdateViewModel>();

            CreateMap<ProdutoViewModel, Produto>();
            CreateMap<Produto, ProdutoViewModel>();
            
            CreateMap<FornecedorViewModel, Fornecedor>();
            CreateMap<Fornecedor, FornecedorViewModel>();
            
            //CreateMap<PedidoViewModel, Pedido>();
            //CreateMap<Pedido, PedidoViewModel>();

            CreateMap<PedidoCreateViewModel, Pedido>();
            CreateMap<Pedido, PedidoCreateViewModel>();

            CreateMap<ItensPedidoViewModel, ItensPedido>();
            CreateMap<ItensPedido, ItensPedidoViewModel>();

            CreateMap<PedidoViewModel, Pedido>().ForMember(dest => dest.ItensPedido,
                opt => opt.MapFrom(src => src.ItensPedido));

            CreateMap<Pedido, PedidoViewModel>().ForMember(dest => dest.ItensPedido,
                opt => opt.MapFrom(src => src.ItensPedido));


        }
    }
}
