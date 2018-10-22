using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Teste_ASP.NET.Models;

namespace Teste_ASP.NET.DAL
{
    public class ClienteDAO : ICliente
    {
        public void Alterar(ClientePF cliente)
        {
            DBHelper.ExecuteNonQuery("SP_CLIENTE_UPDATE",
                "@Id", cliente.Id,
                "@TipoPessoa", (int)TipoPessoa.Fisica,

                "@Nome", cliente.Dados.Nome,
                "@Sobrenome", cliente.Dados.Sobrenome,
                "@CPF", cliente.Dados.CPF,
                "@DataNascimento", cliente.Dados.DataNascimento,

                "@Bairro", cliente.Dados.Endereco.Bairro,
                "@CEP", cliente.Dados.Endereco.CEP,
                "@Cidade", cliente.Dados.Endereco.Cidade,
                "@Complemento", cliente.Dados.Endereco.Complemento,
                "@Logradouro", cliente.Dados.Endereco.Logradouro,
                "@Numero", cliente.Dados.Endereco.Numero,
                "@UF", (int)cliente.Dados.Endereco.UF
                );
        }

        public void Alterar(ClientePJ cliente)
        {
            DBHelper.ExecuteNonQuery("SP_CLIENTE_UPDATE",
                "@Id", cliente.Id,
                "@TipoPessoa", (int)TipoPessoa.Juridica,

                "@NomeFantasia", cliente.Dados.NomeFantasia,
                "@RazaoSocial", cliente.Dados.RazaoSocial,
                "@CNPJ", cliente.Dados.CNPJ,

                "@Bairro", cliente.Dados.Endereco.Bairro,
                "@CEP", cliente.Dados.Endereco.CEP,
                "@Cidade", cliente.Dados.Endereco.Cidade,
                "@Complemento", cliente.Dados.Endereco.Complemento,
                "@Logradouro", cliente.Dados.Endereco.Logradouro,
                "@Numero", cliente.Dados.Endereco.Numero,
                "@UF", (int)cliente.Dados.Endereco.UF
                );
        }

        public void Excluir(int id)
        {
            DBHelper.ExecuteNonQuery("SP_CLIENTE_DELETE", "@Id", id);
        }

        public void Incluir(ClientePF cliente)
        {
            DBHelper.ExecuteNonQuery("SP_CLIENTE_INSERT",
                "@TipoPessoa", (int)TipoPessoa.Fisica,

                "@Nome", cliente.Dados.Nome,
                "@Sobrenome", cliente.Dados.Sobrenome,
                "@CPF", cliente.Dados.CPF,
                "@DataNascimento", cliente.Dados.DataNascimento,

                "@Bairro", cliente.Dados.Endereco.Bairro,
                "@CEP", cliente.Dados.Endereco.CEP,
                "@Cidade", cliente.Dados.Endereco.Cidade,
                "@Complemento", cliente.Dados.Endereco.Complemento,
                "@Logradouro", cliente.Dados.Endereco.Logradouro,
                "@Numero", cliente.Dados.Endereco.Numero,
                "@UF", (int)cliente.Dados.Endereco.UF
                );
        }

        public void Incluir(ClientePJ cliente)
        {
            DBHelper.ExecuteNonQuery("SP_CLIENTE_INSERT",
                "@TipoPessoa", (int)TipoPessoa.Juridica,

                "@NomeFantasia", cliente.Dados.NomeFantasia,
                "@RazaoSocial", cliente.Dados.RazaoSocial,
                "@CNPJ", cliente.Dados.CNPJ,
                
                "@Bairro", cliente.Dados.Endereco.Bairro,
                "@CEP", cliente.Dados.Endereco.CEP,
                "@Cidade", cliente.Dados.Endereco.Cidade,
                "@Complemento", cliente.Dados.Endereco.Complemento,
                "@Logradouro", cliente.Dados.Endereco.Logradouro,
                "@Numero", cliente.Dados.Endereco.Numero,
                "@UF", (int)cliente.Dados.Endereco.UF
                );
        }

        public Cliente ObterPorId(int id)
        {
            Cliente cliente = null;

            using (var reader = DBHelper.ExecuteReader("SP_CLIENTE_SELECT_BY_ID", "@Id", id))
            {
                if (reader.Read())
                {
                    cliente = ObterClienteReader(reader);
                }
            }

            return cliente;
        }

        public List<Cliente> ObterTodos()
        {
            var list = new List<Cliente>();

            using (var reader = DBHelper.ExecuteReader("SP_CLIENTE_SELECT"))
            {
                while (reader.Read())
                {
                    Cliente cliente = ObterClienteReader(reader);

                    list.Add(cliente);
                }
            }

            return list;
        }

        private static Cliente ObterClienteReader(System.Data.IDataReader reader)
        {
            var tipo = (TipoPessoa)reader["TipoPessoa"];

            if (tipo == TipoPessoa.Fisica)
            {
                var cliente = new ClientePF();

                cliente.Dados = new PessoaFisica();

                cliente.Id = Convert.ToInt32(reader["Id"]);
                cliente.DataCadastro = Convert.ToDateTime(reader["DataCadastro"]);
                cliente.Dados.CPF = Convert.ToString(reader["CPF"]);
                cliente.Dados.DataNascimento = Convert.ToDateTime(reader["DataNascimento"]);
                cliente.Dados.Nome = Convert.ToString(reader["Nome"]);
                cliente.Dados.Sobrenome = Convert.ToString(reader["Sobrenome"]);

                cliente.Dados.Endereco = new Endereco();

                cliente.Dados.Endereco.Bairro = Convert.ToString(reader["Bairro"]);
                cliente.Dados.Endereco.CEP = Convert.ToString(reader["CEP"]);
                cliente.Dados.Endereco.Cidade = Convert.ToString(reader["Cidade"]);
                cliente.Dados.Endereco.Complemento = Convert.ToString(reader["Complemento"]);
                cliente.Dados.Endereco.Logradouro = Convert.ToString(reader["Logradouro"]);
                cliente.Dados.Endereco.Numero = Convert.ToInt32(reader["Numero"]);
                cliente.Dados.Endereco.UF = (Estados)reader["UF"];

                return cliente;
            }
            else if (tipo == TipoPessoa.Juridica)
            {
                var cliente = new ClientePJ();

                cliente.Dados = new PessoaJuridica();

                cliente.Id = Convert.ToInt32(reader["Id"]);
                cliente.DataCadastro = Convert.ToDateTime(reader["DataCadastro"]);
                cliente.Dados.CNPJ = Convert.ToString(reader["CNPJ"]);
                cliente.Dados.NomeFantasia = Convert.ToString(reader["NomeFantasia"]);
                cliente.Dados.RazaoSocial = Convert.ToString(reader["RazaoSocial"]);

                cliente.Dados.Endereco = new Endereco();

                cliente.Dados.Endereco.Bairro = Convert.ToString(reader["Bairro"]);
                cliente.Dados.Endereco.CEP = Convert.ToString(reader["CEP"]);
                cliente.Dados.Endereco.Cidade = Convert.ToString(reader["Cidade"]);
                cliente.Dados.Endereco.Complemento = Convert.ToString(reader["Complemento"]);
                cliente.Dados.Endereco.Logradouro = Convert.ToString(reader["Logradouro"]);
                cliente.Dados.Endereco.Numero = Convert.ToInt32(reader["Numero"]);
                cliente.Dados.Endereco.UF = (Estados)reader["UF"];

                return cliente;
            }
            else
            {
                throw new Exception("Não foi possível resgatar o cliente");
            }
        }
    }
}
