﻿using Microsoft.AspNetCore.Mvc;
using VirtualShop.Core.Aplication.DTOs;
using VirtualShop.Core.Domain.Entities;

namespace VirtualShop.Core.Aplication.OutputPorts
{
    interface IUserRepository{
        public Task<List<User>> GetAllUsers();

        public Task<User> CreateUser(User user);

        public Task UpdateUser(int id, UserModDTO userMod);

        public Task DeleteUser(User user);
    }
}
