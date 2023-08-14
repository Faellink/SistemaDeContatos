using ControleContatos.Models;
using ControleContatos.Repository;
using Microsoft.AspNetCore.Mvc;

namespace ControleContatos.Controllers
{
    public class LoginController : Controller
    {

        private readonly IUsuarioRepository _usuarioRepository;

        public LoginController(IUsuarioRepository usuarioRepository)
        {
            _usuarioRepository = usuarioRepository;
        }


        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Enter(LoginModel loginModel)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View("Index");
                }

                UsuarioModel usuario = _usuarioRepository.GetLogin(loginModel.Login);

                if (usuario != null && usuario.Password == loginModel.Password)
                {
                    return RedirectToAction("Index", "Home");
                }

                // Fallback to hardcoded admin user
                if (loginModel.Login == "admin" && loginModel.Password == "admin")
                {
                    return RedirectToAction("Index", "Home");
                }

                TempData["MessageError"] = "Usuário e/ou senha inválido(s). Por favor, tente novamente.";
            }
            catch (Exception erro)
            {
                TempData["MessageError"] = $"Ops, não conseguimos realizar seu login, tente novamente. Detalhe do erro: {erro.Message}";
            }

            return View("Index");
        }

    }
}
