using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SalesSystem.Data;
using SalesSystem.Model;
using SalesSystem.Repository.Interfaces;

namespace SalesSystem.Repository
{
    public class ClientRepository : IClientRepository
    {
        private readonly SystemSaleDbContext _dbContext;
        private readonly IProductRepository _productRepository;

        public ClientRepository(SystemSaleDbContext dbContext, IProductRepository productRepository)
        {
            _dbContext = dbContext;
            _productRepository = productRepository;
        }

        public async Task<List<ClientModel>> GetAllClients()
        {
            return await _dbContext.Clients
                .Include(x => x.Product)
                .ToListAsync();
        }

        public async Task<ClientModel> GetClientById(int id)
        {
            return await _dbContext.Clients
                .Include(x => x.Product)
                .FirstOrDefaultAsync(x => x.Id == id) ??
                throw new Exception("CLIENT NOT FOUND");
        }

        public async Task<ClientModel> AddNewClient(ClientModel client)
        {
            await _dbContext.Clients.AddAsync(client);
            await _dbContext.SaveChangesAsync();

            return client;
        }

        public async Task<ClientModel> UpdateClient(ClientModel client, int id)
        {
            var updateClient = await GetClientById(id) ?? 
                throw new Exception("CLIENT NOT FOUND");

            updateClient.Name = client.Name;
            updateClient.Email = client.Email;
            updateClient.ProductId = client.ProductId;

            _dbContext.Clients.Update(updateClient);
            await _dbContext.SaveChangesAsync();

            return client;
        }

        public async Task<bool> DeleteClient(int id)
        {
            var deleteClient = await GetClientById(id) ??
                throw new Exception("CLIENT NOT FOUND");

            _dbContext.Clients.Remove(deleteClient);
            await _dbContext.SaveChangesAsync();

            return true;
        }


        public async Task<ClientModel> BuyProduct(int idClient,int idProduct, int quantity)
        {
            var client = await GetClientById(idClient) ??
                throw new Exception("CLIENT NOT FOUND");

            client.ProductId = idProduct;
            client.ProductQuantity += quantity;
            client.Product.Quantity -= quantity;

            _dbContext.Clients.Update(client);
            await _dbContext.SaveChangesAsync();

            return client;
        }
  
    }
}
