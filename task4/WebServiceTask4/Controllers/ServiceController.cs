using Microsoft.AspNetCore.Mvc;
using ServiceReference;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;

namespace WebServiceTask4.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ServiceController : ControllerBase
    {
        private readonly ServiceClient service = new ServiceClient();

        [HttpGet]
        public string Get()
        {
            return JsonSerializer.Deserialize<Dictionary<string, string>>(service.GetDataAsync().Result).First().Value.Replace(' ', '_');
        }
    }
}
