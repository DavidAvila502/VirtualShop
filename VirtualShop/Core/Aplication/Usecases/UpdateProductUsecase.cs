using VirtualShop.Adapters.Output;
using VirtualShop.Core.Aplication.DTOs;
using VirtualShop.Core.Aplication.Interfaces;
using VirtualShop.Core.Aplication.OutputPorts;
using VirtualShop.Core.Domain.Entities;

namespace VirtualShop.Core.Aplication.Usecases
{
    public class UpdateProductUsecase:IUpdateProductUsecase
    {

        private IProductRepository _productRepository;

        public UpdateProductUsecase(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task UpdateProduct(int id, ProductModDTO productMod)
        {
            Product?  product = await _productRepository.GetProductById(id);

            if (product == null) {

                throw new KeyNotFoundException("The requested product was not found.");
            }

            try
            {
                await _productRepository.UpdateProduct(id, productMod);
            }
            catch (Exception ex) {

                throw new ApplicationException("Error trying to update the product.");
            
            }

        }

    }
}
