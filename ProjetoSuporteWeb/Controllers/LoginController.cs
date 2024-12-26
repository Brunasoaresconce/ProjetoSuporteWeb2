using Microsoft.AspNetCore.Mvc;
using ProjetoSuporteWeb.Models.Cadastro;
using System.Text.Json;

namespace ProjetoSuporteWeb.Controllers
{
    public class LoginController : Controller
    {
        public IActionResult Index()
        {
            return View("Login");
        }

        [HttpPost] // Alterado para POST
        public IActionResult AutenticacaoDeUsuario(string Login, string Senha)
        {
            if (string.IsNullOrWhiteSpace(Login) || string.IsNullOrWhiteSpace(Senha))
            {
                return Json(new { OK = false, Mensagem = "Login ou senha inválidos." });
            }

            UsuarioDAO cDadosDAO = new UsuarioDAO();
            Usuario cDados = cDadosDAO.Get_Usuario(Login.ToUpper().Trim(), Senha.ToUpper().Trim());

            if (cDados != null && cDados.senha == Senha)
            {
                HttpContext.Session.SetString("username", Login.ToUpper().Trim());
                // Senha removida da sessão
                return Json(new { OK = true, Mensagem = "Autenticado com sucesso." }, new JsonSerializerOptions { PropertyNamingPolicy = null });

            }
            else
            {
                return Json(new { OK = false, Mensagem = "Usuário ou senha incorretos." }, new JsonSerializerOptions { PropertyNamingPolicy = null });
            }
        }
    }
}
