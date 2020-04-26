using Laba2;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Labа2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ServiceController : ControllerBase
    {
        private readonly AppDatabaseContext q;

        public ServiceController(AppDatabaseContext q) => this.q = q;

        // GET: api/service/1
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            if (id <= 0)
            {
                return BadRequest("Not a valid id");
            }

            return Ok(q.Services.Include(s => s.ServiceRequest).FirstOrDefault(x => x.Id == id));
        }

        //POST: api/service
        [HttpPost]
        public IActionResult Post(Service service)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Invalid data");
            }

            q.Services.Add(new Service()
            {
                Name = service.Name,
                ServiceRequest = service.ServiceRequest
            });
            q.SaveChanges();

            return Ok();
        }

        // PUT: api/service/1
        [HttpPut]
        public IActionResult Put(Service service)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Not a valid model");
            }

            Service exServ = q.Services.Find(service.Id);
            if (exServ != null)
            {
                exServ.Name = service.Name;
                q.SaveChanges();
            }
            else
            {
                return NotFound();
            }

            return Ok();
        }

        // DELETE: api/service/1
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            if (id <= 0)
            {
                return BadRequest("Not a valid id");
            }

            Service exServ = q.Services.Find(id);
            if (exServ != null)
            {
                q.Remove(exServ);
                q.SaveChanges();
            }

            return Ok();
        }
    }
}