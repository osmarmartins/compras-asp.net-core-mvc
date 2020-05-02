using Compras.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Compras.Web.Data
{
    public static class ComprasDbInitializer
    {
        public static void Initializer(DataContext context)
        {
            context.Database.EnsureCreated();

            if (context.Produtos.Any())
            {
                return;
            }

            var produtos = new Produto[]
            {
                new Produto { Descricao="Teclado ConfortFingers", Unidade="un", Qtd=10, Preco=235},
                new Produto { Descricao="Mouse HighDefinition", Unidade="un", Qtd=8, Preco=132},
                new Produto { Descricao="Mesa digitalizadora PerformPlus", Unidade="un", Qtd=55, Preco=1289},
            };

            foreach(Produto p in produtos)
            {
                context.Produtos.Add(p);
            }

            var fornecedores = new Fornecedor[]
            {
            new Fornecedor()
            {
                FornecedorID = 1,
                Nome = "Confecção ABC",
                RazaoSocial = "Confecção ABC ME",
                CpfCnpj = "11.111.111/0001-11"
            },
            new Fornecedor()
            {
                FornecedorID = 2,
                Nome = "Metalúrgica XYZ",
                RazaoSocial = "Metalúrgica XYZ Ltda",
                CpfCnpj = "22.222.222/0001-22"
            },
            new Fornecedor()
            {
                FornecedorID = 3,
                Nome = "Seu Zé da Bodega",
                RazaoSocial = "Zé Maria ME",
                CpfCnpj = "111.111.111-11"
            },
            new Fornecedor()
            {
                FornecedorID = 4,
                Nome = "Locadora VHS",
                RazaoSocial = "Locação & Edição de vídeos Ltda",
                CpfCnpj = "44.444.444/0001-44"
            },
            new Fornecedor()
            {
                FornecedorID = 5,
                Nome = "Padaria Pão de Mel",
                RazaoSocial = "Cooperativa Padarias da Capital",
                CpfCnpj = "55.555.555/0001-55"
            },

            };

            foreach (Fornecedor f in fornecedores)
            {
                context.Fornecedores.Add(f);
            }

            context.SaveChanges();
        }
    }
}
