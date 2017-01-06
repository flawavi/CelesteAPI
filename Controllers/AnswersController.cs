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
    public class AnswersController : Controller
    {
        private CelesteContext context;
        public AnswersController(CelesteContext ctx)
        {
            context = ctx;
        }
        // GET api/values
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            //select everything in the explorer table
            List<Answers> answers = await context.Answers.ToListAsync();
            List<AnswersViewModel> AVM = new List<AnswersViewModel>();
            foreach(Answers a in answers)
            {
                Questions result = await context.Questions.Where(q => q.QuestionsID == a.QuestionsID).SingleOrDefaultAsync();
                AnswersViewModel model = new AnswersViewModel(a);
                model.Questions = new QuestionsViewModel(result);
                AVM.Add(model);
            }
            if (answers == null)
            {
                return NotFound();
            }

            return Ok(AVM);
        }

        // GET api/values/5
        [HttpGet("{id}", Name="GetAnswers")]
        public IActionResult Get(int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                List<Answers> answers = context.Answers.Where(a => a.JourneyID == id).ToList();

                if (answers == null)
                {
                    return NotFound();
                }
                
                return Ok(answers);
            }
            catch (System.InvalidOperationException ex)
            {
                return NotFound(ex);
            }
        }

        // POST api/values
        [HttpPost]
        public IActionResult Post([FromBody]Answers answers)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            context.Answers.Add(answers);
            try
            {
                context.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (AnswersExists(answers.AnswersID))
                {
                    return new StatusCodeResult(StatusCodes.Status409Conflict);
                }
                else
                {
                    throw;
                }
            }
            return CreatedAtRoute("GetAnswers", new { id = answers.AnswersID }, answers);
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody]Answers answers)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest();
            }
           if (answers.AnswersID != id)
            {
                return BadRequest();
            }
            context.Answers.Update(answers);
            context.SaveChanges();
            return Ok(answers);
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest();
            }

            Answers answers = context.Answers.Single(a => a.AnswersID == id);
            
            if(answers == null)
            {
                return NotFound();
            }
            try
            {
                context.Answers.Remove(answers);
                context.SaveChanges();
            }
            catch (DbUpdateException)
            {
            if (AnswersExists(answers.AnswersID))
                {
                    return new StatusCodeResult(StatusCodes.Status409Conflict);
                }
                else
                {
                    throw new Exception();
                }
            }
            return Ok(answers);
        }
        //Method: returns true if there is at least a single instance of an Explorer in Celeste.context.
        private bool AnswersExists(int id)
        {
            return context.Answers.Count(a => a.AnswersID == id) > 0;
        }
    }
}
