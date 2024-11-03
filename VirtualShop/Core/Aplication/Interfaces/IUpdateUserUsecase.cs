using VirtualShop.Core.Aplication.DTOs;

namespace VirtualShop.Core.Aplication.Interfaces
{
    interface IUpdateUserUsecase
    {
        public  Task UpdateUser(int id, UserModDTO userMod);
    }
}
