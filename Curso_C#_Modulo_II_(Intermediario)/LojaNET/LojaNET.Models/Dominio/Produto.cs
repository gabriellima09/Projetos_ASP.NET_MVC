using System;
using System.Collections.Generic;
using System.Text;

namespace LojaNet.Models
{
    public class Produto
    {
        /// <summary>
        /// tipo 'string' para criar id's independente de DB
        /// </summary>
        public string id { get; set; }
        public string nome { get; set; }
        public decimal preco { get; set; }
        public int estoque { get; set; }
    }
}
