namespace VirtualShop.Core.Aplication.DTOs
{
    public class ProductModDTO
    {
        public int Id { get; set; }

        public required string Name { get; set; }

        public required int Price  { get; set; }
    }
}
