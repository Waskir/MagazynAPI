using System.ComponentModel.DataAnnotations;

namespace MagazynAPI.Models
{
    public class CreateStorageDto
    {
        [Required]
        [MaxLength(25)]
        public string Name { get; set; }
        public string? Category { get; set; }
        [EmailAddress]
        public string? ContactEmail { get; set; }
        [Phone]
        public string? ContactNumber { get; set; }
        [Required]
        [MaxLength(50)]
        public string City { get; set; }
        [Required]
        [MaxLength(50)]
        public string Street { get; set; }
        public string PostCode { get; set; }
    }
}
