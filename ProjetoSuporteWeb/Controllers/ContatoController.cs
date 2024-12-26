using Microsoft.AspNetCore.Mvc;

namespace ProjetoSuporteWeb.Controllers
{
    public class ContatoController : Controller
    {
        public IActionResult Email()
        {
            return View();
        }
        public ActionResult Sair()
        {
            return RedirectToAction("Index", "Home");
        }

    }
}
