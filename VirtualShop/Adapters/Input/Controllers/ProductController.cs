using Microsoft.AspNetCore.Mvc;
using VirtualShop.Core.Aplication.DTOs;
using VirtualShop.Core.Aplication.InputPorts;
using VirtualShop.Core.Domain.Entities;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace VirtualShop.Adapters.Input.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase,IProductPort
    {
        // GET: api/<ProductController>
        [HttpGet]
        public async Task<ActionResult<List<Product>>> GetAllProducts()
        {
            return StatusCode(500, new {message = "Unimplemented endpoing."});
        }

        // GET api/<ProductController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Product>> GetProductById(int id)
        {
            return StatusCode(500, new { message = "Unimplemented endpoing." });

        }

        // POST api/<ProductController>
        [HttpPost]
        public async Task<ActionResult<Product>> CreateProduct([FromBody] ProductInsertDTO productInsert)
        {
            return StatusCode(500, new { message = "Unimplemented endpoing." });

        }

        // PUT api/<ProductController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateProduct(int id, [FromBody] ProductModDTO productMod)
        {
            return StatusCode(500, new { message = "Unimplemented endpoing." });

        }

        // DELETE api/<ProductController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            return StatusCode(500, new { message = "Unimplemented endpoing." });

        }
    }
}
