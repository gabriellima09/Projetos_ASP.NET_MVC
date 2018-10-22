using System;
using System.Collections.Generic;
using System.Text;

namespace Teste_ASP.NET.Models
{
    public interface ICliente
    {
        void Incluir(ClientePF cliente);
        void Incluir(ClientePJ cliente);
        void Alterar(ClientePF cliente);
        void Alterar(ClientePJ cliente);
        void Excluir(int id);
        List<Cliente> ObterTodos();
        Cliente ObterPorId(int id);
    }
}
