using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using LojaNet.Models;
using LojaNET.BLL;
using LojaNet.DAL;

namespace LojaNET.Test
{
    /// <summary>
    /// Summary description for ClienteBLLTest
    /// </summary>
    [TestClass]
    public class ClienteBLLTest
    {
        public class ClienteDALMock : ICliente
        {
            public void Alterar(Cliente cliente)
            {
                
            }

            public void Excluir(string id)
            {
                
            }

            public void Incluir(Cliente cliente)
            {
                
            }

            public Cliente ObterPorEmail(string email)
            {
                return null;
            }

            public Cliente ObterPorId(string id)
            {
                return null;
            }

            public List<Cliente> ObterTodos()
            {
                throw new NotImplementedException();
            }
        }

        [TestMethod]
        public void IncluirNomeNotNullTest()
        {
            var cliente = new Cliente() { nome = "José da Silva", email = "email@email.com", telefone = "12345678" };
            var dal = new ClienteDALMock();
            var bll = new ClienteBLL(dal);

            bool ok = false;

            try
            {
                bll.Incluir(cliente);

                ok = true;
            }
            catch (ApplicationException)
            {
                ok = false;
            }

            Assert.IsTrue(ok, "Deveria ter disparado um ApplicationException");
        }

        [TestMethod]
        public void IncluirNomeNullTest()
        {
            var cliente = new Cliente() { nome = null, email = "email@email.com",telefone = "12345678" };
            var dal = new ClienteDAL();
            var bll = new ClienteBLL(dal);

            bool ok = false;

            try
            {
                bll.Incluir(cliente);
            }
            catch (ApplicationException)
            {
                ok = true;
            }

            Assert.IsTrue(ok, "Deveria ter disparado um ApplicationException");
        }
    }
}
