using System.ComponentModel.DataAnnotations;

namespace BikeStore_API.DTOS
{
    public class CustomerCreateDTO
    {
        [Required]
        public string FirstName { get; set; } = null!;
        [Required]
        public string LastName { get; set; } = null!;

        public string? Phone { get; set; }
        [Required]
        public string Email { get; set; } = null!;

        public string? Street { get; set; }

        public string? City { get; set; }

        public string? State { get; set; }

        public string? ZipCode { get; set; }
    }
}
