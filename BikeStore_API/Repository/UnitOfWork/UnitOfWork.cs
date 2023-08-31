using BikeStore_API.Models;
using BikeStore_API.Repository.IRepositories;
using BikeStore_API.Repository.Repositories;

namespace BikeStore_API.Repository.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly BikeStoresContext _db;
        public UnitOfWork(BikeStoresContext db)
        {
            _db = db;
            brandRepository = new BrandRepository(_db);
            categoryRepository = new CategoryRepository(_db);
            customerRepository = new CustomerRepository(_db);
            storeRepository = new StoreRepository(_db);
            partRepository = new PartRepository(_db);
        }
        public IBrandRepository brandRepository { get; private set; }

        public ICategoryRepository categoryRepository { get; private set; }
        public ICustomerRepository customerRepository { get; private set; }
        public IStoreRepository storeRepository { get; private set; }
        public IPartRepository partRepository { get; private set; }

        public async Task Save()
        {
            await _db.SaveChangesAsync();
        }
    }
}
