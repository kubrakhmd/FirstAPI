using FirstAPI.DAL;
using FirstAPI.Entity;
using FirstAPI.Repositories.Interfaces;
using FirstAPI.Repostories.Implementations;

namespace FirstAPI.Repositories.Implementations
{
    public class CategoryRepository : Repository<Category>, ICategoryRepository
    {
        public CategoryRepository(AppDbContext context) : base(context) { }
    }
}
