﻿using VirtualShop.Adapters.Output;
using VirtualShop.Core.Aplication.Interfaces;
using VirtualShop.Core.Domain.Entities;

namespace VirtualShop.Core.Aplication.Usecases
{
    public class GetUserUsecase:IGetUserUsecase
    {
       private UserRepository _userRepository;

       public GetUserUsecase(UserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<List<User>> GetAllUsers()
        {
            try
            {
                return await _userRepository.GetAllUsers();
            }
            catch (Exception ex) {

                throw new ApplicationException("Error trying to get the users.");
            }
        }

        public  async Task<User> GetUserById(int id)
        {
                User? user= await _userRepository.GetUserById(id);

                if (user == null) 
                {
                throw new ArgumentException("The requested user does not exist.");
                
                }
                return user;
        }

    }
}
