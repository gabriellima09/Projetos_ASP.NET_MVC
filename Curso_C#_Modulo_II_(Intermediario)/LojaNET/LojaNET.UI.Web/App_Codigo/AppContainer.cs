using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using LojaNet.DAL;
using LojaNET.BLL;
using LojaNet.Models;
using LojaNET.Models.Interfaces;
using LojaNET.DAL;

namespace LojaNET.UI.Web
{
    public static class AppContainer
    {
        public static ICliente ObterClienteBLL()
        {
            var dal = new ClienteDAL();
            var bll = new ClienteBLL(dal);
            return bll;
        }

        public static IProduto ObterProdutoBLL()
        {
            var dal = new ProdutoDAL();
            var bll = new ProdutoBLL(dal);
            return bll;
        }


    }
}