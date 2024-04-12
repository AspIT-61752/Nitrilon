using Microsoft.AspNetCore.Mvc;
using Nitrilon.DataAccess;
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
            Repository repo = new();

            try
            {
                repo.EditEvent(eventToUpdate);
            }
            catch (Exception e)
            {
                return StatusCode(500);
            }
            return Ok(200);
        }

        [HttpGet]
        public ActionResult<List<Event>> GetAll()
        {
            Repository repo = new();
            List<Event> events = new();

            try
            {
                events = repo.GetAllEvents();
            }
            catch (Exception e)
            {
                return StatusCode(500);
            }

            return Ok(events);
        }

        [HttpGet("{id}")]
        public ActionResult<Event> Get(int id)
        {
            Repository repo = new();
            Event e = null;
            try
            {
                e = repo.GetEvent(id);
            }
            catch (Exception exception)
            {
                return StatusCode(500);
            }
            return Ok(e);
        }

        [HttpPost]
        public IActionResult Add(Event newEvent)
        {
            try
            {
                Repository repo = new();
                int createdId = repo.Save(newEvent);
                return Ok(createdId);
            }
            catch (Exception e)
            {
                return StatusCode(500); // Found with base.
            }
        }
    }
}
