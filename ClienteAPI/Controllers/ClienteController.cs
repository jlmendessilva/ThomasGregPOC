using ClienteAPI.Models;
using ClienteAPI.Repositories.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ClienteAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClienteController : ControllerBase
    {
        private readonly IClienteRepository _clienteRepository;

        public ClienteController(IClienteRepository clienteRepository)
        {
            _clienteRepository = clienteRepository;
        }

        [HttpGet]
        public async Task<ActionResult<List<ClienteModel>>> All() 
        { 
            List<ClienteModel> clientes = await _clienteRepository.All();

            return clientes;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ClienteModel>> searchId(Guid id)
        {
            ClienteModel cliente = await _clienteRepository.searchId(id);
            return cliente;
        }

        [HttpPost]
        public async Task<ActionResult<ClienteModel>> Add([FromBody] ClienteModel clienteModel)
        {
            ClienteModel cliente = await _clienteRepository.Add(clienteModel);
            return cliente;
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<ClienteModel>> Update([FromBody] ClienteModel clienteModel, Guid id)
        {
            clienteModel.Id = id;

            ClienteModel cliente = await _clienteRepository.Update(clienteModel, id);
            return cliente;
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<bool>> Delete(Guid id)
        {
            bool apagado = await _clienteRepository.Delete(id);
            return apagado;
        }
    }
}
