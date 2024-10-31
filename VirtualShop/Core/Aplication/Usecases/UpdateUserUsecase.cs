using VirtualShop.Adapters.Output;
using VirtualShop.Core.Aplication.DTOs;
using VirtualShop.Core.Aplication.Interfaces;
using VirtualShop.Core.Domain.Entities;

namespace VirtualShop.Core.Aplication.Usecases
{
    public class UpdateUserUsecase:IUpdateUserUsecase
    {

        private UserRepository _userRepository;
        
        public UpdateUserUsecase(UserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task UpdateUser(int id , UserModDTO userMod)
        {

            if (id != userMod.Id) {
                throw new ArgumentException("El Id enviado no pertenece al usuario a modificar.");
            
            }

            User? user =await  _userRepository.GetUserById(id);

            if (user == null) 
            {
                throw new KeyNotFoundException("This user does not exist.");
            }

            try
            {

                await _userRepository.UpdateUser(id, userMod);

            }
            catch (Exception ex) {

                throw new ApplicationException("Error trying to update the user.");
            
            }

        }
        
    }
}
