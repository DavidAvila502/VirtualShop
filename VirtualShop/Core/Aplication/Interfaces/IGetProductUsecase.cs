using VirtualShop.Core.Domain.Entities;

namespace VirtualShop.Core.Aplication.Interfaces
{
    public interface IGetProductUsecase
    {
        public Task<List<Product>> GetAllProducts();

        public Task<Product> GetProductById(int productId);
    }
}
