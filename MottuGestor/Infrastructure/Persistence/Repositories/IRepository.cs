﻿using MottuGestor.API.Domain.Entities;

namespace MottuGestor.Infrastructure.Persistence.Repositories
{
    public interface IRepository<T> where T : class
    {
        Task<IEnumerable<T>> GetAllAsync();
        Task<T> GetByIdAsync(Guid id);
        Task AddAsync(T entity);
        void Update(T entity);
        void Delete(T entity);
        Task SaveChangesAsync();
        Task DeleteAsync(Guid id);
        Task UpdateAsync(T entity);
    }

}
