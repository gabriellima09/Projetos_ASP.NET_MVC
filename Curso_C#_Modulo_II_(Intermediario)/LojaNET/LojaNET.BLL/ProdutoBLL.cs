using LojaNet.Models;
using LojaNET.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LojaNET.BLL
{
    public class ProdutoBLL : IProduto
    {
        private IProduto dal;

        public ProdutoBLL(IProduto produto)
        {
            dal = produto;
        }

        public void Validar(Produto produto)
        {
            if (string.IsNullOrEmpty(produto.nome))
                throw new Exception("O nome deve ser informado");
            if (produto.preco < 0)
                throw new Exception("O preço deve ser maior ou igual a zero");
        }


        public void Alterar(Produto produto)
        {
            Validar(produto);
            dal.Alterar(produto);
        }

        public void Excluir(string id)
        {
            dal.Excluir(id);
        }

        public void Incluir(Produto produto)
        {
            if (string.IsNullOrEmpty(produto.id))
                produto.id = Guid.NewGuid().ToString();

            Validar(produto);
            dal.Incluir(produto);
        }

        public Produto ObterPorId(string id)
        {
            return dal.ObterPorId(id);
        }

        public List<Produto> ObterTodos()
        {
            return dal.ObterTodos();
        }
    }
}
