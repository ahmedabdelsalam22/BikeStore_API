using BikeStore_API.DomainModels;

namespace BikeStore_API.Repository.IRepositories
{
    public interface ICustomerRepository : IRepository<Customer>
    {
        void Update(Customer customer);
    }
}
