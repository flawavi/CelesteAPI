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
    public class CelesteHostController : Controller
    {
        private CelesteContext context;
        public CelesteHostController(CelesteContext ctx)
        {
            context = ctx;
        }
        // GET api/values
        [HttpGet]
        public IActionResult Get()
        {
            //select everything in the celesteHost table
            IQueryable<object> celesteList = from celeste in context.CelesteHost select celeste;

            if (celesteList == null)
            {
                return NotFound();
            }

            return Ok(celesteList);
        }

        // GET api/values/5
        [HttpGet("{id}", Name="GetCeleste")]
        public IActionResult Get([FromRoute]int id)
        {
            try
            {
                CelesteHost celesteHost = context.CelesteHost.Single(c => c.CelesteHostID == id);

                if (celesteHost == null)
                {
                    return NotFound();
                }
                
                return Ok(celesteHost);
            }
            catch (System.InvalidOperationException ex)
            {
                return NotFound(ex);
            }
        }

        // POST api/values
        [HttpPost]
        public IActionResult Post([FromBody]CelesteHost celesteHost)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            context.CelesteHost.Add(celesteHost);
            try
            {
                context.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (CelesteHostExists(celesteHost.CelesteHostID))
                {
                    return new StatusCodeResult(StatusCodes.Status409Conflict);
                }
                else
                {
                    throw;
                }
            }
            return CreatedAtRoute("GetCelesteHost", new { id = celesteHost.CelesteHostID }, celesteHost);
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody]CelesteHost celesteHost)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest();
            }
           if (celesteHost.CelesteHostID != id)
            {
                return BadRequest();
            }
            context.CelesteHost.Update(celesteHost);
            context.SaveChanges();
            return Ok(celesteHost);
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest();
            }

            CelesteHost celesteHost = context.CelesteHost.Single(c => c.CelesteHostID == id);
            
            if(celesteHost == null)
            {
                return NotFound();
            }
            try
            {
                context.CelesteHost.Remove(celesteHost);
                context.SaveChanges();
            }
            catch (DbUpdateException)
            {
            if (CelesteHostExists(celesteHost.CelesteHostID))
                {
                    return new StatusCodeResult(StatusCodes.Status409Conflict);
                }
                else
                {
                    throw new Exception();
                }
            }
            return Ok(celesteHost);
        }
        //Method: returns true if there is at least a single instance of an CelesteHost in Celeste.context.
        private bool CelesteHostExists(int id)
        {
            return context.CelesteHost.Count(c=> c.CelesteHostID == id) > 0;
        }
    }
}
