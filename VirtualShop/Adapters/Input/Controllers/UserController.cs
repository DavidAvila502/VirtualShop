using Microsoft.AspNetCore.Mvc;
using VirtualShop.Core.Aplication.DTOs;
using VirtualShop.Core.Aplication.InputPorts;
using VirtualShop.Core.Domain.Entities;

namespace VirtualShop.Adapters.Input.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase ,IUserPort
    {
        [HttpPost]
        public async Task<ActionResult<User>> CreateUser([FromBody] UserInsertDTO userInsert)
        {
            return new User() { Id = 1, Name = "David", Email = "david@gmil.com" };
            //throw new NotImplementedException();
        }

        [HttpPost("{userId}/buy/{productId}")]
        public async Task<IActionResult> BuyProduct(int userId , int productId)
        {
            //throw new NotImplementedException();
            return Ok("Process complete.");
        }

    }
}
