namespace VirtualShop.Core.Aplication.DTOs
{
    public class UserInsertDTO
    {
        public required string Name { get; set; } 

        public  string? Email { get; set; }

        public required int Funds { get; set; }

    }
}
