using LojaNet.Models;
using LojaNET.BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LojaNET.UI.Web.Controllers
{
    public class ClienteController : Controller
    {
        private ClienteBLL bll;

        public ClienteController()
        {
            bll = new ClienteBLL();
        }

        // GET: Cliente
        public ActionResult Index()
        {
            var list = bll.ObterTodos();

            return View(list);
        }

        public ActionResult Incluir()
        {
            var cliente = new Cliente();

            return View(cliente);
        }

        [HttpPost]
        public ActionResult Incluir(Cliente cliente)
        {
            try
            {
                bll.Incluir(cliente);

                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);

                return View(cliente);
            }
        }

        public ActionResult Alterar(string id)
        {
            var cliente = bll.ObterPorId(id);

            return View(cliente);
        }

        [HttpPost]
        public ActionResult Alterar(Cliente cliente)
        {
            try
            {
                bll.Alterar(cliente);

                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);

                return View(cliente);
            }
        }

        public ActionResult Excluir(string id)
        {
            var cliente = bll.ObterPorId(id);

            return View(cliente);
        }

        [HttpPost]
        public ActionResult Excluir(string id, FormCollection form)
        {
            try
            {
                bll.Excluir(id);

                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                var cliente = bll.ObterPorId(id);
                return View(cliente);
            }
        }

        public ActionResult Detalhes(string id)
        {
            var cliente = bll.ObterPorId(id);

            return View(cliente);
        }
    }
}