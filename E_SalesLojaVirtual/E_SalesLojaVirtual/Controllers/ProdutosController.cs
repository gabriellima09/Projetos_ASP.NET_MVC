using E_SalesLojaVirtual.Models.CarrinhoDeCompras;
using E_SalesLojaVirtual.Models.Produtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace E_SalesLojaVirtual.Controllers
{
    public class ProdutosController : Controller
    {
        // GET: Produto
        [HttpPost]
        public ActionResult Info(Produto item)
        {
            ViewBag.Departamento = Enum.GetName(typeof(tipoProduto), item.idTipo);

            return View(item);
        }

        // POST: Produtos
        [HttpPost]
        public ActionResult AdicionarCarrinho(Produto p)
        {
            Carrinho c = new Carrinho();

            if (Session["Carrinho"] != null)
            {
                c = (Carrinho)Session["Carrinho"];

                if (c.produtos == null)
                {
                    c.produtos = new List<Produto>();
                }

                c.produtos.Add(p);

                Session["Carrinho"] = c;
            }
            else
            {
                return RedirectToAction("LoginCliente", "AutenticacaoCliente");
            }

            return RedirectToAction("Index", "Carrinho");
        }
    }
}