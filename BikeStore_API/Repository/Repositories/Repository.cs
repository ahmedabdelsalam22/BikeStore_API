using BikeStore_API.Models;
using BikeStore_API.Repository.IRepositories;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

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

        public async Task Create(T entity)
        {
           await _dbset.AddAsync(entity);
        }

        public void Delete(T entity)
        {
            throw new NotImplementedException();
        }

        public Task<T> Get(Expression<Func<T, bool>>? filter = null)
        {
            throw new NotImplementedException();
        }

        public Task<List<T>> GetAll(Expression<Func<T, bool>>? filter = null)
        {
            throw new NotImplementedException();
        }

        public void Update(T entity)
        {
            throw new NotImplementedException();
        }
    }
}
