using BikeStore_API.Repository.IRepositories;

namespace BikeStore_API.Repository.UnitOfWork
{
    public interface IUnitOfWork
    {
        Task Save();
        public IBrandRepository brandRepository { get; }
        public ICategoryRepository categoryRepository { get; }
    }
}
