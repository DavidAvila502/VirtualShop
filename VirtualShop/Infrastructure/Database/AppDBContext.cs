using VirtualShop.Core.Domain.Entities;

namespace VirtualShop.Infrastructure.Database
{
    public class AppDBContext
    {
        public List<User> Users { get; set; }
        public List<Product> Products { get; set; }

        public static AppDBContext CurrentData { get; } = new AppDBContext();

        public AppDBContext() {

            Users = new List<User>() 
            { 
                new User() { Id= 1, Name= "David", Funds = 500,Email= "david@gmail.com"}
            };


            Products = new List<Product>()
            {
                new Product(){Id= 1, Name="Lemonade", Price= 20}
            };

        }

    }
}
