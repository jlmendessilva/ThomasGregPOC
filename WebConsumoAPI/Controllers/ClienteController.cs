using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebConsumoAPI.Interfaces;
using WebConsumoAPI.Models;

namespace WebConsumoAPI.Controllers
{
    public class ClienteController : Controller
    {
        private readonly ICliente _clienteRepository;
        private readonly ILogradouro _logradouroRepository;

        public ClienteController(ICliente cliente, ILogradouro logradouro)
        {
            _clienteRepository = cliente;     
            _logradouroRepository = logradouro;
        }
        // GET: ClienteController
        public async Task<ActionResult> Index()
        {
            return View(await _clienteRepository.List());
        }

        // GET: ClienteController/Details/5
        public async Task<ActionResult> Details(Guid id)
        {
            return View(await _clienteRepository.Get(id));
        }

        // GET: ClienteController/Create
        public async Task<ActionResult> Create()
        {
            return View();
        }

        // POST: ClienteController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(ClienteModel collection)
        {
            try
            {
                await _clienteRepository.Create(collection);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ClienteController/Edit/5
        public async Task<ActionResult> Edit(Guid id)
        {
            return View(await _clienteRepository.Get(id));
        }

        // POST: ClienteController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(int id, ClienteModel collection)
        {
            try
            {
                await _clienteRepository.Update(collection);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ClienteController/Delete/5
        public async Task<ActionResult> Delete(Guid id)
        {
            return View(await _clienteRepository.Get(id));
        }

        // POST: ClienteController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Delete(Guid id, IFormCollection collection)
        {
            try
            {
                await _clienteRepository.Delete(id);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ClienteController/Delete/5
        public async Task<ActionResult> DelEndereco(Guid id)
        {
            await _logradouroRepository.Delete(id);
            return View();
        }
    }
}
