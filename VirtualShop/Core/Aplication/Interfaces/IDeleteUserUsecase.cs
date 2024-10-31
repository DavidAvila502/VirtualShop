using VirtualShop.Core.Domain.Entities;

namespace VirtualShop.Core.Aplication.Interfaces
{
    interface IDeleteUserUsecase
    {
        public Task DeleteUser(User user);
    }
}
