using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using api.Models;
using api.Resources;

namespace api.Controllers
{
    [Route("api/[controller]")]
    public class TodoController : Controller
    {
        private IResource<Todo> resource { get; set; }

        public TodoController(IResource<Todo> resource)
        {
            this.resource = resource;
        }

        [HttpGet]
        public IEnumerable<Todo> GetAll() 
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
        public IActionResult Create([FromBody] Todo item)
        {
            if (item == null)
            {
                return BadRequest();
            }
            resource.Add(item);
            return CreatedAtRoute(new { id = item.Key }, item);
        }

        [HttpPut("{id}")]
        public IActionResult Update(string id, [FromBody] Todo item)
        {
            if (item == null || item.Key != id)
            {
                return BadRequest();
            }

            var res = resource.Find(id);
            if (res == null)
            {
                return NotFound();
            }

            resource.Update(item);
            return new NoContentResult();
        }

        [HttpPatch("{id}")]
        public IActionResult Update([FromBody] Todo item, string id)
        {
            if (item == null)
            {
                return BadRequest();
            }

            var res = resource.Find(id);
            if (res == null)
            {
                return NotFound();
            }

            item.Key = res.Key;

            resource.Update(item);
            return new NoContentResult();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(string id)
        {
            var res = resource.Find(id);
            if (res == null)
            {
                return NotFound();
            }

            resource.Remove(id);
            return new NoContentResult();
        }
    }
}