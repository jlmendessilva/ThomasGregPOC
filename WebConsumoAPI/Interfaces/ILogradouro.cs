using WebConsumoAPI.Models;

namespace WebConsumoAPI.Interfaces
{
    public interface ILogradouro
    {
        Task<LogradouroModel> Post(LogradouroModel logradouro);
        Task<bool> Delete(Guid id);
        Task<LogradouroModel> Get(Guid clienteID);
    }
}
