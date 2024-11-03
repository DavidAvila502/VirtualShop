using Microsoft.AspNetCore.Mvc;
using VirtualShop.Adapters.Output;
using VirtualShop.Core.Aplication.DTOs;
using VirtualShop.Core.Aplication.InputPorts;
using VirtualShop.Core.Aplication.Interfaces;
using VirtualShop.Core.Aplication.OutputPorts;
using VirtualShop.Core.Aplication.Usecases;
using VirtualShop.Core.Domain.Entities;

namespace VirtualShop.Adapters.Input.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase, IUserPort
    {
        private IUserRepository _userRepository;
        private IProductRepository _productRepository;

        private ICreateUserUsecase _createUserUsecase;
        private IGetUserUsecase _getUserUsecase;
        private IUpdateUserUsecase _updateUserUsecase;
        private IDeleteUserUsecase _deleteUserUsecase;
        private IBuyProductUsecase _buyProductUsecase;

        public UserController()
        {
            _userRepository = new UserRepository();
            _productRepository = new ProductRepository();

            _createUserUsecase = new CreateUserUsecase(_userRepository);
            _getUserUsecase = new GetUserUsecase(_userRepository);
            _updateUserUsecase = new UpdateUserUsecase(_userRepository);
            _deleteUserUsecase = new DeleteUserUsecase(_userRepository);
            _buyProductUsecase = new BuyProductUsecase(_userRepository, _productRepository);
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


        [HttpGet("{id}")]
        public async Task<ActionResult<User>> GetUserById(int id)
        {
            try 
            {
                User user =await  _getUserUsecase.GetUserById(id);

                return Ok(user);
            }
            catch (ArgumentException ex) 
            {
                return NotFound(ex.Message);

            }
        }

        [HttpPost]
        public async Task<ActionResult<User>> CreateUser([FromBody] UserInsertDTO userInsert)
        {
            try
            {
                User user = await _createUserUsecase.CreateUser(userInsert);

                return CreatedAtAction(nameof(GetUserById),new {Id = user.Id}, user);
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
            try
            {
                await _updateUserUsecase.UpdateUser(userId, userMod);

                return Ok("User successfully modified.");
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
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

        [HttpDelete("{userId}")]
        public async Task<IActionResult> DeleteUser(int userId)
        {
            try
            {
                User user = await _getUserUsecase.GetUserById(userId);

                await _deleteUserUsecase.DeleteUser(user);

                return Ok("The user was  successfully deleted.");
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

        [HttpPost("{userId}/buy/{productId}")]
        public async Task<IActionResult> BuyProduct(int userId , int productId)
        {
            try
            {
                await _buyProductUsecase.BuyProduct(userId, productId);
                return Ok("Purchase done.");

            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);  
            }
            catch(ApplicationException ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

    }
}
