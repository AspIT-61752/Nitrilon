using Microsoft.AspNetCore.Mvc;
using Nitrilon.DataAccess;

namespace Nitrilon.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EventRatingsController : Controller
    {

        /// <summary>
        /// Adds a rating to an event
        /// </summary>
        /// <param name="eventId">The ID of the event the rating is for</param>
        /// <param name="ratingId">The ID of the rating to add (1 = bad, 2 = neutral, 3 = good)</param>
        /// <returns>The ID of the created event rating or a 500 status code if an error occurred</returns>
        [HttpPost]
        public IActionResult AddEventRating(int eventId, int ratingId)
        {
            EventRepository r = new();
            int createdId = default;

            try
            {
                createdId = r.SaveEventRating(eventId, ratingId);
            }
            catch (Exception e)
            {
                return StatusCode(500);
            }

            return Ok(createdId);
        }
    }
}
