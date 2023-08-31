using BikeStore_API.Repository.IRepositories;

namespace BikeStore_API.Repository.UnitOfWork
{
    public interface IUnitOfWork
    {
        Task Save();
        public IBrandRepository brandRepository { get; }
        public ICategoryRepository categoryRepository { get; }
        public ICustomerRepository customerRepository { get; }
        public IStoreRepository storeRepository { get; }
        public IPartRepository partRepository { get; }
    }
}
