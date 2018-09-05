using E_SalesLojaVirtual.Models.AutenticacaoCliente;
using E_SalesLojaVirtual.Models.Produtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace E_SalesLojaVirtual.Models.CarrinhoDeCompras
{
    public class Carrinho
    {
        public Cliente cliente { get; set; }
        public List<Produto> produtos { get; set; }
    }
}