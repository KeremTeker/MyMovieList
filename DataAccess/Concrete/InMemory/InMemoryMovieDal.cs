using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.InMemory
{
    public class InMemoryMovieDal : IMovieDal
    {
        List<Movie> _movies;
        public InMemoryMovieDal()
        {
            //Oracle,Sql Server, Postgres, MongoDb
            _movies = new List<Movie> {
            new Movie{MovieDirector ="Nolan",MovieDuration=157,GenreId=1,MovieImdbPoint=8.5,MovieListedOn=11,MovieId=1,MovieName="Insterstellar",MovieYear=2014,MovieMyMovieListPoint=8.9,MovieMyPoint=9,MovieTopic=""},
            new Movie{MovieDirector ="Nolan",MovieDuration=150,GenreId=1,MovieImdbPoint=8.4,MovieListedOn=12,MovieId=2,MovieName="Inception",MovieYear=2010,MovieMyMovieListPoint=8.1,MovieMyPoint=8,MovieTopic=""},
            new Movie{MovieDirector ="Nolan",MovieDuration=131,GenreId=1,MovieImdbPoint=8.3,MovieListedOn=9,MovieId=3,MovieName="Prestige",MovieYear=2005,MovieMyMovieListPoint=8.4,MovieMyPoint=9,MovieTopic=""},
            new Movie{MovieDirector ="Nolan",MovieDuration=143,GenreId=1,MovieImdbPoint=8.8,MovieListedOn=7,MovieId=4,MovieName="Tenet",MovieYear=2019,MovieMyMovieListPoint=8.7,MovieMyPoint=8,MovieTopic=""},
            };
        }
        public void Add(Movie movie)
        {
            _movies.Add(movie);
        }

        public void Delete(Movie movie)
        {
            //LINQ - Language Integrated Query
            //Lambda =>
            Movie movieToDelete = _movies.SingleOrDefault(m => m.MovieId == movie.MovieId);
            _movies.Remove(movieToDelete);
        }

        public Movie Get(Expression<Func<Movie, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        public List<Movie> GetAll()
        {
            return _movies;
        }

        public List<Movie> GetAll(Expression<Func<Movie, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        public List<Movie> GetAllByGenre(int movieGenreId)
        {
            return _movies.Where(m => m.GenreId == movieGenreId).ToList();
        }

        public List<MovieDetailDto> GetMovieDetails()
        {
            throw new NotImplementedException();
        }

        public void Update(Movie movie)
        {
            Movie movieToUpdate = _movies.SingleOrDefault(m => m.MovieId == movie.MovieId);
            movieToUpdate.MovieId = movie.MovieId;
            movieToUpdate.MovieName = movie.MovieName;
            movieToUpdate.MovieYear = movie.MovieYear;
            movieToUpdate.MovieMyMovieListPoint = movie.MovieMyMovieListPoint;
            movieToUpdate.MovieMyPoint = movie.MovieMyPoint;
            movieToUpdate.MovieTopic = movie.MovieTopic;
            movieToUpdate.MovieDirector = movie.MovieDirector;
            movieToUpdate.GenreId = movie.GenreId;
            movieToUpdate.MovieListedOn = movie.MovieListedOn;
            movieToUpdate.MovieYear = movie.MovieYear;
            movieToUpdate.MovieImdbPoint = movie.MovieImdbPoint;
        }
    }
}

