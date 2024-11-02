using VirtualShop.Adapters.Output;
using VirtualShop.Core.Aplication.DTOs;
using VirtualShop.Core.Aplication.Interfaces;
using VirtualShop.Core.Aplication.OutputPorts;
using VirtualShop.Core.Domain.Entities;
using VirtualShop.Infrastructure.Database;

namespace VirtualShop.Core.Aplication.Usecases
{
    public class CreateProductUsecase: ICreateProductUsecase
    {

        private IProductRepository _productRepository;

        public CreateProductUsecase(IProductRepository productRepository)
        {
            _productRepository = productRepository;

        }

        public async Task<Product> CreateProduct(ProductInsertDTO productInsert)
        {
            try
            {
                int newIndex = AppDBContext.CurrentData.Products.Count;

                Product newProduct = new Product() { Id = newIndex + 1, Name = productInsert.Name, Price = productInsert.Price };

                Product product = await _productRepository.CreateProduct(newProduct);

                return product;

            }
            catch (Exception ex) {

                throw new ApplicationException("Error trying to create the product.");
            }

          
        }
    }
}
