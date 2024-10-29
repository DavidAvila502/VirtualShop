using Microsoft.AspNetCore.Mvc;
using VirtualShop.Adapters.Output;
using VirtualShop.Core.Aplication.DTOs;
using VirtualShop.Core.Aplication.InputPorts;
using VirtualShop.Core.Aplication.Usecases;
using VirtualShop.Core.Domain.Entities;

namespace VirtualShop.Adapters.Input.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase, IUserPort
    {

        private UserRepository _userRepository;
        private CreateUserUsecase _createUserUsecase;
        private GetUserUsecase _getUserUsecase;

        public UserController()
        {
            _userRepository = new UserRepository();
            _createUserUsecase = new CreateUserUsecase(_userRepository);
            _getUserUsecase = new GetUserUsecase(_userRepository);

        }

        [HttpGet]
        public async Task<ActionResult<List<User>>> GetAllUsers()
        {
            try
            {
                List<User> users = await _getUserUsecase.GetAllUsers();
                return Ok(users);
            }
            catch (ApplicationException ex) { 
                return StatusCode(500, new {message = ex.Message});
            }
     
        }

        [HttpPost]
        public async Task<ActionResult<User>> CreateUser([FromBody] UserInsertDTO userInsert)
        {
            try
            {
                User user = await _createUserUsecase.CreateUser(userInsert);
                return Ok(user);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (ApplicationException ex)
            {
                 return StatusCode(500, new { message = ex.Message });
            }
 
        }

        [HttpPut("{userId}")]
        public async Task<IActionResult> UpdateUser(int userId ,UserModDTO userMod)
        {
            return StatusCode(500, new { message = "Unimplement endpoint" });
        }

        [HttpDelete("{userId}")]
        public async Task<IActionResult> DeleteUser(int userId)
        {
            return StatusCode(500, new { message = "Unimplement endpoint" });
        }

        [HttpPost("{userId}/buy/{productId}")]
        public async Task<IActionResult> BuyProduct(int userId , int productId)
        {
            return StatusCode(500, new { message = "Unimplement endpoint" });
        }

    }
}
