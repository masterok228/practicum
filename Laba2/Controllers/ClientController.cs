using System.Linq;
using Microsoft.AspNetCore.Mvc;

namespace Laba2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientController : ControllerBase
    {
        private readonly AppDatabaseContext q;

        public ClientController(AppDatabaseContext q) => this.q = q;

        //request.AutomaticDecompression = DecompressionMethods.GZip;

        // GET: api/client/1
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            if (id <= 0)
            {
                return BadRequest("Not a valid id");
            }

            return Ok(q.Clients.FirstOrDefault(u => (bool)(u.Id == id)));
        }

        //POST: api/client
        [HttpPost]
        public IActionResult Post(Сlient client)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Invalid data");
            }

            q.Clients.Add(new Сlient()
            {
                Name = client.Name,
                Requests = client.Requests
            });

            //Сlient client1 = new Сlient();
            //client1.Name = "Ваня";
            //q.Clients.Add(client1);
            q.SaveChanges();

            return Ok();
        }

        // PUT: api/client/1
        [HttpPut]
        public IActionResult Put(Сlient client)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Not a valid model");
            }

            Сlient exClient = q.Clients.Find(client.Id);
            if (exClient != null)
            {
                exClient.Name = client.Name;
                q.SaveChanges();
            }
            else
            {
                return NotFound();
            }

            return Ok();
        }

        // DELETE: api/client/1
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            if (id <= 0)
            {
                return BadRequest("Not a valid id");
            }

            Сlient exClient = q.Clients.Find(id);
            if (exClient != null)
            {
                q.Remove(exClient);
                q.SaveChanges();
            }

            return Ok();
        }
    }
}