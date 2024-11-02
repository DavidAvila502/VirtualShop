using VirtualShop.Core.Aplication.DTOs;
using VirtualShop.Core.Domain.Entities;

namespace VirtualShop.Core.Aplication.OutputPorts
{
   public  interface IProductRepository
    {
        public Task<List<Product>> GetAllProducts();

        public Task<Product?> GetProductById(int id);

        public Task<Product> CreateProduct(Product user);

        public Task UpdateProduct(int id , ProductModDTO productMode);

        public Task DeleteProduct(Product product);
    }
}
