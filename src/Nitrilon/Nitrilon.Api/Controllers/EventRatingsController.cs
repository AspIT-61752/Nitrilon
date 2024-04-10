using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Nitrilon.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EventRatingsController : ControllerBase
    {
        //// GET: api/<EventRatingsController>
        //[HttpGet]
        //public IEnumerable<EventRatings> Get()
        //{
        //    // Todo: Implement an endpoint to get all event ratings.
        //    return Enumerable.Range(1, 2).Select(index => new EventRatings()).ToArray();
        //}

        /*
        [HttpGet]
        public IActionResult GetEventRatings()
        {
            //return Enumerable.Range(1, 2).Select(index => new EventRatings()).ToArray();
            List<EventRatings> Ratings = EventRatings.GetDummyDB();
            if (Ratings == null)
            {
                return NotFound();
            }
            return Ok(Ratings);
        }

        // GET api/<EventRatingsController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            List<EventRatings> dummyDB = EventRatings.GetDummyDB();
            if (dummyDB == null)
            {
                NotFound(dummyDB);
            }

            // Temp, remove later
            foreach (EventRatings ratings in dummyDB)
            {
                if (ratings.EventRatingId == id)
                {
                    return Ok(ratings);
                }
            }

            return NotFound();
        }

        // POST api/<EventRatingsController>
        [HttpPost]
        public IActionResult Post([FromBody] EventRatings rating)
        {
            List<EventRatings> dummyDB = EventRatings.GetDummyDB();
            if (dummyDB == null)
            {
                return NotFound(dummyDB);
            }

            return Ok();

            // Temp, remove later
            //dummyDB.add(rating.RatingId);
        }
        //{
        //    List<EventRatings> dummyDB = EventRatings.GetDummyDB();
        //    if (dummyDB == null)
        //    {
        //        NotFound(dummyDB);
        //    }

        //    // Temp, remove later
        //    dummyDB.Add(new EventRatings { EventId = (dummyDB.Count() + 1), EventRatingId = dummyDB.Count(), RatingId = id });
        //}

        // PUT api/<EventRatingsController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<EventRatingsController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }*/
    }
}
