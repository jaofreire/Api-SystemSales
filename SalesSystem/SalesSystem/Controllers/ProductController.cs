using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SalesSystem.Model;
using SalesSystem.Repository;
using SalesSystem.Repository.Interfaces;

namespace SalesSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductRepository _productRepository;

        public ProductController(IProductRepository product)
        {
            _productRepository = product;
        }

        [HttpGet]
        public async Task<ActionResult<List<ProductModel>>> GetAll()
        {
            return await _productRepository.GetAllProducts();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ProductModel>> GetById(int id)
        {
            return await _productRepository.GetProductById(id);
        }

        [HttpPost]
        public async Task<ActionResult<ProductModel>> AddProduct(ProductModel newProduct)
        {
            return await _productRepository.AddNewProduct(newProduct);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<ProductModel>> Update(ProductModel updateProduct, int id)
        {
            updateProduct.Id = id;
            return await _productRepository.UpdateProduct(updateProduct, id);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<bool>> Delete(int id)
        {
            return await _productRepository.DeleteProduct(id);
        }

        [HttpPatch("{id}")]
        public async Task<ActionResult<ProductModel>> UpdateQuantity(int quantity, int id)
        {
            return await _productRepository.UpdateQuantityProduct(quantity, id);
        }
    }
}
