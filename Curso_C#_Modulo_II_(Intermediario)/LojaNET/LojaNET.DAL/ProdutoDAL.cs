using LojaNet.Models;
using LojaNET.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LojaNET.DAL
{
    public class ProdutoDAL : IProduto
    {
        private LojaContext db = new LojaContext();

        public void Alterar(Produto produto)
        {
            var produtoOriginal = ObterPorId(produto.id);

            if (produtoOriginal != null)
            {
                produtoOriginal.nome = produto.nome;
                produtoOriginal.preco = produto.preco;
                produtoOriginal.estoque = produto.estoque;
                db.SaveChanges();
            }
        }

        public void Excluir(string id)
        {
            var produto = ObterPorId(id);

            if (produto != null)
            {
                db.Produtos.Remove(produto);
                db.SaveChanges();
            }
        }

        public void Incluir(Produto produto)
        {
            db.Produtos.Add(produto);
            db.SaveChanges();
        }

        public Produto ObterPorId(string id)
        {
            var produto = db.Produtos.Where(x => x.id == id).FirstOrDefault();

            return produto;
        }

        public List<Produto> ObterTodos()
        {
            return db.Produtos.ToList();
        }
    }
}
