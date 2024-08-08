namespace MagazynAPI.Entities
{
    public class Storage
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string? Category { get; set; }
        public string? ContactEmail { get; set; }
        public string? ContactNumber { get; set; }

        public int? AddressId { get; set; }
        public virtual Address Address { get; set; }
        
        public virtual List<Item> Itemes { get; set; }
    }
}
