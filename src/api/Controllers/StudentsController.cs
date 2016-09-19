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


        [HttpGet("{id}", Name = "GetById2")]
        public IActionResult GetById(string id)
        {
            var item = studentRepo.Find(id);
            if (item == null)
            {
                return NotFound();
            }
            return new ObjectResult(item);
        }

        [HttpPost]
        public IActionResult Create([FromBody] Student item)
        {
            if (item == null)
            {
                return BadRequest();
            }
            studentRepo.Add(item);
            return CreatedAtRoute("GetById2", new { Controller = "Students", id = item.Email }, item);
        }

    }
}
