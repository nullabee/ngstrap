using System;
using System.Collections.Generic;
using System.Linq;
using api.Models;


namespace api.Resources
{
    public class StudentResource : IResource<Student>
    {
        private static List<Student> students = new List<Student> {
            new Student { FirstName = "John", LastName = "Doe", Email = "john@example.com"},
            new Student { FirstName = "Mary", LastName = "Moe", Email = "mary@example.com"},
            new Student { FirstName = "July", LastName = "Dooley", Email = "july@example.com"}
        };
        
        public IEnumerable<Student> GetAll()
        {
            return students;
        }

        public Student Find(string key)
        {
            return students
                .Where(r => r.Email.Equals(key))
                .SingleOrDefault();
        }

        public void Add(Student item)
        {
            students.Add(item);
        }
        
        public void Remove(string key)
        {
            var res = students.SingleOrDefault(r => r.Email == key);
            if (res != null)
                students.Remove(res);
        }

        public void Update(Student item)
        {
            var res = students.SingleOrDefault(r => r.Email == item.Email);
            if (res != null)
            {
                res.FirstName = item.FirstName;
                res.LastName = item.LastName;
                res.Email = item.Email;
            }
        }
    }
}
