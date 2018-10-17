using System;
using System.Collections.Generic;
using System.Text;
using LojaNet.Models;
using LojaNET.DAL;

namespace LojaNet.DAL
{
    public class ClienteDAL : ICliente
    {
        public void Alterar(Cliente cliente)
        {
            DBHelper.ExecuteNonQuery("SP_CLIENTE_UPDATE",
                "@id", cliente.id,
                "@nome", cliente.nome,
                "@email", cliente.email,
                "@telefone", cliente.telefone
                );
        }

        public void Excluir(string id)
        {
            DBHelper.ExecuteNonQuery("SP_CLIENTE_DELETE", "@id", id);
        }

        public void Incluir(Cliente cliente)
        {
            DBHelper.ExecuteNonQuery("SP_CLIENTE_INSERT",
                "@id", cliente.id,
                "@nome", cliente.nome,
                "@email", cliente.email,
                "@telefone", cliente.telefone
                );
        }

        public Cliente ObterPorEmail(string email)
        {
            throw new NotImplementedException();
        }

        public Cliente ObterPorId(string id)
        {
            Cliente cliente = null;

            using (var reader = DBHelper.ExecuteReader("SP_CLIENTE_SELECT_BY_ID", "@id", id))
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
            var cliente = new Cliente();

            cliente.id = Convert.ToString(reader["id"]);
            cliente.nome = Convert.ToString(reader["nome"]);
            cliente.email = Convert.ToString(reader["email"]);
            cliente.telefone = Convert.ToString(reader["telefone"]);
            return cliente;
        }
    }
}
