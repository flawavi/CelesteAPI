using System;
using System.Linq;
using Celeste.Data;
using Celeste.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace CelesteAPI.Controllers
{
    [Route("[controller]")]
    public class ExplorerJourneyController : Controller
    {
        private CelesteContext context;
        public ExplorerJourneyController(CelesteContext ctx)
        {
            context = ctx;
        }
        // GET api/values
        [HttpGet]
        public IActionResult Get()
        {
            //select everything in the explorerjourney table
            IQueryable<object> explorerjournies = from explorerjourney in context.ExplorerJourney select explorerjourney;

            if (explorerjournies == null)
            {
                return NotFound();
            }

            return Ok(explorerjournies);
        }

        // GET api/values/5
        [HttpGet("{id}", Name="GetExplorerJourney")]
        public IActionResult Get([FromRoute]string id)
        {
            try
            {
                IQueryable<ExplorerJourney> explorerjourney = context.ExplorerJourney.Where(e => e.ExplorerID == id);

                if (explorerjourney == null)
                {
                    return NotFound();
                }
                
                return Ok(explorerjourney);
            }
            catch (System.InvalidOperationException ex)
            {
                return NotFound(ex);
            }
        }

        // POST api/values
        [HttpPost]
        public IActionResult Post([FromBody]ExplorerJourney explorerjourney)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            context.ExplorerJourney.Add(explorerjourney);
            try
            {
                context.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (ExplorerJourneyExists(explorerjourney.ExplorerJourneyID))
                {
                    return new StatusCodeResult(StatusCodes.Status409Conflict);
                }
                else
                {
                    throw;
                }
            }
            return CreatedAtRoute("GetExplorerJourney", new { id = explorerjourney.ExplorerJourneyID }, explorerjourney);
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody]ExplorerJourney explorerjourney)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest();
            }
           if (explorerjourney.ExplorerJourneyID != id)
            {
                return BadRequest();
            }
            context.ExplorerJourney.Update(explorerjourney);
            context.SaveChanges();
            return Ok(explorerjourney);
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest();
            }

            ExplorerJourney explorerjourney = context.ExplorerJourney.Single(ej => ej.ExplorerJourneyID == id);
            
            if(explorerjourney == null)
            {
                return NotFound();
            }
            try
            {
                context.ExplorerJourney.Remove(explorerjourney);
                context.SaveChanges();
            }
            catch (DbUpdateException)
            {
            if (ExplorerJourneyExists(explorerjourney.ExplorerJourneyID))
                {
                    return new StatusCodeResult(StatusCodes.Status409Conflict);
                }
                else
                {
                    throw new Exception();
                }
            }
            return Ok(explorerjourney);
        }
        //Method: returns true if there is at least a single instance of an Explorer in Celeste.context.
        private bool ExplorerJourneyExists(int id)
        {
            return context.ExplorerJourney.Count(ej => ej.ExplorerJourneyID == id) > 0;
        }
    }
}
