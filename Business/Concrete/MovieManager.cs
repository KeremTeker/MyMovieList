using Business.Abstract;
using Core.Utilities.Results;
using DataAccess.Abstract;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class MovieManager : IMovieService
    {
        IMovieDal _movieDal;

        public MovieManager(IMovieDal movieDal)
        {
            _movieDal = movieDal;
        }

        public IResult Add(Movie movie)
        {
            if (movie.MovieName.Length<2)
            {
                return new ErrorResult("Film ismi min 2 karatker olmalıdır");
            }
            //bussiness code
            _movieDal.Add(movie);
            return new SuccessResult("Film ekledi");
        }

        public List<Movie> GetAll()
        {

            //iş kodları
            return _movieDal.GetAll();
        }

        public List<Movie> GetAllByGenreId(int id)
        {
            return _movieDal.GetAll(p => p.GenreId == id);
        }

        public List<Movie> GetAllByMovieMyPoint(double min, double max)
        {
            return _movieDal.GetAll(p => p.MovieMyPoint >= min && p.MovieMyPoint <= max);
        }

        public Movie GetById(int movieId)
        {
            return _movieDal.Get(p => p.MovieId == movieId);
        }

        public List<MovieDetailDto> GetMovieDetails()
        {
            return _movieDal.GetMovieDetails();
        }
    }
}
