using ClienteAPI.Data;
using ClienteAPI.Models;
using ClienteAPI.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ClienteAPI.Repositories
{
    public class LogradouroRepository : ILogradouroRepository
    {
        private readonly DataDbcontext _dbContext;

        public LogradouroRepository(DataDbcontext dataDbcontext)
        {
            _dbContext = dataDbcontext;
        }
        public async Task<LogradouroModel> Add(LogradouroModel logradouro)
        {
           await _dbContext.Logradouro.AddAsync(logradouro);
           await _dbContext.SaveChangesAsync();

            return logradouro;
        }

        public async Task<bool> Delete(Guid id)
        {
            var logradouro = await _dbContext.Logradouro.FirstOrDefaultAsync(x => x.Id == id);

            if (logradouro == null)
                throw new Exception($"Logradouro: {id} não encontrado.");

            _dbContext.Logradouro.Remove(logradouro);
            await _dbContext.SaveChangesAsync();

            return true;

        }

        public async Task<List<LogradouroModel>> List(Guid ClienteID)
        {
            var logradouro = _dbContext.Cliente?.FirstOrDefaultAsync(x => x.Id == ClienteID).Result?.Logradouros.ToList();

            if (logradouro == null)
                throw new Exception($"Logradouro do cliente {ClienteID} não encontrado.");

            return logradouro;
        }
    }
}
