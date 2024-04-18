﻿using Microsoft.AspNetCore.Mvc;
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
            // TODO: Write later
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
                Console.WriteLine(e.Message);
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
                Console.WriteLine(e.Message);
                return StatusCode(500);
            }

            return Ok(events);
        }

        [HttpGet]
        [Route("future")]
        public ActionResult<List<Event>> GetFutureEvents()
        {
            Repository repo = new();
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

        [HttpGet("{id}")]
        public ActionResult<Event> Get(int id)
        {
            Repository repo = new();
            Event e = null;
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
                Console.WriteLine(e.Message);
                return StatusCode(500); // Found with base.
            }
        }
    }
}
