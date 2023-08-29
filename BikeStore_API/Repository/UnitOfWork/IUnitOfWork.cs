using BikeStore_API.Repository.IRepositories;

namespace BikeStore_API.Repository.UnitOfWork
{
    public interface IUnitOfWork
    {
        public IBrandRepository brandRepository { get; }
    }
}
