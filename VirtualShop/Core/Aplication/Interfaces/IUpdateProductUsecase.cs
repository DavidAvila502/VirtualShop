using VirtualShop.Core.Aplication.DTOs;

namespace VirtualShop.Core.Aplication.Interfaces
{
    interface IUpdateProductUsecase
    {
        public Task UpdateProduct(int id, ProductModDTO productMod);
    }
}
