using Microsoft.EntityFrameworkCore;
using SalesSystem.Data;
using SalesSystem.Model;
using SalesSystem.Repository.Interfaces;
using System.Linq.Expressions;

namespace SalesSystem.Repository
{
    public class RequestsFinaledsRepository : IRequestsFinaledsRespository
    {
        private readonly SystemSaleDbContext _dbContext;
        private readonly IClientRepository _clientRepository;
        private readonly IProductRepository _productRepository;

        public RequestsFinaledsRepository(SystemSaleDbContext dbContext, IClientRepository clieRepository, IProductRepository productRepository)
        {
            _dbContext = dbContext;
            _clientRepository = clieRepository;
            _productRepository = productRepository;
        }

        public async Task<List<RequestsFinaledsModel>> GetAllRequests()
        {
            return await _dbContext.RequestsFinaleds
                .ToListAsync();
        }

        public async Task<RequestsFinaledsModel> AddRequestFinaled(int id, RequestsFinaledsModel newRequest)
        {
            var client = await _clientRepository.GetClientById(id) ??
                throw new Exception("CLIENT NOT FOUND");

            var product = await _productRepository.GetProductById((int)client.ProductId) ??
                throw new Exception("PRODUCT NOT FOUND");

            newRequest.ClientId = client.Id;
            newRequest.Name = client.Name;
            newRequest.Email = client.Email;

            newRequest.ProductName = product.Name;
            newRequest.ProductId = (int)client.ProductId;
            newRequest.ProductQuantity = (int)client.ProductQuantity;
            newRequest.ProductPrice = product.Price;

            await _dbContext.RequestsFinaleds.AddAsync(newRequest);
            await _dbContext.SaveChangesAsync();

            return newRequest;
        }

        public async Task<bool> DeleteRequestFinaled(int id)
        {
            var request = await _dbContext.RequestsFinaleds.FirstOrDefaultAsync(x => x.Id == id) ??
                throw new Exception("REQUEST NOT FOUND");

            _dbContext.RequestsFinaleds.Remove(request);
            await _dbContext.SaveChangesAsync();

            return true;
        }
    }
}
