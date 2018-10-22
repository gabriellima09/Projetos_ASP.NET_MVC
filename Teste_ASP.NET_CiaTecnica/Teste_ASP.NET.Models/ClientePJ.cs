using System;
using System.Collections.Generic;
using System.Text;

namespace Teste_ASP.NET.Models
{
    public class ClientePJ : Cliente
    {
        public PessoaJuridica Dados { get; set; }
    }
}
