using Business.Abstract;
using DataAccess.Abstract;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;
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
    }
}
