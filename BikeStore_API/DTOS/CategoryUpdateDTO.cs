using System.Security.Principal;

namespace BikeStore_API.DTOS
{
    public class CategoryUpdateDTO
    {
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
    }
}
