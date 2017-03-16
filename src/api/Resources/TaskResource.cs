using System;
using System.Collections.Generic;
using System.Linq;
using api.Models;
using api.Data;

namespace api.Resources
{
    public class TaskResource : IResource<Task>
    {
        private readonly DataContext context;
        
        public TaskResource(DataContext context)
        {
            this.context = context;
        }

        public IEnumerable<Task> GetAll()
        {
            return context.Tasks;
        }

        public Task Find(string key)
        {
            return context.Tasks
                .Where(r => r.Id.Equals(key))
                .SingleOrDefault();
        }

        public void Add(Task item)
        {
            context.Tasks.Add(item);
            context.SaveChanges();
        }

        public bool Remove(string key)
        {
            var res = Find(key);
            if (res != null)
            {
                context.Tasks.Remove(res);
                context.SaveChanges();
                return true;
            }
            return false;
        }

        public bool Update(Task item)
        {
            var res = Find(item.Id);
            if (res != null)
            {
                res.Title = item.Title;
                res.Description = item.Description;
                res.UserId = item.UserId;
                context.SaveChanges();
                return true;
            }

            return false;           
        }
    }
}
