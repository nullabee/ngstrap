using api.Models;
using api.Resources;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using api.Controllers.Common;
using Newtonsoft.Json;
using api.Data;
using System;

namespace api.Controllers
{
    public class DemoController : BaseApiController
    {
        private IResource<Nuance> resource { get; set; }

        private DataContext context { get; set; }

        public DemoController(DataContext context, IResource<Nuance> resource)
        {
            this.resource = resource;
            this.context = context;
        }

        [HttpGet]
        [Route("reset")]
        public async Task<ActionResult> Reset()
        {
            await context.WipeDatabase();
            var results = await resource.AddRangeAsync(MockData.GenerateDefaults());
            return new OkResult();
        }

    }
}
