using SalesSystem.Model;

namespace SalesSystem.Repository.Interfaces
{
    public interface IProductRepository
    {
        Task<List<ProductModel>> GetAllProducts();
        Task<ProductModel> GetProductById(int id);
        Task<ProductModel> AddNewProduct(ProductModel product);
        Task<ProductModel> UpdateProduct(ProductModel product, int id);
        Task<bool> DeleteProduct(int id);

        Task<ProductModel> UpdateQuantityProduct( int quantity, int id);
       

    }
}
