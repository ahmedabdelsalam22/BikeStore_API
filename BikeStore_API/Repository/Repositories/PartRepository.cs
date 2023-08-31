using BikeStore_API.Models;
using BikeStore_API.Repository.IRepositories;

namespace BikeStore_API.Repository.Repositories
{
    public class PartRepository : Repository<Part>, IPartRepository
    {
        private readonly BikeStoresContext _db;

        public PartRepository(BikeStoresContext db) : base(db)
        {
            _db = db;
        }

        public void Update(Part part)
        {
            _db.Update(part);
        }
    }
}
