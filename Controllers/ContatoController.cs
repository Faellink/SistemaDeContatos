using ControleContatos.Models;
using ControleContatos.Repository;
using Microsoft.AspNetCore.Mvc;

namespace ControleContatos.Controllers
{
    public class ContatoController : Controller
    {
        private readonly IContatoRepository _contatoRepository;

        public ContatoController(IContatoRepository contatoRepository)
        {
            _contatoRepository = contatoRepository;
        }

        public IActionResult Index()
        {
            List<ContatoModel> contatos = _contatoRepository.GetAll();

            return View(contatos);
        }

        public IActionResult Create()
        {
            return View();
        }

        public IActionResult Edit(int id)
        {
            ContatoModel contato = _contatoRepository.GetById(id);
            return View(contato);
        }

        public IActionResult DeleteConfirm(int id)
        {
            ContatoModel contato = _contatoRepository.GetById(id);
            return View(contato);
        }

        [HttpPost]
        public IActionResult Create(ContatoModel contato)
        {
            try
            {
                if (!ModelState.IsValid)
                    return View(contato);

                _contatoRepository.Add(contato);
                TempData["MessageSuccess"] = "Contato adicionado com sucesso";

                return RedirectToAction("Index");
            }
            catch (Exception e)
            {
                TempData["MessageError"] = "Erro ao adicionar contato. Erro: " + e.Message;

                return RedirectToAction("Index");
            }
        }


        [HttpPost]
        public IActionResult Edit(ContatoModel contato)
        {
            try
            {
                if (!ModelState.IsValid)
                    return View(contato);

                _contatoRepository.Edit(contato);
                TempData["MessageSuccess"] = "Contato editado com sucesso";

                return RedirectToAction("Index");
            }
            catch (Exception e)
            {
                TempData["MessageError"] = "Erro ao editar contato. Erro: " + e.Message;

                return RedirectToAction("Index");
            }
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            try
            {
                bool deleted = _contatoRepository.Delete(id);

                if (deleted)
                {
                    TempData["MessageSuccess"] = "Contato deletado com sucesso";
                }
                else TempData["MessageError"] = "Erro ao deletar contato";

                return RedirectToAction("Index");
            }
            catch (Exception e)
            {
                TempData["MessageError"] = "Erro ao deletar contato. Erro: " + e.Message;

                return RedirectToAction("Index");
            }
        }
    }
}
