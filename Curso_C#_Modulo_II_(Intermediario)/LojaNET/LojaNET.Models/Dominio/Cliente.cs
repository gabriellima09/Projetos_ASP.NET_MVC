using System;
using System.Collections.Generic;
using System.Text;

namespace LojaNet.Models
{
    public class Cliente
    {
        /// <summary>
        /// tipo 'string' para criar id's independente de DB
        /// </summary>
        public string id { get; set; }
        public string nome { get; set; }
        public string email { get; set; }
        public string telefone { get; set; }
    }
}
