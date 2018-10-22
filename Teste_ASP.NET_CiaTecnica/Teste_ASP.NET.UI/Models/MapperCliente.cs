using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Teste_ASP.NET.Models;

namespace Teste_ASP.NET.UI.Models
{
    public class MapperCliente
    {
        public ClientePF MapClientePF(VM_Cliente c)
        {
            var cliente = new ClientePF()
            {
                Id = c.Id,
                Dados = new PessoaFisica()
                {
                    Nome = c.Nome,
                    Sobrenome = c.Sobrenome,
                    CPF = c.CPF,
                    DataNascimento = c.DataNascimento,
                    Endereco = GetEndereco(c)
                },
            };

            return cliente;
        }

        public ClientePJ MapClientePJ(VM_Cliente c)
        {
            var cliente = new ClientePJ()
            {
                Id = c.Id,
                Dados = new PessoaJuridica()
                {
                    CNPJ = c.CNPJ,
                    NomeFantasia = c.NomeFantasia,
                    RazaoSocial = c.RazaoSocial,
                    Endereco = GetEndereco(c)
                },
            };

            return cliente;
        }

        private Endereco GetEndereco(VM_Cliente c)
        {
            var endereco = new Endereco()
            {
                Bairro = c.Bairro,
                CEP = c.CEP,
                Cidade = c.Cidade,
                Complemento = c.Complemento ?? "",
                Logradouro = c.Logradouro,
                Numero = c.Numero,
                UF = c.UF
            };

            return endereco;
        }

        public VM_Cliente MapVM_Cliente(ClientePF c)
        {
            var cliente = new VM_Cliente()
            {
                TipoPessoa = TipoPessoa.Fisica,

                Id = c.Id,
                Nome = c.Dados.Nome,
                Sobrenome = c.Dados.Sobrenome,
                CPF = c.Dados.CPF,
                DataNascimento = c.Dados.DataNascimento,
                DataCadastro = c.DataCadastro,

                Bairro = c.Dados.Endereco.Bairro,
                CEP = c.Dados.Endereco.CEP,
                Cidade = c.Dados.Endereco.Cidade,
                Complemento = c.Dados.Endereco.Complemento,
                Logradouro = c.Dados.Endereco.Logradouro,
                Numero = c.Dados.Endereco.Numero,
                UF = c.Dados.Endereco.UF,
            };

            return cliente;
        }

        public VM_Cliente MapVM_Cliente(ClientePJ c)
        {
            var cliente = new VM_Cliente()
            {
                TipoPessoa = TipoPessoa.Juridica,

                Id = c.Id,
                NomeFantasia = c.Dados.NomeFantasia,
                RazaoSocial = c.Dados.RazaoSocial,
                CNPJ = c.Dados.CNPJ,
                DataCadastro = c.DataCadastro,

                Bairro = c.Dados.Endereco.Bairro,
                CEP = c.Dados.Endereco.CEP,
                Cidade = c.Dados.Endereco.Cidade,
                Complemento = c.Dados.Endereco.Complemento,
                Logradouro = c.Dados.Endereco.Logradouro,
                Numero = c.Dados.Endereco.Numero,
                UF = c.Dados.Endereco.UF,
            };

            return cliente;
        }
    }
}