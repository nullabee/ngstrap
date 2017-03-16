using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using api.Models;
using api.Resources;

namespace api.Controllers
{
    [Route("api/[controller]")]
    public class TaskController : Controller
    {
        private IResource<Task> resource { get; set; }

        public TaskController(IResource<Task> resource)
        {
            this.resource = resource;
        }

        [HttpGet]
        public IEnumerable<Task> GetAll() 
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
        public IActionResult Create([FromBody] Task item)
        {
            if (item == null)
            {
                return BadRequest();
            }
            resource.Add(item);
            return CreatedAtRoute(new { id = item.Id }, item);
        }

        [HttpPut("{id}")]
        public IActionResult Update(string id, [FromBody] Task item)
        {
            if (item == null || item.Id != id)
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
        public IActionResult Update([FromBody] Task item, string id)
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

            item.Id = res.Id;

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