using VirtualShop.Core.Aplication.DTOs;
using VirtualShop.Core.Aplication.OutputPorts;
using VirtualShop.Core.Domain.Entities;
using VirtualShop.Infrastructure.Database;

namespace VirtualShop.Adapters.Output
{
    public class ProductRepository:IProductRepository
    {
        private Random rdn = new Random();

        public async Task<List<Product>> GetAllProducts()
        {
           List<Product> productList = AppDBContext.CurrentData.Products;
            int seleepValue = rdn.Next(5000);

            Task.Delay(seleepValue).Wait();

            return productList;
        }

        public async Task<Product?> GetProductById(int id)
        {
            int seleepValue = rdn.Next(5000);

            Task.Delay(seleepValue).Wait();

            return AppDBContext.CurrentData.Products.FirstOrDefault((x)=> x.Id == id );
        }

        public async Task<Product> CreateProduct(Product product)
        {
            int seleepValue = rdn.Next(5000);

            Task.Delay(seleepValue).Wait();

            AppDBContext.CurrentData.Products.Add(product);

            return product;
        }

        public async Task UpdateProduct(int id ,ProductModDTO productMod)
        {

            int seleepValue = rdn.Next(5000);

            Task.Delay(seleepValue).Wait();

            Product product = AppDBContext.CurrentData.Products.FirstOrDefault(x => x.Id == id);
            product!.Name = productMod.Name;
            product!.Price = productMod.Price;
        }

        public async Task DeleteProduct(Product product)
        {
            int seleepValue = rdn.Next(5000);

            Task.Delay(seleepValue).Wait();

            AppDBContext.CurrentData.Products.Remove(product);

        }
    }
}
