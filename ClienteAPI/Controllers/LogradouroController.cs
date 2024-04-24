using ClienteAPI.Models;
using ClienteAPI.Repositories;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ClienteAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LogradouroController : ControllerBase
    {
        private readonly LogradouroRepository _logradouroRepository;

        public LogradouroController(LogradouroRepository logradouroRepository)
        {
            _logradouroRepository = logradouroRepository;     
        }

        // GET api/<LogradouroController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<List<LogradouroModel>>> Get(Guid clienteID)
        {
            return  await _logradouroRepository.List(clienteID);
        }

        // POST api/<LogradouroController>
        [HttpPost]
        public async Task<ActionResult<LogradouroModel>> Post([FromBody] LogradouroModel logradouro)
        {
            return await _logradouroRepository.Add(logradouro);
        }

        // DELETE api/<LogradouroController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<bool>> Delete(Guid id)
        {
            return await _logradouroRepository.Delete(id);
        }
    }
}
