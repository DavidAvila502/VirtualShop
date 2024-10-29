using Microsoft.AspNetCore.Mvc;
using VirtualShop.Core.Aplication.DTOs;
using VirtualShop.Core.Domain.Entities;
namespace VirtualShop.Core.Aplication.InputPorts;

interface IUserPort
{
    public Task<ActionResult<List<User>>> GetAllUsers();

    public Task<ActionResult<User>> CreateUser(UserInsertDTO userInsert);

    public Task<IActionResult> UpdateUser(int id, UserModDTO userMod);

    public Task<IActionResult> DeleteUser(int id);

    public Task<IActionResult> BuyProduct(int userId , int productId);

}