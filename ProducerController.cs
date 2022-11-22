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
    public class ProducerController : ControllerBase
    {
        private IProducer _producer;
        // GET: api/Actors

        public ProducerController(IProducer producer)
        {
            _producer = producer;
        }


        [HttpGet]
        public IActionResult GetProducers()
        {
            return Ok(_producer.GetProducers());
        }

        [HttpPost]
        public IActionResult GetProducers([FromBody]Producer producer)
        {
            _producer.AddProducer(producer);
            return Created(HttpContext.Request.Scheme + "://"
                + HttpContext.Request.Host + HttpContext.Request.Path
                + "/" + producer.ProducerId, producer);
        }

        //EDIT:api/ApiWithActions/
        [HttpPatch("{id}")]
        public IActionResult Edit(int id, [FromBody]Producer producer)
        {
            var producers = _producer.GetProducer(id);
            if (producers != null)
            {
                producer.ProducerId = producers.ProducerId;
                _producer.EditProducer(producer);
            }
            return Ok(producer);
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var producers = _producer.GetProducer(id);
            if (producers != null)
            {
                _producer.DeleteProducer(producers);
                return Ok();
            }
            return NotFound($"Movie Not Found");
        }
    }
}
