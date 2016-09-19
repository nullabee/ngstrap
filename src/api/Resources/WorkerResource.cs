using System;
using System.Collections.Generic;
using System.Linq;
using api.Models;
using api.Data;

namespace api.Resources
{
    public class WorkerResource : IResource<Worker>
    {
        private readonly DataContext context;
        
        public WorkerResource(DataContext context)
        {
            this.context = context;
        }

        public IEnumerable<Worker> GetAll()
        {
            return context.Workers;
        }

        public Worker Find(string key)
        {
            return context.Workers
                .Where(r => r.Email.Equals(key))
                .SingleOrDefault();
        }

        public void Add(Worker item)
        {
            context.Workers.Add(item);
            context.SaveChanges();
        }

        public bool Remove(string key)
        {
            var res = Find(key);
            if (res != null)
            {
                context.Workers.Remove(res);
                context.SaveChanges();
                return true;
            }
            return false;
        }

        public bool Update(Worker item)
        {
            var res = Find(item.Email);
            if (res != null)
            {
                res.FirstName = item.FirstName;
                res.LastName = item.LastName;
                res.Email = item.Email;
                context.SaveChanges();
                return true;
            }

            return false;           
        }
    }
}
