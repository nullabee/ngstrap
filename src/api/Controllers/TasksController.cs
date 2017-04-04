using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using api.Models;
using api.Resources;

namespace api.Controllers
{
    [Route("api/v1/[controller]")]
    public class TasksController : Controller
    {
        private IResource<Task> resource { get; set; }

        public TasksController(IResource<Task> resource)
        {
            this.resource = resource;
        }

        [HttpGet]
        public IEnumerable<Task> List() 
        {
            return resource.GetAll();
        }

        [HttpGet("{id}")]
        public IActionResult Read(int id)
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
            return CreatedAtRoute(new { id = item.TaskID }, item);
        }

        [HttpPut("{id}")]
        public IActionResult Replace(int id, [FromBody] Task item)
        {
            if (item == null || item.TaskID != id)
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
        public IActionResult Update(int id, [FromBody] Task item)
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

            item.TaskID = res.TaskID;

            resource.Update(item);
            return new NoContentResult();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
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