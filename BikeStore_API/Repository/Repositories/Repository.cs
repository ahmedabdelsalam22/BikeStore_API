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
            _dbset.Remove(entity);
        }

        public async Task<T> Get(Expression<Func<T, bool>>? filter = null, bool tracked = true, string[]? includes = null)
        {
            IQueryable<T> query = _dbset;
            if (filter != null) 
            {
                query = query.Where(filter);
            }
            if (!tracked) 
            {
                query = query.AsNoTracking();
            }
            if (includes != null) 
            {
                foreach (var include in includes)
                {
                    query = query.Include(include);
                }
            }
            return await query.FirstOrDefaultAsync();
        }

        public async Task<List<T>> GetAll(Expression<Func<T, bool>>? filter = null, bool tracked = true, string[]? includes = null)
        {
            IQueryable<T> query = _dbset;
            if (filter !=null)
            {
                query = query.Where(filter);
            }
            if (!tracked)
            {
                query = query.AsNoTracking();
            }
            if (includes != null)
            {
                foreach (var include in includes)
                {
                    query = query.Include(include);
                }
            }
            return await query.ToListAsync();
        }

        public void Update(T entity)
        {
            _db.Update(entity);
        }
    }
}
