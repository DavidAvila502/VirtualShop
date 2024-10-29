using Microsoft.AspNetCore.Mvc;
using VirtualShop.Core.Aplication.DTOs;
using VirtualShop.Core.Aplication.OutputPorts;
using VirtualShop.Core.Domain.Entities;
using VirtualShop.Infrastructure.Database;
namespace VirtualShop.Adapters.Output
{
    public class UserRepository:IUserRepository
    {
        private Random rdn = new Random();

        public async Task<List<User>> GetAllUsers() 
        {
            int seleepValue = rdn.Next(5000);

            Task.Delay(seleepValue).Wait();

            return AppDBContext.CurrentData.Users;

        }

        public  async Task<User> CreateUser(User user)
        {
            int seleepValue = rdn.Next(5000);

            Task.Delay(seleepValue).Wait();

            List<User> AllUsers = AppDBContext.CurrentData.Users;

            AllUsers.Add(user);

            return user;
        }

        public async Task UpdateUser(int id, UserModDTO userModDTO)
        {
            int seleepValue = rdn.Next(5000);

            Task.Delay(seleepValue).Wait();

            List<User> AllUsers = AppDBContext.CurrentData.Users;
            
            User user = AllUsers.FirstOrDefault(x => x.Id == id);

            user.Name= userModDTO.Name;
            user.Email= userModDTO.Email;
            user.Funds= userModDTO.Funds;

            
        }
        public async Task DeleteUser(User user)
        {
            int seleepValue = rdn.Next(5000);

            Task.Delay(seleepValue).Wait();

            List<User> AllUsers = AppDBContext.CurrentData.Users;

            AllUsers.Remove(user);
        } 
    }
}
