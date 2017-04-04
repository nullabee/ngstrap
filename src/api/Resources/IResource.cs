using System.Collections.Generic;

namespace api.Resources
{
    public interface IResource<T>
    {
        IEnumerable<T> GetAll();
        T Find(int key);
        void Add(T item);
        bool Remove(int key);
        bool Update(T item);
    }
}
