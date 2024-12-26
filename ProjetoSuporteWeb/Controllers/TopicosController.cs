using Microsoft.AspNetCore.Mvc;

namespace ProjetoSuporteWeb.Controllers
{
    public class TopicosController : Controller
    {
        public IActionResult Info1()
        {
            return View("Info1");
        }

    }
}
