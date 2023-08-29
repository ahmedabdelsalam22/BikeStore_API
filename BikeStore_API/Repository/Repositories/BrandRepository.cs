using BikeStore_API.Models;
using BikeStore_API.Repository.IRepositories;

namespace BikeStore_API.Repository.Repositories
{
    public class BrandRepository : Repository<Brand>, IBrandRepository
    {
        public BrandRepository(BikeStoresContext db) : base(db)
        {
        }
    }
}
