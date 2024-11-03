using VirtualShop.Core.Aplication.DTOs;
using VirtualShop.Core.Domain.Entities;

namespace VirtualShop.Core.Aplication.Interfaces
{
    public interface ICreateProductUsecase
    {
        public Task<Product> CreateProduct(ProductInsertDTO productInsert);
    }
}
