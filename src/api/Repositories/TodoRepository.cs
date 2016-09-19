using System;
using System.Collections.Generic;
using System.Collections.Concurrent;
using api.Models;

namespace api.Repositories
{
    public class TodoRepository : ITodoRepository
    {
        private static ConcurrentDictionary<string, TodoItem> _todos =
              new ConcurrentDictionary<string, TodoItem>();

        public TodoRepository()
        {
            Add(new TodoItem { Name = "Item1" });
            Add(new TodoItem { Name = "Item2" });
        }

        public IEnumerable<TodoItem> GetAll()
        {
            return _todos.Values;
        }

        public TodoItem Find(string key)
        {
            TodoItem item;
            _todos.TryGetValue(key, out item);
            return item;
        }

        public void Add(TodoItem item)
        {
            item.Id = Guid.NewGuid().ToString();
            _todos[item.Id] = item;
        }

        public void Remove(string key)
        {
            TodoItem item;
            _todos.TryRemove(key, out item);
        }

        public void Update(TodoItem item)
        {
            _todos[item.Id] = item;
        }
    }
}