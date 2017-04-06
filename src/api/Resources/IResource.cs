using System.Collections.Generic;
using System.Threading.Tasks;

namespace api.Resources
{
    public interface IResource<T>
    {
        //IEnumerable<T> List();
        Task<List<T>> ListAsync();
        //Task<T> FindAsync(int key);
        //Task<int> AddAsync(T item);
        //Task<int> RemoveAsync(int key);
        //Task<int> UpdateAsync(T item);
    }
}
