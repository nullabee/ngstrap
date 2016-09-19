using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using api.Models;
using api.Resources;

namespace api.Controllers
{
    [Route("api/[controller]")]
    public class ContactsController : Controller
    {
        private IResource<Contact> resource { get; set; }

        public ContactsController(IResource<Contact> resource)
        {
            this.resource = resource;
        }

        [HttpGet]
        public IEnumerable<Contact> GetAll()
        {
            return resource.GetAll();
        }

        //[HttpGet("{id}", Name = "GetContacts")]
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
        public IActionResult Create([FromBody] Contact item)
        {
            if (item == null)
            {
                return BadRequest();
            }
            resource.Add(item);
            //return CreatedAtRoute("GetContacts", new { Controller = "Contacts", id = item.MobilePhone }, item);
            return CreatedAtRoute(new { id = item.MobilePhone }, item);
        }

        [HttpPut("{id}")]
        public IActionResult Update(string id, [FromBody] Contact item)
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
            resource.Update(item);
            return new NoContentResult();
        }

        [HttpDelete("{id}")]
        public void Delete(string id)
        {
            resource.Remove(id);
        }
    }
}
