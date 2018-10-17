using System;
using System.Collections.Generic;
using System.Text;

namespace LojaNet.Models
{
    public interface ICliente
    {
        void Incluir(Cliente cliente);
        void Alterar(Cliente cliente);
        void Excluir(string id);
        List<Cliente> ObterTodos();
        Cliente ObterPorId(string id);
        Cliente ObterPorEmail(string email);
    }
}
