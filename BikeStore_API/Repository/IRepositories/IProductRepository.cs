
using BikeStore_API.DomainModels;

namespace BikeStore_API.Repository.IRepositories
{
    public interface IProductRepository : IRepository<Product>
    {
        void Update(Product product);
    }
}
