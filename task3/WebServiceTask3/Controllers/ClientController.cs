using Microsoft.AspNetCore.Mvc;
using ServiceReference;

namespace WebServiceTask3.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientController : ControllerBase
    {
        private readonly ServiceClient service = new ServiceClient();

        [HttpGet("{id}")]
        public IActionResult Get(int id) => Ok(service.ClFindAsync(id).Result);

        [HttpPost]
        public IActionResult Post(Client cl) => Ok(service.ClCreateAsync(cl));

        [HttpPut]
        public IActionResult Put(Client cl) => Ok(service.ClUpdateAsync(cl));

        [HttpDelete("{id}")]
        public IActionResult Delete(int id) => Ok(service.ClDeleteAsync(id));
    }
}
