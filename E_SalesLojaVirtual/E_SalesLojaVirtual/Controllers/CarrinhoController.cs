using E_SalesLojaVirtual.Models.CarrinhoDeCompras;
using E_SalesLojaVirtual.Models.Produtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace E_SalesLojaVirtual.Controllers
{
    public class CarrinhoController : Controller
    {
        // GET: Carrinho
        public ActionResult Index()
        {
            Carrinho c = new Carrinho();

            c = (Carrinho)Session["Carrinho"];

            if (c.produtos == null)
            {
                c.produtos = new List<Produto>();
            }

            return View(c);
        }

        public ActionResult RemoverProduto(int idProduto)
        {
            Carrinho c = new Carrinho();

            c = (Carrinho)Session["Carrinho"];

            c.produtos.RemoveAll(x => x.id == idProduto);

            return Json(1, JsonRequestBehavior.AllowGet);
        }
    }
}