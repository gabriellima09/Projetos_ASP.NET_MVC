using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.IO;
using E_SalesLojaVirtual.Models.AutenticacaoCliente;
using E_SalesLojaVirtual.Models.CarrinhoDeCompras;
using E_SalesLojaVirtual.Models;

namespace E_SalesLojaVirtual.Controllers
{
    public class AutenticacaoClienteController : Controller
    {
        // GET: CadastrarCliente
        public ActionResult CadastrarCliente()
        {
            return View();
        }

        // POST: CadastrarCliente
        [HttpPost]
        public ActionResult CadastrarCliente(Cliente cliente)
        {
            if (ModelState.IsValid)
            {
                CRUD_Cliente crud = new CRUD_Cliente();

                crud.CadastrarCliente(cliente);

                return RedirectToAction("Index", "Home");
            }

            return View("CadastrarCliente", cliente);
        }

        // GET: LoginCliente
        public ActionResult LoginCliente()
        {
            return View();
        }

        // POST: LoginCliente
        [HttpPost]
        public ActionResult LoginCliente(Cliente cliente)
        {
            CRUD_Cliente crud = new CRUD_Cliente();

            Cliente c = crud.RetornaCliente(cliente.email, cliente.senha);

            if (c != null)
            {
                Carrinho carrinho = new Carrinho();

                carrinho.cliente = c;

                Session["Carrinho"] = carrinho;

                return RedirectToAction("Index", "Home");
            }
            else
            {
                ViewBag.Cliente = 1;

                return View("LoginCliente", cliente);
            }
        }

        // GET: VerificaSessaoCliente
        public ActionResult VerificaSessaoCliente()
        {
            if (Session["Carrinho"] != null)
            {
                Carrinho carrinho = (Carrinho)Session["Carrinho"];

                ViewBag.NomeCliente = carrinho.cliente.nome;

                return PartialView("ClienteLoginNavBar");
            }
            else
            {
                return RedirectToAction("Error", "Home");
            }
        }

        // GET: RedefinirSenha
        public ActionResult RedefinirSenha()
        {
            return View();
        }

        // POST: RedefinirSenha
        [HttpPost]
        public ActionResult RedefinirSenha(Cliente cliente)
        {
            CRUD_Cliente crud = new CRUD_Cliente();

            crud.EditarCliente(cliente);

            return RedirectToAction("Index", "Home");
        }

        // GET: LogoutCliente
        public ActionResult LogoutCliente()
        {
            Session.Remove("Carrinho");

            return RedirectToAction("Index", "Home");
        }
    }
}