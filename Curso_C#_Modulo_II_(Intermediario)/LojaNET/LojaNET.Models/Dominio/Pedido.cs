using System;
using System.Collections.Generic;
using System.Text;

namespace LojaNet.Models
{
    public class Pedido
    {
        public int id { get; set; }
        public DateTime dataPedido { get; set; }
        public Cliente cliente { get; set; }
        public List<Item> itens { get; set; }

        public FormaPagamento formaPagamento { get; set; }

        public class Item
        {
            public int ordem { get; set; }
            public Produto produto { get; set; }
            public int quantidade { get; set; }
            public decimal preco { get; set; }
        }
    }
}
