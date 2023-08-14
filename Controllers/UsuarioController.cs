using ControleContatos.Models;
using ControleContatos.Repository;
using Microsoft.AspNetCore.Mvc;

namespace ControleContatos.Controllers
{
    public class UsuarioController : Controller
    {
        private readonly IUsuarioRepository _usuarioRepositoryRepository;

        public UsuarioController(IUsuarioRepository usuarioRepository)
        {
            _usuarioRepositoryRepository = usuarioRepository;
        }

        public IActionResult Index()
        {
            List<UsuarioModel> usuarios = _usuarioRepositoryRepository.GetAll();

            return View(usuarios);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(UsuarioModel usuario)
        {
            try
            {
                if (!ModelState.IsValid)
                    return View(usuario);

                _usuarioRepositoryRepository.Add(usuario);
                TempData["MessageSuccess"] = "Usuário adicionado com sucesso";

                return RedirectToAction("Index");
            }
            catch (Exception e)
            {
                TempData["MessageError"] = "Erro ao adicionar usuário. Erro: " + e.Message;

                return RedirectToAction("Index");
            }
        }
    }
}
