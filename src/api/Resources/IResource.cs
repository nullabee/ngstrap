using System.Collections.Generic;
using System.Threading.Tasks;

namespace api.Resources
{
    public interface IResource<T>
    {
        Task<List<T>> GetAll();
        Task<T> Find(int key);
        void Add(T item);
        bool Remove(int key);
        bool Update(T item);
    }
}
