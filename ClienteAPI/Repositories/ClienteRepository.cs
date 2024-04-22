using ClienteAPI.Data;
using ClienteAPI.Models;
using ClienteAPI.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ClienteAPI.Repositories
{
    public class ClienteRepository : IClienteRepository
    {
        private readonly DataDbcontext _dbContext;  
        public ClienteRepository(DataDbcontext dataDbcontext)
        {
            _dbContext = dataDbcontext;
        }
        public async Task<ClienteModel> Add(ClienteModel cliente)
        {
            _dbContext.AddAsync(cliente);
            await _dbContext.SaveChangesAsync();

            return cliente;
        }

        public async Task<List<ClienteModel>> All()
        {
            return await _dbContext.Cliente.Include(c => c.Logradouros).ToListAsync();
        }

        public async Task<bool> Delete(Guid id)
        {
            ClienteModel cliente_id = await searchId(id);

            if (cliente_id == null)
                throw new Exception($"Usuario: {id} não encontrado.");

            _dbContext.Cliente.Remove(cliente_id);
            await _dbContext.SaveChangesAsync();

            return true;
        }

        public async Task<ClienteModel> searchId(Guid id)
        {
            return await _dbContext.Cliente.Include(c => c.Logradouros).FirstOrDefaultAsync(x => x.Id == id);
        }

        /*public async Task<ClienteModel> Update(ClienteModel cliente, Guid id)
        {
            ClienteModel cliente_id = await searchId(id);

            if(cliente_id == null)
                throw new Exception($"Usuario: {id} não encontrado.");

            cliente_id.Nome = cliente.Nome;
            cliente_id.Email = cliente.Email;
            cliente_id.Logotipo = cliente.Logotipo;
            cliente_id.Logradouros = cliente.Logradouros;

            await _dbContext.SaveChangesAsync();

            return cliente_id;
           
        }*/

        public async Task<ClienteModel> Update(ClienteModel cliente, Guid id)
        {
            ClienteModel cliente_id = await searchId(id);

            if (cliente_id == null)
                throw new Exception($"Usuário: {id} não encontrado.");

            // Atualiza informações básicas do cliente
            cliente_id.Nome = cliente.Nome;
            cliente_id.Email = cliente.Email;
            cliente_id.Logotipo = cliente.Logotipo;

            // Remove os logradouros existentes que não estão na lista atualizada
            var logradourosParaRemover = cliente_id.Logradouros
                .Where(existingAddress => !cliente.Logradouros.Any(updatedAddress => updatedAddress.Id == existingAddress.Id))
                .ToList();

            foreach (var enderecoParaRemover in logradourosParaRemover)
            {
                cliente_id.Logradouros.Remove(enderecoParaRemover);
                //_dbContext.Logradouros.Remove(enderecoParaRemover); // Remove do banco de dados
            }

            // Adiciona ou atualiza os logradouros
            foreach (var enderecoAtualizado in cliente.Logradouros)
            {
                var enderecoExistente = cliente_id.Logradouros.FirstOrDefault(a => a.Id == enderecoAtualizado.Id);
                if (enderecoExistente != null)
                {
                    // Atualiza o endereço existente
                    enderecoExistente.Endereco = enderecoAtualizado.Endereco;

                }
                else
                {
                    // Adiciona um novo endereço
                    cliente_id.Logradouros.Add(enderecoAtualizado);
                    //_dbContext.Logradouros.Add(enderecoAtualizado); // Adiciona ao banco de dados
                }
            }

            await _dbContext.SaveChangesAsync();

            return cliente_id;
        }
    }
}
