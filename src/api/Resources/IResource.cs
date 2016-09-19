using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.Resources
{
    public interface IResource<T>
    {
        IEnumerable<T> GetAll();
        T Find(string key);
        void Add(T item);
        bool Remove(string key);
        bool Update(T item);
    }
}
