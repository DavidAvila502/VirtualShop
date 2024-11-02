using VirtualShop.Core.Aplication.DTOs;
using VirtualShop.Core.Aplication.Interfaces;
using VirtualShop.Core.Aplication.OutputPorts;
using VirtualShop.Core.Domain.Entities;

namespace VirtualShop.Core.Aplication.Usecases
{
    public class BuyProductUsecase:IBuyProductUsecase
    {
        private IUserRepository _userRepository;
        private IProductRepository _productRepository;

        public BuyProductUsecase(IUserRepository userRepository, IProductRepository productRepository)
        {
            _userRepository = userRepository;
            _productRepository = productRepository;
        }

        public async Task BuyProduct(int userId, int productId)
        {
            User? user = await _userRepository.GetUserById(userId);

            if (user == null) {
                throw new KeyNotFoundException("The user does not exist.");
            }

            Product? product = await _productRepository.GetProductById(productId);

            if (product == null) {
                throw new KeyNotFoundException("The product does not exist.");
            }

            if(user.Funds < product.Price)
            {
                throw new ArgumentException("The user have not enough funds.");

            }

            try
            {
                await _userRepository.UpdateUser(userId, new UserModDTO()
                {
                    Id = userId,
                    Email = user.Email,
                    Name = user.Name,
                    Funds = (user.Funds - product.Price)
                });

                await _productRepository.DeleteProduct(product);
            }
            catch (Exception ex) 
            {
                throw new ApplicationException("Something was wrong trying to do the transaction.");
            }


        }
    }
}
