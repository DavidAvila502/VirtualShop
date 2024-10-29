using VirtualShop.Adapters.Output;
using VirtualShop.Core.Aplication.DTOs;
using VirtualShop.Core.Aplication.Interfaces;
using VirtualShop.Core.Domain.Entities;
using VirtualShop.Infrastructure.Database;
namespace VirtualShop.Core.Aplication.Usecases
{
    public class CreateUserUsecase: ICreateUserUsecase
    {
        private UserRepository _userRepository;

       public CreateUserUsecase(UserRepository userRepository)
        {
            _userRepository = userRepository;
        }


        public async Task<User> CreateUser(UserInsertDTO userInsert)
        {
            if (userInsert == null|| string.IsNullOrEmpty(userInsert.Name))
            {
                throw new ArgumentException("Invalid user data.");
            }

            try
            {
                int count = AppDBContext.CurrentData.Users.Count;

                int newId = count + 1;

                User newUser = new User()
                {
                    Id = newId,
                    Name = userInsert.Name,
                    Email = userInsert.Email,
                    Funds = userInsert.Funds
                };

                return await _userRepository.CreateUser(newUser);

            }
            catch (Exception ex)
            {
                throw new ApplicationException("Error trying to create the user.");
            }



        }
    }
}
