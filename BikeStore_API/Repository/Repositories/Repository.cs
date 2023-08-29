using BikeStore_API.Models;
using BikeStore_API.Repository.IRepositories;
using Microsoft.EntityFrameworkCore;

namespace BikeStore_API.Repository.Repositories
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly BikeStoresContext _db;
        private readonly DbSet<T> _dbset;
        public Repository(BikeStoresContext db)
        {
            _db = db;
            _dbset = _db.Set<T>();
        }
        public void Create()
        {
            throw new NotImplementedException();
        }

        public void Delete()
        {
            throw new NotImplementedException();
        }

        public Task<T> Get(System.Linq.Expressions.Expression<Func<T, bool>>? filter = null)
        {
            throw new NotImplementedException();
        }

        public Task<List<T>> GetAll(System.Linq.Expressions.Expression<Func<T, bool>>? filter = null)
        {
            throw new NotImplementedException();
        }

        public void Update()
        {
            throw new NotImplementedException();
        }
    }
: class
    {
    }
}
