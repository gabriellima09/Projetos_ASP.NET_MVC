using System.Web.Mvc;

namespace E_SalesLojaVirtual.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Devolucoes()
        {
            return View();
        }

        public ActionResult Error()
        {
            return View();
        }
    }
}