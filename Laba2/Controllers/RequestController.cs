using Laba2;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Labа2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RequestController : ControllerBase
    {
        private readonly AppDatabaseContext q;

        public RequestController(AppDatabaseContext q) => this.q = q;

        // GET: api/request/1
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            if (id <= 0)
            {
                return BadRequest("Not a valid id");
            }

            return Ok(q.Requests.Include(s => s.ServiceRequest).FirstOrDefault(x => (bool)(x.Id == id)));
        }

        //POST: api/request
        [HttpPost]
        public IActionResult Post(Request request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Invalid data");
            }

            q.Requests.Add(new Request()
            {
                ClientId = request.ClientId,
                ServiceRequest = request.ServiceRequest
            });
            q.SaveChanges();

            return Ok();
        }

        // PUT: api/request1
        [HttpPut]
        public IActionResult Put(Request request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Not a valid model");
            }

            Request exReq = q.Requests.Find(request.Id);
            if (exReq != null)
            {
                exReq.ClientId = request.ClientId;
                exReq.ServiceRequest = request.ServiceRequest;
                q.SaveChanges();
            }
            else
            {
                return NotFound();
            }

            return Ok();
        }

        // DELETE: api/request/1
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            if (id <= 0)
            {
                return BadRequest("Not a valid id");
            }

            Request exReq = q.Requests.Find(id);
            if (exReq != null)
            {
                q.Remove(exReq);
                q.SaveChanges();
            }

            return Ok();
        }
    }
}