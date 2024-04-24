using Newtonsoft.Json;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Text.Json.Serialization;
using WebConsumoAPI.Interfaces;
using WebConsumoAPI.Models;

namespace WebConsumoAPI.Repositories
{
    public class ClienteRepository : ICliente
    {
        private readonly string _uriAPI = "http://localhost:5054/api/Cliente/";
        private readonly IWebHostEnvironment _environment;

        public ClienteRepository(IWebHostEnvironment environment)
        {
            _environment = environment;      
        }
        public async Task<ClienteModel> Create(ClienteModel cliente)
        {
            try
            {
                if(cliente.Upload != null && cliente.Upload.Length > 0) 
                {
                    using (var ms = new MemoryStream())
                    {
                        await cliente.Upload.CopyToAsync(ms);
                        var imgBytes = ms.ToArray();

                        cliente.Logotipo = imgBytes;
                    }
                }

                using (var cli = new HttpClient())
                {
                    string jsonObject = JsonConvert.SerializeObject(cliente);
                    var content = new StringContent(jsonObject, Encoding.UTF8, "application/json");
                    var res = await cli.PostAsync($"{_uriAPI}", content);

                    if (res.IsSuccessStatusCode)
                    {
                        var retorno = await res.Content.ReadAsStringAsync();
                        return JsonConvert.DeserializeObject<ClienteModel>(retorno);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ocorreu um erro: {ex.Message}");
                throw;
            }

            return null;
        }

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

        public async Task<ClienteModel> Get(Guid id)
        {
            var cliente = new ClienteModel();

            try
            {
                using (var cli = new HttpClient())
                {
                    var res = await cli.GetAsync($"{_uriAPI}{id}");

                    if (res.IsSuccessStatusCode)
                    {
                        var retorno = await res.Content.ReadAsStringAsync();
                        cliente = JsonConvert.DeserializeObject<ClienteModel>(retorno);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ocorreu um erro: {ex.Message}");
                throw; 
            }

            return cliente;
        }

        public async Task<List<ClienteModel>> List()
        {
            var clientes = new List<ClienteModel>();

            try
            {
                using (var cli = new HttpClient())
                {
                    var res = cli.GetAsync(_uriAPI);

                    res.Wait();

                    if (res.Result.IsSuccessStatusCode)
                    {
                        var retorno = res.Result.Content.ReadAsStringAsync();
                        clientes = JsonConvert.DeserializeObject<ClienteModel[]>(retorno.Result).ToList();
                    }
                }
            }
            catch (Exception)
            {

                throw;
            }

            return clientes;
        }

        public async Task<ClienteModel> Update(ClienteModel cliente)
        {
            var clienteUpdate = new ClienteModel();

            try
            {

                if (cliente.Upload != null && cliente.Upload.Length > 0)
                {
                    using (var ms = new MemoryStream())
                    {
                        await cliente.Upload.CopyToAsync(ms);
                        var imgBytes = ms.ToArray();

                        cliente.Logotipo = imgBytes;
                    }
                }

                using (var cli = new HttpClient())
                {
                    string jsonObject = JsonConvert.SerializeObject(cliente);
                    var content = new StringContent(jsonObject, Encoding.UTF8, "application/json");
                    var res = await cli.PutAsync(_uriAPI + $"{cliente.Id}", content);

                    if (res.IsSuccessStatusCode)
                    {
                        var retorno = res.Content.ReadAsStringAsync().Result;
                        clienteUpdate = JsonConvert.DeserializeObject<ClienteModel>(retorno);
                    }
                }
            }
            catch (Exception)
            {

                throw;
            }

            return clienteUpdate;
        }
    }
}
