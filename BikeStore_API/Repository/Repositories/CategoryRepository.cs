using BikeStore_API.DomainModels;
using BikeStore_API.Repository.IRepositories;

namespace BikeStore_API.Repository.Repositories
{
    public class CategoryRepository : Repository<Category>, ICategoryRepository
    {
        private readonly BikeStoresContext _db;
        public CategoryRepository(BikeStoresContext db) : base(db)
        {
            _db = db;
        }

        public void Update(Category category)
        {
            _db.Update(category);
        }

       
    }
}
