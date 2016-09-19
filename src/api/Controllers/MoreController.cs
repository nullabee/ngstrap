using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Net.Http;

namespace api.Controllers
{
    [Route("api/[controller]")]
    [Route("More")]
    public class MoreController : Controller
    {
        [HttpGet]
        [Route("Something")]
        public string Get()
        {
            return "GET: This";
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
