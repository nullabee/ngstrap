using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using api.Models;
using api.Resources;

namespace api.Controllers
{
    [Route("api/[controller]")]
    public class StudentsController : Controller
    {
        private IResource<Student> resource { get; set; }

        public StudentsController(IResource<Student> resource)
        {
            this.resource = resource;
        }

        [HttpGet]
        public IEnumerable<Student> GetAll()
        {
            return resource.GetAll();
        }


        [HttpGet("{id}")]
        public IActionResult GetById(string id)
        {
            var res = resource.Find(id);
            if (res == null)
            {
                return NotFound();
            }
            return new ObjectResult(res);
        }

        [HttpPost]
        public IActionResult Create([FromBody] Student item)
        {
            if (item == null)
            {
                return BadRequest();
            }
            resource.Add(item);
            //return CreatedAtRoute("GetById2", new { Controller = "Students", id = item.Email }, item);
            return CreatedAtRoute(new { id = item.Email }, item);
        }

    }
}
