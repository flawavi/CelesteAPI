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
    public class QuestionsController : Controller
    {
        private CelesteContext context;
        public QuestionsController(CelesteContext ctx)
        {
            context = ctx;
        }
        // GET api/values
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            //select everything in the explorer table
            List<Questions> questions = await context.Questions.ToListAsync();
            List<QuestionsViewModel> TVM = new List<QuestionsViewModel>();
            foreach(Questions q in questions)
            {
                Journey result = await context.Journey.Where(j => j.JourneyID == q.JourneyID).SingleOrDefaultAsync();
                QuestionsViewModel model = new QuestionsViewModel(q);
                model.Journey = new JourneyViewModel(result);
                TVM.Add(model);
            }
            if (questions == null)
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
                List<Questions> trivia = context.Questions.Where(t => t.JourneyID == id).ToList();

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
        public IActionResult Post([FromBody]Questions question)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            context.Questions.Add(question);
            try
            {
                context.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (QuestionsExists(question.QuestionsID))
                {
                    return new StatusCodeResult(StatusCodes.Status409Conflict);
                }
                else
                {
                    throw;
                }
            }
            return CreatedAtRoute("GetTrivia", new { id = question.QuestionsID }, question);
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody]Questions question)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest();
            }
           if (question.QuestionsID != id)
            {
                return BadRequest();
            }
            context.Questions.Update(question);
            context.SaveChanges();
            return Ok(question);
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest();
            }

            Questions question = context.Questions.Single(q => q.QuestionsID == id);
            
            if(question == null)
            {
                return NotFound();
            }
            try
            {
                context.Questions.Remove(question);
                context.SaveChanges();
            }
            catch (DbUpdateException)
            {
            if (QuestionsExists(question.QuestionsID))
                {
                    return new StatusCodeResult(StatusCodes.Status409Conflict);
                }
                else
                {
                    throw new Exception();
                }
            }
            return Ok(question);
        }
        //Method: returns true if there is at least a single instance of an Explorer in Celeste.context.
        private bool QuestionsExists(int id)
        {
            return context.Questions.Count(q => q.QuestionsID == id) > 0;
        }
    }
}
