using VirtualShop.Adapters.Output;
using VirtualShop.Core.Aplication.Interfaces;
using VirtualShop.Core.Aplication.OutputPorts;
using VirtualShop.Core.Domain.Entities;

namespace VirtualShop.Core.Aplication.Usecases
{
    public class DeleteUserUsecase:IDeleteUserUsecase
    {
        private IUserRepository _userRepository;

        public DeleteUserUsecase(IUserRepository useRepository)
        {
            _userRepository = useRepository;
        }

        public async Task DeleteUser(User user)
        {
            int userId = user.Id;

            User? foundUser = await _userRepository.GetUserById(userId);

            if (foundUser == null) {

                throw new KeyNotFoundException("The requested user does not exist.");
            }

            try
            {
                await _userRepository.DeleteUser(user);
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Error trying to delete the user.");
            }
        }

    }
}
