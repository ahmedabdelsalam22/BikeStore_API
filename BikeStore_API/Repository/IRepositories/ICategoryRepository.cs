using BikeStore_API.Models;

namespace BikeStore_API.Repository.IRepositories
{
    public interface ICategoryRepository : IRepository<Category>
    {
        void Update(Category category);
    }
}
