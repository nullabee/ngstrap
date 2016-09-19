using System;
using System.Collections.Generic;
using System.Collections.Concurrent;
using api.Models;

namespace api.Resources
{
    public class TodoResource : IResource<Todo>
    {
        private static ConcurrentDictionary<string, Todo> todos =
              new ConcurrentDictionary<string, Todo>();

        public TodoResource()
        {
            Add(new Todo { Name = "Item1" });
            Add(new Todo { Name = "Item2" });
        }

        public IEnumerable<Todo> GetAll()
        {
            return todos.Values;
        }

        public Todo Find(string key)
        {
            Todo item;
            todos.TryGetValue(key, out item);
            return item;
        }

        public void Add(Todo item)
        {
            item.Key = Guid.NewGuid().ToString();
            todos[item.Key] = item;
        }

        public bool Remove(string key)
        {
            Todo item;
            return todos.TryRemove(key, out item);
        }

        public bool Update(Todo item)
        {
            todos[item.Key] = item;
            return true;
        }
    }
}