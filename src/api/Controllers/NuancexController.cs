using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using api.Models;
using api.Resources;

namespace api.Controllers
{
    public class TaskxController : BaseApiController
    {
        private IResource<Nuance> resource { get; set; }

        public TaskxController(IResource<Nuance> resource)
        {
            this.resource = resource;
        }

        [HttpGet]
        public IEnumerable<Nuance> List() 
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
        public IActionResult Create([FromBody] Nuance item)
        {
            if (item == null)
            {
                return BadRequest();
            }
            resource.Add(item);
            return CreatedAtRoute(new { id = item.NuanceID }, item);
        }

        [HttpPut("{id}")]
        public IActionResult Replace(int id, [FromBody] Nuance item)
        {
            if (item == null || item.NuanceID != id)
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
        public IActionResult Update(int id, [FromBody] Nuance item)
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

            item.NuanceID = res.NuanceID;

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