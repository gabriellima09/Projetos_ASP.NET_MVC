using LojaNET.BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace LojaNET.Services
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "ConsultaCliente" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select ConsultaCliente.svc or ConsultaCliente.svc.cs at the Solution Explorer and start debugging.
    public class ConsultaCliente : IConsultaCliente
    {
        public ClienteInfo ConsultarPorEmail(string chave, string email)
        {
            if (chave != "123")
                return null;

            ClienteInfo clienteInfo = null;

            var bll = new ClienteBLL();
            var cliente = bll.ObterPorEmail(email);

            if (cliente != null)
            {
                clienteInfo = new ClienteInfo() { nome = cliente.nome, email = cliente.email, telefone = cliente.telefone };
            }
            else
            {
                return null;
            }

            return clienteInfo;
        }
    }
}
