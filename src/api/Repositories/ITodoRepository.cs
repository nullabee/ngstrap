using System.Collections.Generic;
using api.Models;

namespace api.Repositories
{
    public interface ITodoRepository
    {
        IEnumerable<TodoItem> GetAll();
        TodoItem Find(string key);
        void Add(TodoItem item);
        void Remove(string key);
        void Update(TodoItem item);
    }
}
