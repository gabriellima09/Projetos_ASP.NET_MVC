using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Teste_ASP.NET.DAL;
using Teste_ASP.NET.Models;
using Teste_ASP.NET.UI.Models;

namespace Teste_ASP.NET.UI.Controllers
{
    public class ClienteController : Controller
    {
        ClienteDAO dao = new ClienteDAO();
        MapperCliente mapper = new MapperCliente();

        // GET: Cliente
        public ActionResult Index()
        {
            List<Cliente> clientes = new List<Cliente>();
            List<VM_Cliente> list = new List<VM_Cliente>();

            clientes = dao.ObterTodos();

            foreach (var item in clientes)
            {
                if (item.GetType() == typeof(ClientePF))
                {
                    ClientePF c = (ClientePF)item;

                    list.Add(mapper.MapVM_Cliente(c));
                }
                else if (item.GetType() == typeof(ClientePJ))
                {
                    ClientePJ c = (ClientePJ)item;

                    list.Add(mapper.MapVM_Cliente(c));
                }                
            }

            return View(list);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(VM_Cliente c)
        {
            try
            {
                if (c.TipoPessoa == TipoPessoa.Fisica)
                {
                    ClientePF cliente = mapper.MapClientePF(c);
                    dao.Incluir(cliente);
                }
                else if (c.TipoPessoa == TipoPessoa.Juridica)
                {
                    ClientePJ cliente = mapper.MapClientePJ(c);
                    dao.Incluir(cliente);
                }
                else
                {
                    throw new ApplicationException("Não foi possível cadastrar o cliente. Ocorreu um erro ao identificar o tipo de cliente");
                }

                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                return View(c);
            }
        }

        public ActionResult Edit(int Id)
        {
            Cliente cliente = dao.ObterPorId(Id);

            if (cliente.GetType() == typeof(ClientePF))
            {
                ClientePF c = (ClientePF)cliente;

                return View(mapper.MapVM_Cliente(c));
            }
            else if (cliente.GetType() == typeof(ClientePJ))
            {
                ClientePJ c = (ClientePJ)cliente;

                return View(mapper.MapVM_Cliente(c));
            }
            else
            {
                return View("Error");
            }
        }
        
        [HttpPost]
        public ActionResult Edit(VM_Cliente c)
        {
            try
            {
                if (c.TipoPessoa == TipoPessoa.Fisica)
                {
                    ClientePF cliente = mapper.MapClientePF(c);
                    dao.Alterar(cliente);
                }
                else if (c.TipoPessoa == TipoPessoa.Juridica)
                {
                    ClientePJ cliente = mapper.MapClientePJ(c);
                    dao.Alterar(cliente);
                }
                else
                {
                    throw new ApplicationException("Não foi possível editar o cliente. Ocorreu um erro ao identificar o tipo de cliente");
                }

                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                return View(c);
            }
        }

        public ActionResult Delete(int Id)
        {
            Cliente cliente = dao.ObterPorId(Id);

            if (cliente.GetType() == typeof(ClientePF))
            {
                ClientePF c = (ClientePF)cliente;

                return View(mapper.MapVM_Cliente(c));
            }
            else if (cliente.GetType() == typeof(ClientePJ))
            {
                ClientePJ c = (ClientePJ)cliente;

                return View(mapper.MapVM_Cliente(c));
            }
            else
            {
                return View("Error");
            }
        }

        [HttpPost]
        public ActionResult Delete(int Id, FormCollection form)
        {
            dao.Excluir(Id);

            return RedirectToAction("Index");
        }

        public ActionResult Details(int Id)
        {
            Cliente cliente = dao.ObterPorId(Id);

            if (cliente.GetType() == typeof(ClientePF))
            {
                ClientePF c = (ClientePF)cliente;
                
                return View(mapper.MapVM_Cliente(c));
            }
            else if (cliente.GetType() == typeof(ClientePJ))
            {
                ClientePJ c = (ClientePJ)cliente;

                return View(mapper.MapVM_Cliente(c));
            }
            else
            {
                return View("Error");
            }
        }
    }
}