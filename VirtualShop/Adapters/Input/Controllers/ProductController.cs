using Microsoft.AspNetCore.Mvc;
using VirtualShop.Adapters.Output;
using VirtualShop.Core.Aplication.DTOs;
using VirtualShop.Core.Aplication.InputPorts;
using VirtualShop.Core.Aplication.Interfaces;
using VirtualShop.Core.Aplication.OutputPorts;
using VirtualShop.Core.Aplication.Usecases;
using VirtualShop.Core.Domain.Entities;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace VirtualShop.Adapters.Input.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase,IProductPort
    {
        private IProductRepository _productRepository;
        private IGetProductUsecase _getProductUsecase;
        private ICreateProductUsecase _createProductUsecase;
        private IUpdateProductUsecase _updateProductUsecase;
        private IDeleteProductUsecase _deleteProductUsecase;

        public ProductController()
        {
            _productRepository = new ProductRepository();
            _getProductUsecase = new GetProductUsecase(_productRepository);
            _createProductUsecase = new CreateProductUsecase(_productRepository);
            _updateProductUsecase = new UpdateProductUsecase(_productRepository);
            _deleteProductUsecase = new DeleteProductUsecase(_productRepository);
        }

        // GET: api/<ProductController>
        [HttpGet]
        public async Task<ActionResult<List<Product>>> GetAllProducts()
        {
            try
            {
                List<Product> products = await _getProductUsecase.GetAllProducts();

                return products;
            }
            catch (ApplicationException ex) 
            {
               return StatusCode(500, ex.Message);  
            }
        }

        // GET api/<ProductController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Product>> GetProductById(int id)
        {
            try
            {
                Product product = await _getProductUsecase.GetProductById(id);
                return product;
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
            catch(ApplicationException ex)
            {
                return StatusCode(500, new {message = ex.Message});
            }

        }

        // POST api/<ProductController>
        [HttpPost]
        public async Task<ActionResult<Product>> CreateProduct([FromBody] ProductInsertDTO productInsert)
        {
            try
            {

                Product product = await _createProductUsecase.CreateProduct(productInsert);
                return CreatedAtAction(nameof(GetProductById), new {Id = product.Id}, product);
            }

            catch (ApplicationException ex) {

                return StatusCode(500, new {message = ex.Message });
            }

        }

        // PUT api/<ProductController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateProduct(int id, [FromBody] ProductModDTO productMod)
        {
            try
            {
                await _updateProductUsecase.UpdateProduct(id, productMod);

                return Ok("The product was updated successfully.");
            }
            catch (KeyNotFoundException ex) {

                return NotFound(ex.Message);
            }

            catch(ApplicationException ex)
            {
                return StatusCode(500, new {message = ex.Message});
            }
 

        }

        // DELETE api/<ProductController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            try
            {
                await _deleteProductUsecase.DeleteProduct(id);

                return Ok("The product was deleted successfully.");
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
            catch (ApplicationException ex)
            {
                return StatusCode(500, new { message = ex.Message });
            }
        }
    }
}
