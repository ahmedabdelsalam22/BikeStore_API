using BikeStore_API.DomainModels;
using BikeStore_API.Repository.IRepositories;

namespace BikeStore_API.Repository.Repositories
{
    public class ProductRepository : Repository<Product>, IProductRepository
    {
        private readonly BikeStoresContext _db;
        public ProductRepository(BikeStoresContext db) : base(db)
        {
            _db = db;
        }

        public void Update(Product product)
        {
            _db.Update(product);
        }
    }
}
