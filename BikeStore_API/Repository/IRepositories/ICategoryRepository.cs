using BikeStore_API.DomainModels;

namespace BikeStore_API.Repository.IRepositories
{
    public interface ICategoryRepository : IRepository<Category>
    {
        void Update(Category category);
    }
}
