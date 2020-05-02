using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Compras.Web.Models
{
    public class Produto
    {
        public long? ProdutoId { get; set; }
        public string Descricao { get; set; }
        public string Unidade { get; set; }
        public int Qtd { get; set; }
        public decimal Preco { get; set; }
    }
}
