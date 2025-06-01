﻿using System.Collections.Generic;
using System.Threading.Tasks;

namespace MauiLib3._1.Infrastructure
{
    public interface IRepository<T> where T : class
    {
        Task<T?> GetByIdAsync(int id);
        Task<IEnumerable<T>> GetAllAsync();
        Task AddAsync(T entity);
        Task Update(T entity);
        Task Delete(T entity);
    }
}
