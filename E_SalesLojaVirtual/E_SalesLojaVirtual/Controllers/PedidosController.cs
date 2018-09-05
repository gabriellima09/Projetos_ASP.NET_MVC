using E_SalesLojaVirtual.Models;
using E_SalesLojaVirtual.Models.CarrinhoDeCompras;
using E_SalesLojaVirtual.Models.Pedidos;
using E_SalesLojaVirtual.Models.Produtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace E_SalesLojaVirtual.Controllers
{
    public class PedidosController : Controller
    {
        // GET: Pedidos
        public ActionResult Pedidos()
        {
            Carrinho c = new Carrinho();

            CRUD_Pedido crud = new CRUD_Pedido();

            c = (Carrinho)Session["Carrinho"];

            List<Pedido> lst = new List<Pedido>();

            lst = crud.ListarPedidos(c.cliente.id);

            return View(lst);
        }

        // POST: Pedidos
        [HttpPost]
        public ActionResult FinalizarCompra()
        {
            Carrinho c = new Carrinho();

            CRUD_Pedido crud = new CRUD_Pedido();

            c = (Carrinho)Session["Carrinho"];

            Pedido p = new Pedido();

            p.id = DateTime.Now.ToString("yyyyMMddHHmmss");

            p.carrinho = c;

            p.valorPedido = p.carrinho.produtos.Sum(x => x.valor);

            p.dataPedido = String.Format("{0:f}", DateTime.Now.ToString());

            crud.SalvarPedido(p);

            c.produtos = new List<Produto>();

            Session["Carrinho"] = c;

            List<Pedido> lst = new List<Pedido>();

            lst = crud.ListarPedidos(p.carrinho.cliente.id);

            return View("Pedidos", lst);
        }
    }
}