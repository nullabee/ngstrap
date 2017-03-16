using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Net.Http;

namespace api.Controllers
{
    [Route("api/[controller]")]
    public class Test1Controller : Controller
    {
        [HttpGet]
        public string Get()
        {
            return "GET: Test messssssage";
        }

        [HttpPost]
        public string Post()
        {
            return "POST: Test message";
        }

        [HttpPut]
        public string Put()
        {
            return "PUT: Test message";
        }
    }
}
