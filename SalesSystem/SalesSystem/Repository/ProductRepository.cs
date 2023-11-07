using Microsoft.EntityFrameworkCore;
using SalesSystem.Data;
using SalesSystem.Model;
using SalesSystem.Repository.Interfaces;

namespace SalesSystem.Repository
{
    public class ProductRepository : IProductRepository
    {
        private readonly SystemSaleDbContext _dbContext;

        public ProductRepository(SystemSaleDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<ProductModel>> GetAllProducts()
        {
            return await _dbContext.Products.ToListAsync();
        }

        public async Task<ProductModel> GetProductById(int id)
        {
            return await _dbContext.Products.FirstOrDefaultAsync(x => x.Id == id) ??
                throw new ArgumentException("PRODUCT NOT FOUND");
        }

        public async Task<ProductModel> AddNewProduct(ProductModel product)
        {
            await _dbContext.Products.AddAsync(product);
            await _dbContext.SaveChangesAsync();

            return product;
        }

        public async Task<bool> DeleteProduct(int id)
        {
            var product = await GetProductById(id) ??
                 throw new ArgumentException("PRODUCT NOT FOUND");

            _dbContext.Products.Remove(product);
            await _dbContext.SaveChangesAsync();

            return true;
        }

        public async Task<ProductModel> UpdateProduct(ProductModel product, int id)
        {
            var updateProduct = await GetProductById(id) ??
                 throw new Exception("PRODUCT NOT FOND");

            updateProduct.Name = product.Name;
            updateProduct.Price = product.Price;
            updateProduct.Quantity = product.Quantity;

            _dbContext.Products.Update(updateProduct);
            await _dbContext.SaveChangesAsync();

            return product;

        }

        public async Task<ProductModel> UpdateQuantityProduct( int quantity, int id)
        {
            var updateProduct = await GetProductById(id) ?? 
                throw new Exception("PRODUCT NOT FOUND");

            updateProduct.Quantity = updateProduct.Quantity += quantity;

            _dbContext.Update(updateProduct);
            await _dbContext.SaveChangesAsync();

            return updateProduct;
        }

    }
}
