using System;
using System.Linq;
using Celeste.Data;
using Celeste.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

namespace CelesteAPI.Controllers
{
    [Route("[controller]")]
    public class TriviaController : Controller
    {
        private CelesteContext context;
        public TriviaController(CelesteContext ctx)
        {
            context = ctx;
        }
        // GET api/values
        [HttpGet]
        public IActionResult Get()
        {
            //select everything in the explorer table
            IQueryable<object> trivias = from trivia in context.Trivia select trivia;

            if (trivias == null)
            {
                return NotFound();
            }

            return Ok(trivias);
        }

        // GET api/values/5
        [HttpGet("{id}", Name="GetTrivia")]
        public IActionResult Get(int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                Trivia trivia = context.Trivia.Single(t => t.TriviaID == id);

                if (trivia == null)
                {
                    return NotFound();
                }
                
                return Ok(trivia);
            }
            catch (System.InvalidOperationException ex)
            {
                return NotFound(ex);
            }
        }

        // POST api/values
        [HttpPost]
        public IActionResult Post([FromBody]Trivia trivia)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            context.Trivia.Add(trivia);
            try
            {
                context.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (TriviaExists(trivia.TriviaID))
                {
                    return new StatusCodeResult(StatusCodes.Status409Conflict);
                }
                else
                {
                    throw;
                }
            }
            return CreatedAtRoute("GetTrivia", new { id = trivia.TriviaID }, trivia);
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody]Trivia trivia)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest();
            }
           if (trivia.TriviaID != id)
            {
                return BadRequest();
            }
            context.Trivia.Update(trivia);
            context.SaveChanges();
            return Ok(trivia);
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest();
            }

            Trivia trivia = context.Trivia.Single(t => t.TriviaID == id);
            
            if(trivia == null)
            {
                return NotFound();
            }
            try
            {
                context.Trivia.Remove(trivia);
                context.SaveChanges();
            }
            catch (DbUpdateException)
            {
            if (TriviaExists(trivia.TriviaID))
                {
                    return new StatusCodeResult(StatusCodes.Status409Conflict);
                }
                else
                {
                    throw new Exception();
                }
            }
            return Ok(trivia);
        }
        //Method: returns true if there is at least a single instance of an Explorer in Celeste.context.
        private bool TriviaExists(int id)
        {
            return context.Trivia.Count(t => t.TriviaID == id) > 0;
        }
    }
}
