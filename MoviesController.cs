using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using IMDBApplication.IMoviesData;
using IMDBApplication.Model;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace IMDBApplication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MoviesController : ControllerBase
    {
        private IMovies _movies;
        private readonly IHostingEnvironment _hostingEnvironment;

        // GET: api/Movies

        public MoviesController(IMovies movies,
            IHostingEnvironment hostingEnvironment)
        {
            _movies = movies;
            _hostingEnvironment = hostingEnvironment;
        }


        [HttpGet]
        public IActionResult GetMovies()
        {
            return Ok(_movies.GetMovies());
        }

        [HttpPost]
        public IActionResult GetMovies([FromBody]Movies movies)
        {
            //var path = Path.Combine(_hostingEnvironment.WebRootPath,"images",$"{movies.MovieImage}.jpeg");
            //var imageFileStream = System.IO.File.OpenRead(path);
            //var image = (imageFileStream, "image/jpeg");
            //movies.MovieImage = image.ToString();
            _movies.AddMovies(movies);
            return Created(HttpContext.Request.Scheme + "://"
                + HttpContext.Request.Host + HttpContext.Request.Path
                + "/" + movies.MovieId, movies);
        }

        //EDIT:api/ApiWithActions/
        [HttpPatch("{id}")]
        public IActionResult Edit(int id, [FromBody]Movies movies)
        {
            var movie = _movies.GetMovie(id);
            if (movie != null)
            {
                movies.MovieId = movie.MovieId;
                _movies.EditMovies(movies);
            }
            return Ok(movies);
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var movie = _movies.GetMovie(id);
            if (movie != null)
            {
                _movies.DeleteMovies(movie);
                return Ok();
            }
            return NotFound($"Movie Not Found");
        }
    }
}
