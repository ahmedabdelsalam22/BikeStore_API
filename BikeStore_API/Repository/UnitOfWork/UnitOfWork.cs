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
        }
        public IBrandRepository brandRepository { get; private set; }
    }
}
