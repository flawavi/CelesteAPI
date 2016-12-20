using System;
using System.Linq;
using Celeste.Data;
using Celeste.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Celeste.Models.ViewModels;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

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
        public async Task<IActionResult> Get()
        {
            //select everything in the explorer table
            List<Trivia> trivias = await context.Trivia.ToListAsync();
            List<TriviaViewModel> TVM = new List<TriviaViewModel>();
            foreach(Trivia t in trivias)
            {
                Journey result = await context.Journey.Where(j => j.JourneyID == t.JourneyID).SingleOrDefaultAsync();
                TriviaViewModel model = new TriviaViewModel(t);
                model.Journey = new JourneyViewModel(result);
                TVM.Add(model);
            }
            if (trivias == null)
            {
                return NotFound();
            }

            return Ok(TVM);
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
                List<Trivia> trivia = context.Trivia.Where(t => t.JourneyID == id).ToList();

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
