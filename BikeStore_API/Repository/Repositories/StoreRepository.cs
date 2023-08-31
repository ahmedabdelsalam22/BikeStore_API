using BikeStore_API.Models;
using BikeStore_API.Repository.IRepositories;

namespace BikeStore_API.Repository.Repositories
{
    public class StoreRepository : Repository<Store>, IStoreRepository
    {
        private readonly BikeStoresContext _db;
        public StoreRepository(BikeStoresContext db) : base(db)
        {
            _db = db;
        }
        public void Update(Store store)
        {
            _db.Update(store);
        }
    }
}
