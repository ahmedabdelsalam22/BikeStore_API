using BikeStore_API.Models;
using BikeStore_API.Repository.IRepositories;

namespace BikeStore_API.Repository.Repositories
{
    public class BrandRepository : Repository<Brand>, IBrandRepository
    {
        private readonly BikeStoresContext _context;
        public BrandRepository(BikeStoresContext context) : base(context)
        {
            _context = context;
        }

        public void Update(Brand brand)
        {
            _context.Update(brand);
        }
    }
}
