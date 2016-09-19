using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using api.Models;
using api.Repositories;

namespace api.Controllers
{
    [Route("api/[controller]")]
    public class StudentsController : Controller
    {
        private IStudentRepository studentRepo { get; set; }

        public StudentsController(IStudentRepository repo)
        {
            studentRepo = repo;
        }

        [HttpGet]
        public IEnumerable<Student> GetAll()
        {
            return studentRepo.GetAll();
        }
    }
}
