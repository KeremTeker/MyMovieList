using Business.Abstract;
using Business.Constants;
using Business.CSS;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.CrossCuttingConcerns.Validation;
using Core.Utilities.Business;
using Core.Utilities.Results;
using DataAccess.Abstract;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;
using Entities.DTOs;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Business.Concrete
{
    public class MovieManager : IMovieService
    {
        IMovieDal _movieDal;
        IGenreService _genreService;

        public MovieManager(IMovieDal movieDal, IGenreService genreService)
        {
            _movieDal = movieDal;
            _genreService = genreService;
        }
        [ValidationAspect(typeof(MovieValidator))]
        public IResult Add(Movie movie)
        {

            IResult result = BusinessRules.Run(
                CheckIfMovieNameExixst(movie.MovieName),
                CheckIfMovieCountOfGenreCorrect(movie.GenreId),
                CheckIfGenreLimitExceded());


            if (result != null)
            {
                return result;
            }

            _movieDal.Add(movie);
            return new SuccessResult(Messages.MovieAdded);

        }

        public IDataResult<List<Movie>> GetAll()
        {
            if (DateTime.Now.Hour == 22)
            {
                return new ErrorDataResult<List<Movie>>(Messages.MaintenanceTime);
            }


            return new SuccessDataResult<List<Movie>>(_movieDal.GetAll(), Messages.MovieListed);
        }

        public IDataResult<List<Movie>> GetAllByGenreId(int id)
        {
            return new SuccessDataResult<List<Movie>>(_movieDal.GetAll(p => p.GenreId == id));
        }

        public IDataResult<List<Movie>> GetAllByMovieMyPoint(double min, double max)
        {
            return new SuccessDataResult<List<Movie>>(_movieDal.GetAll(p => p.MovieMyPoint >= min && p.MovieMyPoint <= max));
        }

        public IDataResult<Movie> GetById(int movieId)
        {
            return new SuccessDataResult<Movie>(_movieDal.Get(p => p.MovieId == movieId));
        }

        public IDataResult<List<MovieDetailDto>> GetMovieDetails()
        {
            return new SuccessDataResult<List<MovieDetailDto>>(_movieDal.GetMovieDetails());
        }
        [ValidationAspect(typeof(MovieValidator))]
        public IResult Update(Movie movie)
        {
            if (CheckIfMovieCountOfGenreCorrect(movie.GenreId).Success)
            {
                _movieDal.Update(movie);
                return new SuccessResult(Messages.MovieAdded);
            }
            return new ErrorResult();

        }

        private IResult CheckIfMovieCountOfGenreCorrect(int genreId)
        {

            var result = _movieDal.GetAll(m => m.GenreId == genreId).Count;
            if (result >= 10)
            {
                return new ErrorResult(Messages.MovieCountofGenreError);
            }
            return new SuccessResult();
        }
        private IResult CheckIfMovieNameExixst(string movieName)
        {
            var result = _movieDal.GetAll(m => m.MovieName == movieName).Any();
            if (result == true)
            {
                return new ErrorResult(Messages.MovieExistError);
            }
            return new SuccessResult();
        }
        private IResult CheckIfGenreLimitExceded()
        {
            var result = _genreService.GetAll();
            if (result.Data.Count>=15)
            {
                return new ErrorResult(Messages.GenreLimitExceded);
            }
            return new SuccessResult();
        }
    }
}
