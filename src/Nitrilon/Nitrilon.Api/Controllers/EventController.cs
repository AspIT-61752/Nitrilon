using Microsoft.AspNetCore.Mvc;
using Nitrilon.DataAccess;
using Nitrilon.Entities;

namespace Nitrilon.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EventController : ControllerBase
    {
        /// <summary>
        /// Deletes an event from the database, based on the ID of the event to delete
        /// </summary>
        /// <param name="id">The ID of the event to delete</param>
        /// <returns>The status code of the operation</returns>
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            // TODO: Write later
            return Ok();
        }

        /// <summary>
        /// Updates an event in the database, based on the ID of the event to update
        /// </summary>
        /// <param name="eventToUpdate">The event to update and its new values</param>
        /// <returns>The status code of the operation</returns>
        [HttpPut]
        public IActionResult Put(Event eventToUpdate)
        {
            EventRepository repo = new();

            try
            {
                repo.EditEvent(eventToUpdate);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return StatusCode(500);
            }

            return Ok(200);
        }

        /// <summary>
        /// Gets EVERY event from the database
        /// </summary>
        /// <returns>The events from the database or a 500 status code if an error occurred</returns>
        [HttpGet]
        public ActionResult<List<Event>> GetAll()
        {
            EventRepository repo = new();
            List<Event> events = new();

            try
            {
                events = repo.GetAllEvents();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return StatusCode(500);
            }

            return Ok(events);
        }

        /// <summary>
        /// Gets every event from 3 days ago and onwards
        /// </summary>
        /// <returns>The events or a 500 status code if an error occurred</returns>
        [HttpGet]
        [Route("future")]
        public ActionResult<List<Event>> GetFutureEvents()
        {
            EventRepository repo = new();
            List<Event> events = new();

            try
            {
                events = repo.GetFutureEvents();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return StatusCode(500);
            }

            return Ok(events);
        }

        /// <summary>
        /// Gets a specific event by its ID
        /// </summary>
        /// <param name="id">The ID of the event to get</param>
        /// <returns>The event with the specified ID or a 500 status code if an error occurred</returns>
        [HttpGet("{id}")]
        public ActionResult<Event> Get(int id)
        {
            EventRepository repo = new();
            Event e = new();

            try
            {
                e = repo.GetEvent(id);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return StatusCode(500);
            }

            return Ok(e);
        }

        /// <summary>
        /// Gets the rating data for a specific event
        /// </summary>
        /// <param name="eventId">The ID of the event to get the rating data for</param>
        /// <returns>The rating data for the event</returns>
        [HttpGet]
        [Route("GetEventRatingDataBy")]
        public ActionResult<EventRatingData> GetRatingData(int eventId)
        {
            EventRepository repo = new();
            EventRatingData ratingData = default;

            try
            {
                ratingData = repo.GetEventRatingDataBy(eventId);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return StatusCode(500);
            }

            return ratingData;
        }

        /// <summary>
        /// Adds a new event to the database
        /// </summary>
        /// <param name="newEvent">The event to add to the database</param>
        /// <returns>Returns the ID of the newly created event or a 500 status code if an error occurred</returns>
        [HttpPost]
        public IActionResult Add(Event newEvent)
        {

            EventRepository repo = new();
            int createdId = default;

            try
            {
                createdId = repo.Save(newEvent);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return StatusCode(500); // Found with base.
            }

            return Ok(createdId);
        }
    }
}
