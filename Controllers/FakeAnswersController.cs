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
    public class FakeAnswersController : Controller
    {
        private CelesteContext context;
        public FakeAnswersController(CelesteContext ctx)
        {
            context = ctx;
        }
        // GET api/values
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            //select everything in the explorer table
            List<FakeAnswers> fakeanswers = await context.FakeAnswers.ToListAsync();
            List<FakeAnswersViewModel> FAVM = new List<FakeAnswersViewModel>();
            foreach(FakeAnswers fa in fakeanswers)
            {
                Questions result = await context.Questions.Where(q => q.QuestionsID == fa.QuestionsID).SingleOrDefaultAsync();
                FakeAnswersViewModel model = new FakeAnswersViewModel(fa);
                model.Questions = new QuestionsViewModel(result);
                FAVM.Add(model);
            }
            if (fakeanswers == null)
            {
                return NotFound();
            }

            return Ok(FAVM);
        }

        // GET api/values/5
        [HttpGet("{id}", Name="GetFakeAnswers")]
        public IActionResult Get(int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                List<FakeAnswers> fakeanswers = context.FakeAnswers.Where(fa => fa.FakeAnswersID == id).ToList();

                if (fakeanswers == null)
                {
                    return NotFound();
                }
                
                return Ok(fakeanswers);
            }
            catch (System.InvalidOperationException ex)
            {
                return NotFound(ex);
            }
        }

        // POST api/values
        [HttpPost]
        public IActionResult Post([FromBody]FakeAnswers fakeanswers)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            context.FakeAnswers.Add(fakeanswers);
            try
            {
                context.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (FakeAnswersExists(fakeanswers.FakeAnswersID))
                {
                    return new StatusCodeResult(StatusCodes.Status409Conflict);
                }
                else
                {
                    throw;
                }
            }
            return CreatedAtRoute("GetFakeAnswers", new { id = fakeanswers.FakeAnswersID }, fakeanswers);
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody]FakeAnswers fakeanswers)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest();
            }
           if (fakeanswers.FakeAnswersID != id)
            {
                return BadRequest();
            }
            context.FakeAnswers.Update(fakeanswers);
            context.SaveChanges();
            return Ok(fakeanswers);
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest();
            }

            FakeAnswers fakeanswers = context.FakeAnswers.Single(fa => fa.FakeAnswersID == id);
            
            if(fakeanswers == null)
            {
                return NotFound();
            }
            try
            {
                context.FakeAnswers.Remove(fakeanswers);
                context.SaveChanges();
            }
            catch (DbUpdateException)
            {
            if (FakeAnswersExists(fakeanswers.FakeAnswersID))
                {
                    return new StatusCodeResult(StatusCodes.Status409Conflict);
                }
                else
                {
                    throw new Exception();
                }
            }
            return Ok(fakeanswers);
        }
        //Method: returns true if there is at least a single instance of an Explorer in Celeste.context.
        private bool FakeAnswersExists(int id)
        {
            return context.FakeAnswers.Count(fa => fa.FakeAnswersID == id) > 0;
        }
    }
}
