using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Teste_ASP.NET.Models;

namespace Teste_ASP.NET.UI.Models
{
    public class VM_Cliente
    {
        public int Id { get; set; }
        public DateTime DataCadastro { get; set; }

        
        public TipoPessoa TipoPessoa { get; set; }

        
        public string CPF { get; set; }
        public string Nome { get; set; }
        public string Sobrenome { get; set; }
        public DateTime DataNascimento { get; set; }

        
        public string CNPJ { get; set; }
        public string RazaoSocial { get; set; }
        public string NomeFantasia { get; set; }

        
        public string CEP { get; set; }
        public string Logradouro { get; set; }
        public int Numero { get; set; }
        public string Complemento { get; set; }
        public string Bairro { get; set; }
        public string Cidade { get; set; }
        public Estados UF { get; set; }
    }
}