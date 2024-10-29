using VirtualShop.Core.Aplication.DTOs;
using VirtualShop.Core.Domain.Entities;

namespace VirtualShop.Core.Aplication.Interfaces
{
    interface ICreateUserUsecase
    {
        public Task<User> CreateUser(UserInsertDTO user);

    }
}
