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

        public IActionResult Edit(int id)
        {
            UsuarioModel usuario = _usuarioRepositoryRepository.GetById(id);
            return View(usuario);
        }

        [HttpPost]
        public IActionResult Edit(UsuarioEditModel usuarioEdit)
        {
            try
            {
                UsuarioModel usuario = null;

                if (!ModelState.IsValid)
                    return View(usuario);

                usuario = new UsuarioModel()
                {
                    Id = usuarioEdit.Id,
                    Name = usuarioEdit.Name,
                    Email = usuarioEdit.Email,
                    Login = usuarioEdit.Login,
                    Profile = usuarioEdit.Profile
                };

                _usuarioRepositoryRepository.Edit(usuario);
                TempData["MessageSuccess"] = "Usuário editado com sucesso";

                return RedirectToAction("Index");
            }
            catch (Exception e)
            {
                TempData["MessageError"] = "Erro ao editar usuário. Erro: " + e.Message;

                return RedirectToAction("Index");
            }
        }

        public IActionResult DeleteConfirm(int id)
        {
            UsuarioModel usuario = _usuarioRepositoryRepository.GetById(id);
            return View(usuario);
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            try
            {
                bool deleted = _usuarioRepositoryRepository.Delete(id);

                if (deleted)
                {
                    TempData["MessageSuccess"] = "Usuário deletado com sucesso";
                }
                else TempData["MessageError"] = "Erro ao deletar usuário";

                return RedirectToAction("Index");
            }
            catch (Exception e)
            {
                TempData["MessageError"] = "Erro ao deletar usuário. Erro: " + e.Message;

                return RedirectToAction("Index");
            }
        }
    }
}
