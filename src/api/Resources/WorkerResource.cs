using System;
using System.Collections.Generic;
using System.Linq;
using api.Models;


namespace api.Resources
{
    public class WorkerResource : IResource<Worker>
    {
        private static List<Worker> workers = new List<Worker> {
            new Worker { FirstName = "John", LastName = "Doe", Email = "john@example.com"},
            new Worker { FirstName = "Mary", LastName = "Moe", Email = "mary@example.com"},
            new Worker { FirstName = "July", LastName = "Dooley", Email = "july@example.com"}
        };
        
        public IEnumerable<Worker> GetAll()
        {
            return workers;
        }

        public Worker Find(string key)
        {
            return workers
                .Where(r => r.Email.Equals(key))
                .SingleOrDefault();
        }

        public void Add(Worker item)
        {
            workers.Add(item);
        }
        
        public void Remove(string key)
        {
            var res = workers.SingleOrDefault(r => r.Email == key);
            if (res != null)
                workers.Remove(res);
        }

        public void Update(Worker item)
        {
            var res = workers.SingleOrDefault(r => r.Email == item.Email);
            if (res != null)
            {
                res.FirstName = item.FirstName;
                res.LastName = item.LastName;
                res.Email = item.Email;
            }
        }
    }
}
