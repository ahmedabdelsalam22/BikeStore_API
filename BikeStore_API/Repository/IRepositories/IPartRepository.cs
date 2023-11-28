using BikeStore_API.DomainModels;

namespace BikeStore_API.Repository.IRepositories
{
    public interface IPartRepository : IRepository<Part>
    {
        void Update(Part part);
    }
}
