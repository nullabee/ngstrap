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
        
        [HttpGet("{key}")]
        public IActionResult GetById(string key)
        {
            var res = resource.Find(key);
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
            return CreatedAtRoute(new { id = item.Id }, item);
        }

        [HttpPut("{key}")]
        public IActionResult Update(string key, [FromBody] Student item)
        {
            if (item == null)
            {
                return BadRequest();
            }
            
            if (resource.Update(item))
            {
                return new NoContentResult();
            }

            return NotFound();            
        }

        [HttpDelete("{key}")]
        public IActionResult Delete(string key)
        {
            if (resource.Remove(key))
            {
                return new NoContentResult();
            }
            return NotFound();
        }
    }
}
