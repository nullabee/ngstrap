using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using api.Models;
using api.Resources;
using api.Controllers.Common;
using Newtonsoft.Json;

namespace api.Controllers
{
    public class NuancesController : BaseApiController
    {
        readonly JsonSerializerSettings jsonSS = new JsonSerializerSettings
        {
            ReferenceLoopHandling = ReferenceLoopHandling.Ignore,
            ContractResolver = new JsonContractResolver()
        };

        // TODO: resources can be instantiated per request to 
        // avoid persistent connections with DB (depends on setup)
        private IResource<Nuance> resource { get; set; }

        public NuancesController(IResource<Nuance> resource)
        {
            this.resource = resource;
        }

        [HttpGet]
        public async Task<JsonResult> List()
        {
            var results = await resource.GetAll();
            return new JsonResult(results, jsonSS);
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

            item.TaskID = res.NuanceID;

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