using Contatos.Models;
using Contatos.Services;
using Microsoft.AspNetCore.Mvc;

namespace Contatos.Controllers
{
    public class ContatoController : Controller
    {
        private readonly IContatosService _service;

        public ContatoController(IContatosService service)
        {
            _service = service;
        }

        public IActionResult Index(int id)
        {
            Cliente? cliente = _service.Find(id);
            return View(cliente);
        }

        [HttpGet]
        public IActionResult Adicionar(int id)
        {
            Cliente? cliente = _service.Find(id);
            return View(cliente);
        }

        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public IActionResult Adicionar(int id, Contato contato)
        {
            Cliente? cliente = _service.Find(id);
            cliente.Contatos.Add(contato);
            return View(id);
        }
    }
}
