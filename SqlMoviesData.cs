using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IMDBApplication.Model;
using IMDBApplication.Models;
using IMDBApplication.MoviesData;

namespace IMDBApplication.IMoviesData
{
    public class SqlMoviesData : IMovies, IActor, IProducer
    {
        private MoviesDBContext _moviesDBContext;
        public SqlMoviesData(MoviesDBContext moviesDBContext)
        {
            _moviesDBContext = moviesDBContext;
        }
        public Movies AddMovies(Movies movies)
        {
            _moviesDBContext.movies.Add(movies);
            _moviesDBContext.SaveChanges();
            return movies;
        }

        public void DeleteMovies(Movies movies)
        {
            _moviesDBContext.movies.Remove(movies);
            _moviesDBContext.SaveChanges();

        }

        public Movies EditMovies(Movies movies)
        {
            var movie = _moviesDBContext.movies.Find(movies.MovieId);
            if (movie != null)
            {
                movie.MovieName = movies.MovieName;
                movie.Actor = movies.Actor;
                movie.Producer = movies.Producer;
                movie.DateOfRelease = movies.DateOfRelease;
                movie.MovieImage = movies.MovieImage;
                _moviesDBContext.movies.Update(movie);
                _moviesDBContext.SaveChanges();
            }
            return movies;
        }

        public List<Movies> GetMovies()
        {

            return _moviesDBContext.movies.ToList();
        }

        public Movies GetMovie(int id)
        {
            var movie = _moviesDBContext.movies.Find(id);
            return movie;
        }

        public Producer GetProducer(int id)
        {
            return _moviesDBContext.producer.SingleOrDefault(x => x.ProducerId == id);
        }

        public Producer AddProducer(Producer producer)
        {
            _moviesDBContext.producer.Add(producer);
            _moviesDBContext.SaveChanges();
            return producer;
        }

        public Producer EditProducer(Producer producer)
        {
            var producers = _moviesDBContext.producer.Find(producer.ProducerId);
            if (producers != null)
            {
                producers.ProducerName = producer.ProducerName;
                producers.CompanyName = producer.CompanyName;
                producers.Bio = producer.Bio;
                producers.DOB = producer.DOB;
                producers.Gender = producer.Gender;
                _moviesDBContext.producer.Update(producer);
                _moviesDBContext.SaveChanges();
            }
            return producer;
        }

        public Producer DeleteProducer(Producer producer)
        {
            _moviesDBContext.producer.Remove(producer);
            return producer;
        }

        public Actor GetActor(int id)
        {
            return _moviesDBContext.actors.SingleOrDefault(x => x.ActorId == id);
        }

        public Actor AddActor(Actor actor)
        {
            _moviesDBContext.actors.Add(actor);
            _moviesDBContext.SaveChanges();
            return actor;
        }

        public Actor EditActor(Actor actor)
        {
            var actors = _moviesDBContext.actors.Find(actor.ActorId);
            if (actors != null)
            {
                actors.ActorName = actor.ActorName;
                actors.DOB = actor.DOB;
                actors.Gender = actor.Gender;
                _moviesDBContext.actors.Update(actor);
                _moviesDBContext.SaveChanges();
            }
            return actor;
        }

        public Actor DeleteActor(Actor actor)
        {
            _moviesDBContext.actors.Remove(actor);
            return actor;
        }

        public List<Actor> GetActors()
        {
            return _moviesDBContext.actors.ToList();
        }

        public List<Producer> GetProducers()
        {
            return _moviesDBContext.producer.ToList();
        }
    }
}
