using Microsoft.AspNetCore.Mvc;
using VirtualShop.Core.Aplication.DTOs;
using VirtualShop.Core.Domain.Entities;
namespace VirtualShop.Core.Aplication.InputPorts;

interface IUserPort
{

    public Task<ActionResult<User>> CreateUser(UserInsertDTO userInsert);

    public Task<IActionResult> BuyProduct(int userId , int productId);

}