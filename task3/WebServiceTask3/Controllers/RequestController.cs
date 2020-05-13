using Microsoft.AspNetCore.Mvc;
using ServiceReference;

namespace WebServiceTask3.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RequestController : ControllerBase
    {
        private readonly ServiceClient service = new ServiceClient();

        [HttpGet("{id}")]
        public IActionResult Get(int id) => Ok(service.ReqFindAsync(id).Result);

        [HttpPost]
        public IActionResult Post(Request req) => Ok(service.ReqCreateAsync(req));

        [HttpPut]
        public IActionResult Put(Request req) => Ok(service.ReqUpdateAsync(req));

        [HttpDelete("{id}")]
        public IActionResult Delete(int id) => Ok(service.ReqDeleteAsync(id));
    }
}
