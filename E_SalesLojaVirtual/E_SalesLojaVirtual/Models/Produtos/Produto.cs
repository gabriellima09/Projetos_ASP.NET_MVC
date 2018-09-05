using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace E_SalesLojaVirtual.Models.Produtos
{
    public enum tipoProduto
    {
        Carro,
        Casa,
        Feminino,
        Infantil,
        Informatica,
        Livros,
        Masculino
    }

    public class Produto
    {
        public long id { get; set; }
        public string descricao { get; set; }
        public double valor { get; set; }
        public string imagem { get; set; }
        public int idTipo { get; set; }
        public string idPedido { get; set; }
    }
}