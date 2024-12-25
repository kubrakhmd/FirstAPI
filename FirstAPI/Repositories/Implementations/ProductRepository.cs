using FirstAPI.DAL;
using FirstAPI.Entity;
using FirstAPI.Repositories.Interfaces;
using FirstAPI.Repostories.Implementations;

namespace FirstAPI.Repositories.Implementations
{
    public class ProductRepository : Repository<Product>, IProductRepository
    {
        public ProductRepository(AppDbContext context) : base(context) { }

    }
}
