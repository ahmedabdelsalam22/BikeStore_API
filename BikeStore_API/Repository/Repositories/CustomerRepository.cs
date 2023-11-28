using BikeStore_API.DomainModels;
using BikeStore_API.Repository.IRepositories;

namespace BikeStore_API.Repository.Repositories
{
    public class CustomerRepository : Repository<Customer>, ICustomerRepository
    {
        private readonly BikeStoresContext _db;
        public CustomerRepository(BikeStoresContext db) : base(db)
        {
            _db = db;
        }
        public void Update(Customer customer) 
        {
            _db.Update(customer);
        }
    }
}
