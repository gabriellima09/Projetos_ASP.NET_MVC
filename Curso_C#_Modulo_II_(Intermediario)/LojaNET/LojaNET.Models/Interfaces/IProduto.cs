using LojaNet.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LojaNET.Models.Interfaces
{
    public interface IProduto
    {
        void Incluir(Produto produto);
        void Alterar(Produto produto);
        void Excluir(string id);
        List<Produto> ObterTodos();
        Produto ObterPorId(string id);
    }
}
