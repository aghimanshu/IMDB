using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IMDBApplication.Model;
using IMDBApplication.MoviesData;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace IMDBApplication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ActorController : ControllerBase
    {
        private IActor _actors;
        // GET: api/Actors

        public ActorController(IActor actor)
        {
            _actors = actor;
        }


        [HttpGet]
        //[Route("api/[controller]")]
        public IActionResult GetActors()
        {
            return Ok(_actors.GetActors());
        }

        [HttpPost]
        //[Route("api/[controller]")]
        public IActionResult GetActors([FromBody]Actor actor)
        {
            _actors.AddActor(actor);
            return Created(HttpContext.Request.Scheme + "://"
                + HttpContext.Request.Host + HttpContext.Request.Path
                + "/" + actor.ActorId, actor);
        }

        //EDIT:api/ApiWithActions/
        [HttpPatch("{id}")]
        //[Route("api/[controller]/{id}")]
        public IActionResult Edit(int id, [FromBody]Actor actor)
        {
            var actors = _actors.GetActor(id);
            if (actors != null)
            {
                actor.ActorId = actors.ActorId;
                _actors.EditActor(actor);
            }
            return Ok(actor);
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        //[Route("api/[controller]/{id}")]
        public IActionResult Delete(int id)
        {
            var actor = _actors.GetActor(id);
            if (actor != null)
            {
                _actors.DeleteActor(actor);
                return Ok();
            }
            return NotFound($"Movie Not Found");
        }
    }
}

    