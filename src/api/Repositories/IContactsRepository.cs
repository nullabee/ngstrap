using System.Collections.Generic;
using api.Models;

namespace api.Repositories
{
    public interface IContactsRepository
    {
        void Add(Contacts item);
        IEnumerable<Contacts> GetAll();
        Contacts Find(string key);
        void Remove(string Id);
        void Update(Contacts item);
    }
}
