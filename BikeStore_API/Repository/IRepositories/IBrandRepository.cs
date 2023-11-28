
using BikeStore_API.DomainModels;

namespace BikeStore_API.Repository.IRepositories
{
    public interface IBrandRepository : IRepository<Brand>
    {
        void Update(Brand brand);
    }
}
