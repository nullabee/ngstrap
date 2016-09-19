using System;
using System.Collections.Generic;
using System.Linq;
using api.Models;
using api.Data;

namespace api.Resources
{
    public class StudentResource : IResource<Student>
    {
        private readonly DataContext context;

        public StudentResource(DataContext context)
        {
            this.context = context;
        }

        public IEnumerable<Student> GetAll()
        {
            return context.Students;
        }

        public Student Find(string key)
        {
            int id = Int32.Parse(key);
            return context.Students
                .Where(r => r.Id == id)
                .SingleOrDefault();
        }

        public void Add(Student item)
        {
            context.Students.Add(item);
            context.SaveChanges();
        }
        
        public bool Remove(string key)
        {
            var res = Find(key);
            if (res != null)
            {
                context.Students.Remove(res);
                context.SaveChanges();
                return true;
            }
            return false;
        }

        public bool Update(Student item)
        {
            var res = Find(item.Id.ToString());
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
