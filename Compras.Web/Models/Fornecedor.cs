using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Compras.Web.Models
{
    public class Fornecedor
    {
        public long? FornecedorId { get; set; }
        public string Nome { get; set; }
        public string RazaoSocial { get; set; }
        public string CpfCnpj { get; set; }



    }
}
