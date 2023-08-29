using Microsoft.EntityFrameworkCore;

namespace BikeStore_API.Data
{
    public class DbContextClass : DbContext
    {
        public DbContextClass(DbContextOptions options) : base(options)
        {
        }
    }
}
