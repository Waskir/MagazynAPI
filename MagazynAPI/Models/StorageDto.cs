﻿namespace MagazynAPI.Models
{
    public class StorageDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string? Category { get; set; }
        public string City { get; set; }
        public string Street { get; set; }
        public string PostalCode { get; set; }

        public List<ItemDto> Items { get; set; }
    }
}
