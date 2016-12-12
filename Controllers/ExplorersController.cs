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
    public class ExplorersController : Controller
    {
        private CelesteContext context;
        // GET api/values
        [HttpGet]
        public IActionResult Get()
        {
            //select everything in the explorer table
            IQueryable<object> explorers = from explorer in context.Explorer select explorer;

            if (explorers == null)
            {
                return NotFound();
            }

            return Ok(explorers);
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
                Explorer explorer = context.Explorer.Single(e => e.ExplorerID == id);

                if (explorer == null)
                {
                    return NotFound();
                }
                
                return Ok(explorer);
            }
            catch (System.InvalidOperationException ex)
            {
                return NotFound(ex);
            }
        }

        // POST api/values
        [HttpPost]
        public IActionResult Post([FromBody]Explorer explorer)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            context.Explorer.Add(explorer);
            try
            {
                context.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (ExplorerExists(explorer.ExplorerID))
                {
                    return new StatusCodeResult(StatusCodes.Status409Conflict);
                }
                else
                {
                    throw;
                }
            }
            return CreatedAtRoute("GetCustomer", new { id = explorer.ExplorerID }, explorer);
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody]Explorer explorer)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest();
            }
           if (explorer.ExplorerID != id)
            {
                return BadRequest();
            }
            context.Explorer.Update(explorer);
            context.SaveChanges();
            return Ok(explorer);
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest();
            }

            Explorer explorer = context.Explorer.Single(e => e.ExplorerID == id);
            
            if(explorer == null)
            {
                return NotFound();
            }
            try
            {
                context.Explorer.Remove(explorer);
                context.SaveChanges();
            }
            catch (DbUpdateException)
            {
            if (ExplorerExists(explorer.ExplorerID))
                {
                    return new StatusCodeResult(StatusCodes.Status409Conflict);
                }
                else
                {
                    throw new Exception();
                }
            }
            return Ok(explorer);
        }
        //Method: returns true if there is at least a single instance of an Explorer in Celeste.context.
        private bool ExplorerExists(int id)
        {
            return context.Explorer.Count(e => e.ExplorerID == id) > 0;
        }
    }
}
