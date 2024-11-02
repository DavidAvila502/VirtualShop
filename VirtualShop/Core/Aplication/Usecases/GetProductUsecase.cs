using VirtualShop.Adapters.Output;
using VirtualShop.Core.Aplication.Interfaces;
using VirtualShop.Core.Aplication.OutputPorts;
using VirtualShop.Core.Domain.Entities;

namespace VirtualShop.Core.Aplication.Usecases
{
    public class GetProductUsecase: IGetProductUsecase
    {

        private IProductRepository _productRepository;

        public GetProductUsecase(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<List<Product>> GetAllProducts()
        {
            try
            {
                List<Product> AllProducts = await _productRepository.GetAllProducts();

                return AllProducts;
            }
            catch (Exception ex) {

                throw new ApplicationException("Error trying to get the products.");
            }
        }


        public async Task<Product> GetProductById(int id)
        {
            Product? product = await _productRepository.GetProductById(id);

            if (product == null) {

                throw new KeyNotFoundException("The requested product does not exist.");
            }

            return product;
        }

    }
}
