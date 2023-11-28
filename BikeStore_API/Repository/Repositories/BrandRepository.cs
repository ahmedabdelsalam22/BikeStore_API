using BikeStore_API.DomainModels;
using BikeStore_API.Repository.IRepositories;

namespace BikeStore_API.Repository.Repositories
{
    public class BrandRepository : Repository<Brand>, IBrandRepository
    {
        private readonly BikeStoresContext _db;

        public BrandRepository(BikeStoresContext db) : base(db)
        {
            _db = db;   
        }

        public void Update(Brand brand)
        {
            _db.Brands.Update(brand);
        }
    }
}
