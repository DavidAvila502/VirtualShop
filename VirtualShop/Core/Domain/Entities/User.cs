namespace VirtualShop.Core.Domain.Entities;


public class User
{
    public int Id { get; set; }
    public required string Name { get; set; }
    public  string? Email { get; set; }
    public required int Funds { get; set; }
}
