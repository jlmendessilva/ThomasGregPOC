using ClienteAPI.Models;

namespace ClienteAPI.Repositories.Interfaces
{
    public interface IClienteRepository
    {
        Task<List<ClienteModel>> All();
        Task<ClienteModel> searchId(Guid id);
        Task<ClienteModel> Add(ClienteModel cliente);
        Task<ClienteModel> Update(ClienteModel cliente, Guid id);
        Task<bool> Delete(Guid id);


    }
}
