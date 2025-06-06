﻿namespace Drink.Infrastructure.Service
{
    public interface ICrudServiceAsync<T>
    {
        Task<bool> CreateAsync(T element);
        Task<T> ReadAsync(Guid id);
        Task<IEnumerable<T>> ReadAllAsync();
        Task<IEnumerable<T>> ReadAllAsync(int page, int amount);
        Task<bool> UpdateAsync(T element);
        Task<bool> RemoveAsync(T element);
        Task<bool> SaveAsync();
    }
}
