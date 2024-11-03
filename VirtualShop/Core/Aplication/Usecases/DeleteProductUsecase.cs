using VirtualShop.Adapters.Output;
using VirtualShop.Core.Aplication.Interfaces;
using VirtualShop.Core.Aplication.OutputPorts;
using VirtualShop.Core.Domain.Entities;

namespace VirtualShop.Core.Aplication.Usecases
{
    public class DeleteProductUsecase:IDeleteProductUsecase
    {
        private IProductRepository _productRepository;

        public DeleteProductUsecase(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task DeleteProduct(int id)
        {
            Product? product = await _productRepository.GetProductById(id);

            if (product == null) 
            {
                throw new KeyNotFoundException("The product was not found.");
            }

            try
            {
                await _productRepository.DeleteProduct(product);
            }
            catch (Exception ex) 
            {
                throw new ApplicationException("Error trying to delete the product.");
            }
        }
    }
}
