using System.Collections.Generic;
using api.Models;

namespace api.Repositories
{
    public interface IContactsRepository
    {
        IEnumerable<Contacts> GetAll();
        Contacts Find(string key);
        void Add(Contacts item);
        void Remove(string key);
        void Update(Contacts item);
    }
}
