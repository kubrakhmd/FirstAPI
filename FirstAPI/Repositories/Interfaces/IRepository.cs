﻿using System.Linq.Expressions;
using FirstAPI.Entity;

namespace FirstAPI.Repostories.Interfaces
{
    public interface IRepository<T> where T : BaseEntity, new()
    {
        IQueryable<T> GetAll(
             Expression<Func<T, bool>>? expression = null,
             Expression<Func<T, object>>? sort = null,
             bool IsDescending = false,
             bool IsTracking = false,
             int skip = 0,
             int take = 0,
             params string[]? includes);
        Task<T> GetbyIdAsync(int? id);

        Task AddAsync(T entity);

        void Delete(T entity);

        void Update(T entity);

       
        Task<int> SaveChangesAsync();
    }
}
