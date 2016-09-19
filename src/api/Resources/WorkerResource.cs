using System;
using System.Collections.Generic;
using System.Linq;
using api.Models;
using api.Data;

namespace api.Resources
{
    public class WorkerResource : IResource<Worker>
    {
        private readonly WorkerContext context;
        
        public WorkerResource(WorkerContext context)
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

        public void Remove(string key)
        {
            var res = context.Workers.SingleOrDefault(r => r.Email == key);
            if (res != null)
                context.Workers.Remove(res);
        }

        public void Update(Worker item)
        {
            var res = context.Workers.SingleOrDefault(r => r.Email == item.Email);
            if (res != null)
            {
                res.FirstName = item.FirstName;
                res.LastName = item.LastName;
                res.Email = item.Email;
            }
        }
    }
}
