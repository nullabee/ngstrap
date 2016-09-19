using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using api.Models;
using api.Resources;

namespace api.Controllers
{
    [Route("api/[controller]")]
    public class WorkersController : Controller
    {
        private IResource<Worker> resource { get; set; }

        public WorkersController(IResource<Worker> resource)
        {
            this.resource = resource;
        }

        [HttpGet]
        public IEnumerable<Worker> GetAll()
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
        public IActionResult Create([FromBody] Worker item)
        {
            if (item == null)
            {
                return BadRequest();
            }
            resource.Add(item);
            return CreatedAtRoute(new { id = item.Email }, item);
        }

    }
}
