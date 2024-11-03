using VirtualShop.Core.Domain.Entities;

namespace VirtualShop.Core.Aplication.Interfaces
{
    interface IGetUserUsecase
    {
        public Task<List<User>> GetAllUsers();
        public Task<User> GetUserById(int id);
    }
}
