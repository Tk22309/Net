using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Coffe.Common
{
public interface ICrudService<T>
{
    void Create(T element);
    T Read(Guid id);
    IEnumerable<T> ReadAll();
    void Update(T element);
    void Remove(T element);
}

    public class CrudService<T> : ICrudService<T> where T : Drink
    {
        private readonly Dictionary<Guid, T> _data = new Dictionary<Guid, T>();

        public void Create(T element) => _data[element.Id] = element;
        public T Read(Guid id) => _data.ContainsKey(id) ? _data[id] : default;
        public IEnumerable<T> ReadAll() => _data.Values;
        public void Update(T element) => _data[element.Id] = element;
        public void Remove(T element) => _data.Remove(element.Id);
    }
}