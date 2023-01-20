using Business.Abstract;
using Business.Constants;
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
                //magic strings
                return new ErrorResult(Messages.MovieNameInvalid);
            }
            //bussiness code
            _movieDal.Add(movie);
            return new SuccessResult(Messages.MovieAdded);
        }

        public IDataResult<List<Movie>> GetAll()
        {
            if (DateTime.Now.Hour==22)
            {
                return new ErrorResult();
            }

            //iş kodları
            return new SuccessDataResult<List<Movie>>(_movieDal.GetAll(),true,"Filmler listelendi");
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
