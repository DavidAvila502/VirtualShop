using VirtualShop.Adapters.Output;
using VirtualShop.Core.Aplication.Interfaces;
using VirtualShop.Core.Domain.Entities;

namespace VirtualShop.Core.Aplication.Usecases
{
    public class DeleteUserUsecase:IDeleteUserUsecase
    {
        private UserRepository _userRepository;

        public DeleteUserUsecase(UserRepository useRepository)
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
