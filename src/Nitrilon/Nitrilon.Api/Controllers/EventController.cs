using Microsoft.AspNetCore.Mvc;
using Nitrilon.Entities;

namespace Nitrilon.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EventController : ControllerBase
    {
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            return Ok();
        }

        [HttpPut]
        public IActionResult Put(Event eventToUpdate)
        {
            return Ok();
        }

        [HttpGet]
        public IEnumerable<Event> GetAll()
        {
            List<Event> events = new()
            {
                new(){Id = 1}, new(){Id = 2}, new(){Id = 3}
            };

            return events;
        }

        [HttpGet("{id}")]
        public ActionResult<Event> Get(int id)
        {
            Event e = null;
            if (id == 3)
            {
                e = new() { Id = 3 };
            }
            else
            {
                return NotFound($"Event with the id of {id} was not found");
            }
            return Ok(e);
        }

        [HttpPost]
        public IActionResult Add(Event newEvent)
        {
            try
            {
                return Ok();
            }
            catch (Exception e)
            {
                return StatusCode(500); // Found with base.
            }
        }
    }
}
