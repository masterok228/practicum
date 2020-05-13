using Microsoft.AspNetCore.Mvc;
using ServiceReference;

namespace WebServiceTask3.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ServiceController : ControllerBase
    {
        private readonly ServiceClient service = new ServiceClient();

        [HttpGet("{id}")]
        public IActionResult Get(int id) => Ok(service.SerFindAsync(id).Result);

        [HttpPost]
        public IActionResult Post(Service ser) => Ok(service.SerCreateAsync(ser));

        [HttpPut]
        public IActionResult Put(Service ser) => Ok(service.SerUpdateAsync(ser));

        [HttpDelete("{id}")]
        public IActionResult Delete(int id) => Ok(service.SerDeleteAsync(id));
    }
}
