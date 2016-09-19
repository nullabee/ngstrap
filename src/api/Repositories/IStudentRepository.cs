using System.Collections.Generic;
using api.Models;

namespace api.Repositories
{
    public interface IStudentRepository
    {
        IEnumerable<Student> GetAll();
        Student Find(string key);
        void Add(Student item);
        void Remove(string key);
        void Update(Student item);
    }
}
