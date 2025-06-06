﻿using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace Drink.Infrastructure
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly CoffeContext _context;
        private readonly DbSet<T> _dbSet;

        public Repository(CoffeContext context)
        {
            _context = context;
            _dbSet = _context.Set<T>();
        }

        public async Task<T> GetByIdAsync(Guid id) => await _dbSet.FindAsync(id);
        public async Task<IEnumerable<T>> GetAllAsync() => await _dbSet.ToListAsync();
        public async Task AddAsync(T entity) { await _dbSet.AddAsync(entity); await _context.SaveChangesAsync(); }
        public async Task Update(T entity) { _dbSet.Update(entity); await _context.SaveChangesAsync(); }
        public async Task Delete(T entity) { _dbSet.Remove(entity); await _context.SaveChangesAsync(); }
    }
}