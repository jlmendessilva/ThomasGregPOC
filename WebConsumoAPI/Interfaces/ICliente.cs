using WebConsumoAPI.Models;

namespace WebConsumoAPI.Interfaces
{
    public interface ICliente
    {

        Task<List<ClienteModel>> List();
        Task<ClienteModel> Create(ClienteModel cliente);
        Task<ClienteModel> Update(ClienteModel cliente);
        Task<bool> Delete(Guid id);
        Task<ClienteModel> Get(Guid id);

    }
}
