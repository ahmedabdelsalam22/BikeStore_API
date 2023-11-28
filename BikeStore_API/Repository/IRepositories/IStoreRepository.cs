using BikeStore_API.DomainModels;

namespace BikeStore_API.Repository.IRepositories
{
    public interface IStoreRepository : IRepository<Store>
    {
        void Update(Store store);
    }
}
