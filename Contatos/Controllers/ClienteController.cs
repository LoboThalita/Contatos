using Contatos.Models;
using Contatos.Services;
using Microsoft.AspNetCore.Mvc;

namespace Contatos.Controllers
{
    public class ClienteController : Controller
    {
        private readonly IClienteService _service;

        public ClienteController(IClienteService service)
        {
            _service = service;
        }

        public IActionResult Index()
        {
            ICollection<Cliente> clientes = _service.FindAll();
            return View(clientes);
        }

        public IActionResult Detalhar(int id)
        {
            Cliente? cliente = _service.Find(id);
            return View(cliente);
        }

        [HttpGet]
        public IActionResult Editar(int id)
        {
            Cliente? cliente = _service.Find(id);
            return View("Criar", cliente);
        }

        [HttpGet]
        public IActionResult Criar()
        {
            return View();
        }

        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public IActionResult Criar([Bind("Nome", "Endereco")] Cliente cliente)
        {
            if (Char.IsDigit(cliente.Nome[0]))
            {
                ModelState.AddModelError("Nome", "Nome não pode iniciar com digito!");
                return View(cliente);
            }
            if (cliente.Id > 0)
            {
                _service.Create(cliente);
            }
            else
            {
                _service.Update(cliente);
            }

            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Remover(int id)
        {
            Cliente? cliente = _service.Find(id);
            return View(cliente);
        }

        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public IActionResult Remover([Bind("Id", "Nome", "Endereco")] Cliente cliente)
        {
            _service.Delete(cliente);
            return RedirectToAction("Index");
        }
    }
}
