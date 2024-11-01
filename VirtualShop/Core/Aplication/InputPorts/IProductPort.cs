using Microsoft.AspNetCore.Mvc;
using VirtualShop.Core.Aplication.DTOs;
using VirtualShop.Core.Domain.Entities;

namespace VirtualShop.Core.Aplication.InputPorts
{
    interface IProductPort
    {
        public Task<ActionResult<List<Product>>> GetAllProducts();

        public Task<ActionResult<Product>> GetProductById(int id);

        public Task<ActionResult<Product>> CreateProduct(ProductInsertDTO productInsert);

        public Task<IActionResult> UpdateProduct(int id, ProductModDTO productMod );

        public Task<IActionResult> DeleteProduct(int id);
    }
}
