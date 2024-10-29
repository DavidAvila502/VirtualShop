namespace VirtualShop.Core.Aplication.DTOs
{
    public class UserModDTO
    {
        public required int Id { get; set; }
        public required string Name { get; set; }
        public string? Email {  get; set; }
        public required int Funds { get; set; }
    }
}
