using BikeStore_API.Models;

namespace BikeStore_API.Repository.IRepositories
{
    public interface IStoreRepository : IRepository<Store>
    {
        void Update(Store store);
    }
}
