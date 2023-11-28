using System.ComponentModel.DataAnnotations;

namespace BikeStore_API.DomainModels
{
    public class Part
    {
        [Key]
        public int PartId { get; set; }
        public string? PartName { get; set; }
    }
}
