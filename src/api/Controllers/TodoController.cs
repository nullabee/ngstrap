using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using api.Models;
using api.Repositories;

namespace api.Controllers
{
    [Route("api/[controller]")]
    public class TodoController : Controller
    {
        private ITodoRepository todoRepo { get; set; }

        public TodoController(ITodoRepository repo)
        {
            todoRepo = repo;
        }

        [HttpGet]
        public IEnumerable<TodoItem> GetAll() 
        {
            return todoRepo.GetAll();
        }

        [HttpGet("{id}", Name = "GetById")]
        public IActionResult GetById(string id)
        {
            var item = todoRepo.Find(id);
            if (item == null)
            {
                return NotFound();
            }
            return new ObjectResult(item);
        }

        [HttpPost]
        public IActionResult Create([FromBody] TodoItem item)
        {
            if (item == null)
            {
                return BadRequest();
            }
            todoRepo.Add(item);
            return CreatedAtRoute("GetById", new { id = item.Id }, item);
        }

        [HttpPut("{id}")]
        public IActionResult Update(string id, [FromBody] TodoItem item)
        {
            if (item == null || item.Id != id)
            {
                return BadRequest();
            }

            var todo = todoRepo.Find(id);
            if (todo == null)
            {
                return NotFound();
            }

            todoRepo.Update(item);
            return new NoContentResult();
        }

        [HttpPatch("{id}")]
        public IActionResult Update([FromBody] TodoItem item, string id)
        {
            if (item == null)
            {
                return BadRequest();
            }

            var todo = todoRepo.Find(id);
            if (todo == null)
            {
                return NotFound();
            }

            item.Id = todo.Id;

            todoRepo.Update(item);
            return new NoContentResult();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(string id)
        {
            var todo = todoRepo.Find(id);
            if (todo == null)
            {
                return NotFound();
            }

            todoRepo.Remove(id);
            return new NoContentResult();
        }
    }
}