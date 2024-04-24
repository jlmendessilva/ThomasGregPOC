using WebConsumoAPI.Interfaces;
using WebConsumoAPI.Models;

namespace WebConsumoAPI.Repositories
{
    public class LogradouroRepository : ILogradouro
    {
        private readonly string _uriAPI = "http://localhost:5054/api/Logradouro/";

        public async Task<bool> Delete(Guid id)
        {
            try
            {
                using (var cli = new HttpClient())
                {
                    var res = await cli.DeleteAsync(_uriAPI + $"{id}");

                    if (res.IsSuccessStatusCode)
                    {
                        var retorno = await res.Content.ReadAsStringAsync();
                        return bool.Parse(retorno);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ocorreu um erro: {ex.Message}");
                throw;
            }

            return false;
        }

        public Task<LogradouroModel> Get(Guid clienteID)
        {
            throw new NotImplementedException();
        }

        public Task<LogradouroModel> Post(LogradouroModel logradouro)
        {
            throw new NotImplementedException();
        }
    }
}
