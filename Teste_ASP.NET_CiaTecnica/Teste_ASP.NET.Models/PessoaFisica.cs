using System;
using System.Collections.Generic;
using System.Text;

namespace Teste_ASP.NET.Models
{
    public class PessoaFisica : Pessoa
    {
        public string CPF { get; set; }
        public string Nome { get; set; }
        public string Sobrenome { get; set; }
        public DateTime DataNascimento { get; set; }
    }
}
