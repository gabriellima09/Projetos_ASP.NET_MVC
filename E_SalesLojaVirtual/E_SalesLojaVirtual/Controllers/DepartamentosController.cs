using E_SalesLojaVirtual.Models.Produtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace E_SalesLojaVirtual.Controllers
{
    public class DepartamentosController : Controller
    {
        // GET: Departamentos
        public ActionResult Index()
        {
            return View("Departamentos");
        }

        // GET: PV_Departamentos
        public ActionResult PV_Departamentos()
        {
            return PartialView();
        }

        // GET: Carro
        public ActionResult Carro()
        {
            List<Produto> list = new List<Produto>();

            list = CRUD_Produto.GetProdutos(tipoProduto.Carro);

            ViewBag.Departamento = tipoProduto.Carro.ToString();

            return View(list);
        }

        // GET: Casa
        public ActionResult Casa()
        {
            List<Produto> list = new List<Produto>();

            list = CRUD_Produto.GetProdutos(tipoProduto.Casa);

            ViewBag.Departamento = tipoProduto.Casa.ToString();

            return View(list);
        }

        // GET: Feminino
        public ActionResult Feminino()
        {
            List<Produto> list = new List<Produto>();

            list = CRUD_Produto.GetProdutos(tipoProduto.Feminino);

            ViewBag.Departamento = tipoProduto.Feminino.ToString();

            return View(list);
        }

        // GET: Infantil
        public ActionResult Infantil()
        {
            List<Produto> list = new List<Produto>();

            list = CRUD_Produto.GetProdutos(tipoProduto.Infantil);

            ViewBag.Departamento = tipoProduto.Infantil.ToString();

            return View(list);
        }

        // GET: Informatica
        public ActionResult Informatica()
        {
            List<Produto> list = new List<Produto>();

            list = CRUD_Produto.GetProdutos(tipoProduto.Informatica);

            ViewBag.Departamento = tipoProduto.Informatica.ToString();

            return View(list);
        }

        // GET: Livros
        public ActionResult Livros()
        {
            List<Produto> list = new List<Produto>();

            list = CRUD_Produto.GetProdutos(tipoProduto.Livros);

            ViewBag.Departamento = tipoProduto.Livros.ToString();

            return View(list);
        }

        // GET: Masculino
        public ActionResult Masculino()
        {
            List<Produto> list = new List<Produto>();

            list = CRUD_Produto.GetProdutos(tipoProduto.Masculino);

            ViewBag.Departamento = tipoProduto.Masculino.ToString();

            return View(list);
        }
    }
}