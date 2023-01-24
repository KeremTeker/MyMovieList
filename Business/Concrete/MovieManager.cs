using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.CrossCuttingConcerns.Validation;
using Core.Utilities.Results;
using DataAccess.Abstract;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;
using Entities.DTOs;
using FluentValidation;
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
        [ValidationAspect(typeof(MovieValidator))]
        public IResult Add(Movie movie)
        {

            //bussiness codes
            //validation

            //Cross Cutting Concerns
            //validation
            //Log
            //Cache
            //Transaction
            //Authorization
            //Performance

            //sadece MovieValidator ve Movie değiştiği için


            _movieDal.Add(movie);
            return new SuccessResult(Messages.MovieAdded);
        }

        public IDataResult<List<Movie>> GetAll()
        {
            if (DateTime.Now.Hour==22)
            {
                return new ErrorDataResult<List<Movie>>(Messages.MaintenanceTime);
            }

            //iş kodları
            return new SuccessDataResult<List<Movie>>(_movieDal.GetAll(),Messages.MovieListed);
        }

        public IDataResult<List<Movie>> GetAllByGenreId(int id)
        {
            return new SuccessDataResult<List<Movie>>(_movieDal.GetAll(p => p.GenreId == id));
        }

        public IDataResult<List<Movie>> GetAllByMovieMyPoint(double min, double max)
        {
            return new SuccessDataResult<List<Movie>> (_movieDal.GetAll(p => p.MovieMyPoint >= min && p.MovieMyPoint <= max));
        }

        public IDataResult<Movie> GetById(int movieId)
        {
            return new SuccessDataResult<Movie> (_movieDal.Get(p => p.MovieId == movieId));
        }

        public IDataResult<List<MovieDetailDto>> GetMovieDetails()
        {
            return new SuccessDataResult<List<MovieDetailDto>>(_movieDal.GetMovieDetails());
        }
    }
}
