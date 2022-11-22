using IMDBApplication.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IMDBApplication.IMoviesData
{
    public interface IMovies
    {
        List<Movies> GetMovies();
        Movies GetMovie(int id);
        Movies AddMovies(Movies movies);
        Movies EditMovies(Movies movies);
        void DeleteMovies(Movies movies);
    }
}
