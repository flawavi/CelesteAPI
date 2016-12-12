using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Celeste.Data;
using Celeste.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CelesteAPI.Controllers
{
    [Route("api/[controller]")]
    public class JourniesController : Controller
    {
        private CelesteContext context;
        // GET api/values
        [HttpGet]
        public IActionResult Get()
        {
            //select everything in the explorer table
            IQueryable<object> journies = from journey in context.Journey select journey;

            if (journies == null)
            {
                return NotFound();
            }

            return Ok(journies);
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                Journey journey = context.Journey.Single(j => j.JourneyID == id);

                if (journey == null)
                {
                    return NotFound();
                }
                
                return Ok(journey);
            }
            catch (System.InvalidOperationException ex)
            {
                return NotFound(ex);
            }
        }

        // POST api/values
        [HttpPost]
        public IActionResult Post([FromBody]Journey journey)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            context.Journey.Add(journey);
            try
            {
                context.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (ExplorerExists(journey.JourneyID))
                {
                    return new StatusCodeResult(StatusCodes.Status409Conflict);
                }
                else
                {
                    throw;
                }
            }
            return CreatedAtRoute("GetCustomer", new { id = journey.JourneyID }, journey);
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody]Journey journey)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest();
            }
           if (journey.JourneyID != id)
            {
                return BadRequest();
            }
            context.Journey.Update(journey);
            context.SaveChanges();
            return Ok(journey);
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest();
            }

            Journey journey = context.Journey.Single(j => j.JourneyID == id);
            
            if(journey == null)
            {
                return NotFound();
            }
            try
            {
                context.Journey.Remove(journey);
                context.SaveChanges();
            }
            catch (DbUpdateException)
            {
            if (JourneyExists(journey.JourneyID))
                {
                    return new StatusCodeResult(StatusCodes.Status409Conflict);
                }
                else
                {
                    throw new Exception();
                }
            }
            return Ok(journey);
        }
        //Method: returns true if there is at least a single instance of an Explorer in Celeste.context.
        private bool JourneyExists(int id)
        {
            return context.Journey.Count(j => j.JourneyID == id) > 0;
        }
    }
}
