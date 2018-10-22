using System;
using System.Collections.Generic;
using System.Text;

namespace Teste_ASP.NET.Models
{
    public abstract class Cliente 
    {
        public int Id { get; set; }
        public DateTime DataCadastro { get; set; }
    }
}
