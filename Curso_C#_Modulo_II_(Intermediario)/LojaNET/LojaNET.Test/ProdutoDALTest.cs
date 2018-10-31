using System;
using LojaNet.Models;
using LojaNET.DAL;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LojaNET.Test
{
    [TestClass]
    public class ProdutoDALTest
    {
        [TestMethod]
        public void Incluir()
        {
            var p = new Produto()
            {
                id = Guid.NewGuid().ToString(),
                nome = "Produto Teste",
                preco = 100,
                estoque = 2
            };

            var dal = new ProdutoDAL();
            dal.Incluir(p);

            var produto = dal.ObterPorId(p.id);

            Assert.IsTrue(produto != null, "Erro na inclusão");
        }

        [TestMethod]
        public void Listar()
        {
            var dal = new ProdutoDAL();
            var lista = dal.ObterTodos();

            foreach (var p in lista)
            {
                Console.WriteLine(p.id);
                Console.WriteLine(p.nome);
                Console.WriteLine(p.preco);
                Console.WriteLine(p.estoque);
            }

            Assert.IsTrue(lista.Count > 0, "A lista não pode ser vazia");
        }

    }
}
