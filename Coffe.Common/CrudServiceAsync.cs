using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;

namespace Coffe.Common
{
    public class CrudServiceAsync<T> : ICrudServiceAsync<T> where T : Drink
    {
        private readonly Dictionary<Guid, T> _data = new Dictionary<Guid, T>();
        private readonly string _filePath;
        private readonly SemaphoreSlim _semaphore = new SemaphoreSlim(1, 1);

        public CrudServiceAsync(string filePath)
        {
            _filePath = filePath;
        }

        public async Task<bool> CreateAsync(T element)
        {
            await _semaphore.WaitAsync();
            try
            {
                _data[element.Id] = element;
                return true;
            }
            finally
            {
                _semaphore.Release();
            }
        }

        public async Task<T> ReadAsync(Guid id)
        {
            await _semaphore.WaitAsync();
            try
            {
                return _data.ContainsKey(id) ? _data[id] : null;
            }
            finally
            {
                _semaphore.Release();
            }
        }

        public async Task<IEnumerable<T>> ReadAllAsync()
        {
            await _semaphore.WaitAsync();
            try
            {
                return _data.Values.ToList();
            }
            finally
            {
                _semaphore.Release();
            }
        }

        public async Task<IEnumerable<T>> ReadAllAsync(int page, int amount)
        {
            await _semaphore.WaitAsync();
            try
            {
                return _data.Values.Skip((page - 1) * amount).Take(amount).ToList();
            }
            finally
            {
                _semaphore.Release();
            }
        }

        public async Task<bool> UpdateAsync(T element)
        {
            await _semaphore.WaitAsync();
            try
            {
                if (_data.ContainsKey(element.Id))
                {
                    _data[element.Id] = element;
                    return true;
                }
                return false;
            }
            finally
            {
                _semaphore.Release();
            }
        }

        public async Task<bool> RemoveAsync(T element)
        {
            await _semaphore.WaitAsync();
            try
            {
                return _data.Remove(element.Id);
            }
            finally
            {
                _semaphore.Release();
            }
        }

        public async Task<bool> SaveAsync()
        {
            await _semaphore.WaitAsync();
            try
            {
                var json = JsonSerializer.Serialize(_data.Values, new JsonSerializerOptions { WriteIndented = true });
                File.WriteAllText(_filePath, json); // Синхронно, сумісно з C# 7.3
                return true;
            }
            finally
            {
                _semaphore.Release();
            }
        }

        public IEnumerator<T> GetEnumerator()
        {
            return _data.Values.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
