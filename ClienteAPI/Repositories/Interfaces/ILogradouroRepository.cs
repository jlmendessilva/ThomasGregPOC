using ClienteAPI.Models;
using System.Collections.Generic;

namespace ClienteAPI.Repositories.Interfaces
{
    public interface ILogradouroRepository
    {
        Task<LogradouroModel> Add(LogradouroModel logradouro);
        Task<List<LogradouroModel>> List(Guid ClienteID);
        Task<bool> Delete(Guid id);
    }
}
