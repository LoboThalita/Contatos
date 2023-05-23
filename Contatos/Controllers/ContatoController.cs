using Contatos.Models;
using Contatos.Services;
using Microsoft.AspNetCore.Mvc;

namespace Contatos.Controllers
{
    public class ContatoController : Controller
    {
        private readonly IClienteService _service;

        public ContatoController(IClienteService service)
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
        public IActionResult Adicionar([FromRoute] int id,[FromForm]Contato contato)
        {
            _service.Create(id, contato);
            return View(_service.Find(id));
        }

        [HttpGet]
        public IActionResult Remover(int idContato, int idCliente)
        {
            return View(_service.Find(idCliente, idContato));
        }

        [AutoValidateAntiforgeryToken]
        public IActionResult RemoverConfirmacao (int Contato, int Cliente)
        {
            _service.Delete(Contato);
            var cliente = _service.Find(Cliente);
            return View("Index", cliente);
        }

        public IActionResult Editar(int idCliente, int idContato)
        {
            return View(_service.Find(idCliente, idContato));
        }

        [HttpPost]
        public IActionResult Editar([FromForm]Contato contato, int idContato, int idCliente)
        {
            _service.Update(idCliente, idContato, contato);
            return View("index", _service.Find(idCliente));
        }
    }
}
