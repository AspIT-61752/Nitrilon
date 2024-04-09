using Microsoft.AspNetCore.Mvc;
using Nitrilon.Api.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Nitrilon.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EventRatingsController : ControllerBase
    {
        // GET: api/<EventRatingsController>
        [HttpGet]
        public IEnumerable<EventRatings> Get()
        {
            // Todo: Implement an endpoint to get all event ratings.
            return Enumerable.Range(1, 2).Select(index => new EventRatings()).ToArray();
        }

        // GET api/<EventRatingsController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<EventRatingsController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<EventRatingsController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<EventRatingsController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
