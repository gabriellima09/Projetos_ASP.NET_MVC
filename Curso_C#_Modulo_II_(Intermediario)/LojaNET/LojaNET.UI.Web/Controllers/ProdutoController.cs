using LojaNet.Models;
using LojaNET.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LojaNET.UI.Web.Controllers
{
    public class ProdutoController : Controller
    {
        private IProduto bll;

        public ProdutoController()
        {
            bll = AppContainer.ObterProdutoBLL();
        }

        // GET: Produto
        public ActionResult Index()
        {
            var list = bll.ObterTodos();

            return View(list);
        }

        public ActionResult Incluir()
        {
            var produto = new Produto();

            return View(produto);
        }

        [HttpPost]
        public ActionResult Incluir(Produto produto)
        {
            try
            {
                bll.Incluir(produto);

                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);

                return View(produto);
            }
        }

        public ActionResult Alterar(string id)
        {
            var produto = bll.ObterPorId(id);

            return View(produto);
        }

        [HttpPost]
        public ActionResult Alterar(Produto produto)
        {
            try
            {
                bll.Alterar(produto);

                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);

                return View(produto);
            }
        }

        public ActionResult Excluir(string id)
        {
            var produto = bll.ObterPorId(id);

            return View(produto);
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
                var produto = bll.ObterPorId(id);
                return View(produto);
            }
        }

        public ActionResult Detalhes(string id)
        {
            var produto = bll.ObterPorId(id);

            return View(produto);
        }
    }
}