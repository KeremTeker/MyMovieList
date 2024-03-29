﻿using Core.Utilities.Results;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface IMovieService
    {
        IDataResult<List<Movie>> GetAll();
        IDataResult<List<Movie>> GetAllByGenreId(int id);
        IDataResult<List<Movie>> GetAllByMovieMyPoint(double min, double max);
        IDataResult<List<MovieDetailDto>> GetMovieDetails();

        IResult Add(Movie movie);
        IDataResult<Movie> GetById(int movieId);
        IResult Update(Movie movie);
        IResult AddTransactionalTest(Movie movie);


        //RESTFUL --> HTTP --> 
    }
}
