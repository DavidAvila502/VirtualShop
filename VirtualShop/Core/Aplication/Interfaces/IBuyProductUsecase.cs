namespace VirtualShop.Core.Aplication.Interfaces
{
    public interface IBuyProductUsecase
    {
        public Task BuyProduct(int userId, int productId);
    }
}
