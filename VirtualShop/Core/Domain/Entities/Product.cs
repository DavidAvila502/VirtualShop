﻿namespace VirtualShop.Core.Domain.Entities
{
    public class Product
    {
        public required int Id { get; set; }
        public required string Name { get; set; }
        public required int Price { get; set; }
    }
}
