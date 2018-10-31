using System;
using LojaNet.DAL;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LojaNET.Test
{
    [TestClass]
    public class ClienteDALTest
    {
        [TestMethod]
        public void ObterPorEmailNullTest()
        {
            string email = null;
            var dal = new ClienteDAL();
            bool ok = false;

            try
            {
                dal.ObterPorEmail(email);
            }
            catch (ApplicationException ex)
            {
                if (ex.Message == "O email deve ser informado")
                {
                    ok = true;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Erro no Servidor. Parâmetro não informado: " + ex.Message);
            }

            Assert.IsTrue(ok, "Deveria ter disparado um 'ApplicationException' com a mensagem 'O email deve ser informado'");
        }


        [TestMethod]
        public void ObterPorEmailTest()
        {
            string email = "gabriellimagomes.14@hotmail.com";

            var dal = new ClienteDAL();

            var cliente = dal.ObterPorEmail(email);

            if (cliente != null)
            {
                Console.WriteLine("Cliente encontrado: ");
                Console.WriteLine(cliente.id);
                Console.WriteLine(cliente.nome);
                Console.WriteLine(cliente.email);
                Console.WriteLine(cliente.telefone);
            }

            Assert.IsTrue(cliente != null, "Deveria retornar os dados de um cliente");
        }
    }
}
