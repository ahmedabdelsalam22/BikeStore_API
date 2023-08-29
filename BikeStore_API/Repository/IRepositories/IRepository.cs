using Microsoft.EntityFrameworkCore.ChangeTracking;
using System.Linq.Expressions;

namespace BikeStore_API.Repository.IRepositories
{
    public interface IRepository<T> where T : class
    {
        Task<List<T>> GetAll(Expression<Func<T,bool>>? filter = null,bool tracked = true,string[]? includes=null);
        Task<T> Get(Expression<Func<T,bool>>? filter=null, bool tracked = true,string[]? includes = null);
        Task Create(T entity);
        void Update(T entity);
        void Delete(T entity);
    }
}
