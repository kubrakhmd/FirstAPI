using System.Linq;
using System.Linq.Expressions;
using FirstAPI.DAL;
using FirstAPI.Entity;
using FirstAPI.Repostories.Interfaces;
using Microsoft.EntityFrameworkCore;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace FirstAPI.Repostories.Implementations
{
    public class Repository<T> : IRepository<T> where T : BaseEntity, new()
    {
        private readonly AppDbContext _context;
        private readonly DbSet<T> _table;

        public Repository(AppDbContext context)
        {
            _context = context;
            _table = context.Set<T>();
        }
        public IQueryable<T> GetAll(Expression<Func<T, bool>>? expression = null,
             Expression<Func<T, object>>? sort = null,
            bool IsDescending = false,
            bool IsTracking = false,
            int skip = 0,
            int take = 0,
            params string[]? includes)

        { 
            IQueryable<T> query = _table;
            if(expression != null) query = query.Where(expression);
            if(includes != null)
            {
                for(int i = 0; i<includes.Length; i++)
                {
                    query=query.Include(includes[i]);
                }
            }
            if (sort!= null) query = IsDescending ? query.OrderByDescending(sort) : query.OrderBy(sort);
            if (take != 0) query = query.Take(take);
                              return IsTracking ? query : query.AsNoTracking();   
           
        }

        public async Task<T> GetbyIdAsync(int? id)
        {
            return await _table.FirstOrDefaultAsync(c => c.Id == id);
        }


        public async Task AddAsync(T entity)
        {
            await _table.AddAsync(entity);
        }

        public void Delete(T entity)
        {
            _table.Remove(entity);
        }


        public void Update(T entity)
        {
            _table.Update(entity);
        }

        public async Task<int> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync();
        }

       
    }
}
