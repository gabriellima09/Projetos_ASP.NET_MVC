using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LojaNet.Models;
using LojaNet.DAL;
using LojaNET.DAL;

namespace LojaNET.BLL
{
    public class ClienteBLL : ICliente
    {
        private ClienteDAL dal;

        public ClienteBLL()
        {
            this.dal = new ClienteDAL();
        }

        public void Alterar(Cliente cliente)
        {
            ValidarCliente(cliente);

            if (string.IsNullOrEmpty(cliente.id))
                throw new Exception("O Id do cliente não foi recuperado");

            dal.Alterar(cliente);
        }

        public void Excluir(string id)
        {
            if (string.IsNullOrEmpty(id))
                throw new Exception("O Id do cliente não foi recuperado");

            dal.Excluir(id);
        }

        public void Incluir(Cliente cliente)
        {
            ValidarCliente(cliente);

            if (string.IsNullOrEmpty(cliente.id))
                cliente.id = Guid.NewGuid().ToString();

            dal.Incluir(cliente);
        }

        private static void ValidarCliente(Cliente cliente)
        {
            if (string.IsNullOrEmpty(cliente.nome))
                throw new ApplicationException("O nome do cliente deve ser informado");
        }

        public Cliente ObterPorEmail(string email)
        {
            throw new NotImplementedException();
        }

        public Cliente ObterPorId(string id)
        {
            return dal.ObterPorId(id);
        }

        public List<Cliente> ObterTodos()
        {
            return dal.ObterTodos();
        }
    }
}
