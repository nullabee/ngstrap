using System;
using System.Collections.Generic;
using System.Linq;
using api.Models;


namespace api.Repositories
{
    public class StudentRepository : IStudentRepository
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
                .Where(e => e.Email.Equals(key))
                .SingleOrDefault();
        }

        public void Add(Student item)
        {
            students.Add(item);
        }
        
        public void Remove(string key)
        {
            var itemToRemove = students.SingleOrDefault(r => r.Email == key);
            if (itemToRemove != null)
                students.Remove(itemToRemove);
        }

        public void Update(Student item)
        {
            var itemToUpdate = students.SingleOrDefault(r => r.Email == item.Email);
            if (itemToUpdate != null)
            {
                itemToUpdate.FirstName = item.FirstName;
                itemToUpdate.LastName = item.LastName;
                itemToUpdate.Email = item.Email;
            }
        }
    }
}
