using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TesteFortes.Domain.Entities;
using TesteFortes.Domain.Models;

namespace TesteFortes.Data.Extensions
{
    public static class ModelBuilderExtension
    {
        public static ModelBuilder ApplyGlobalConfigs(this ModelBuilder builder)
        {
            foreach (var entityType in builder.Model.GetEntityTypes())
            {
                foreach (var prop in entityType.GetProperties())
                {
                    switch (prop.Name)
                    {
                        case nameof(Entity.Id):
                            prop.IsKey();
                            break;
                        case nameof(Entity.UpdatedData):
                            prop.IsNullable = true;
                            break;
                        case nameof(Entity.CreatedDate):
                            prop.SetDefaultValue(DateTime.Now);
                            break;
                        case nameof(Entity.IsActive):
                            prop.IsNullable = false;
                            prop.SetDefaultValue(true);
                            break;
                        default:
                            break;
                    }
                }
            }

            return builder;
        }

        public static ModelBuilder SeedData(this ModelBuilder builder)
        {
            builder.Entity<User>()
                .HasData(
                    new User
                    {
                        UserId = 1,
                        Name = "Silvio Agostinho",
                        CreatedDate = new DateTime(2022, 9, 16),
                        IsActive = true,
                        UpdatedData = null
                    }
                );

            builder.Entity<Produto>()
                .HasData(
                    new Produto
                    {
                        ProdutoId = 1,
                        Codigo = "AX001",
                        DataCadastro = DateTime.Now,
                        Descricao = "Monitor HDTV 20 Genérico",
                        Valor = 405.99M
                    },
                    new Produto
                    {
                        ProdutoId = 2,
                        Codigo = "AX301",
                        DataCadastro = DateTime.Now,
                        Descricao = "Webcam Stylus 1080p",
                        Valor = 62.90M
                    },
                    new Produto
                    {
                        ProdutoId = 3,
                        Codigo = "BC401",
                        DataCadastro = DateTime.Now,
                        Descricao = "Mesa escritório 1,60 Prime",
                        Valor = 399.00M
                    },
                    new Produto
                    {
                        ProdutoId = 4,
                        Codigo = "BD112",
                        DataCadastro = DateTime.Now,
                        Descricao = "Mouse Microsoft 4 botões",
                        Valor = 110.00M
                    }
                );

            builder.Entity<Fornecedor>()
                .HasData(
                    new Fornecedor
                    {
                        FornecedorId = 1,
                        CNPJ = "00123456000190",
                        RazaoSocial = "Atlas Suplimentos de Informática Ltda",
                        UF = "SP",
                        NomeContato = "Josias Benedito Silva",
                        EmailContato = "jsilva@atlasinf.com.br"
                    }
                );

            return builder;
        }
    }
}
