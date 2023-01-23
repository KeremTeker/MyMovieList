using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.EntityFramework
{
    //NuGet
    public class EfMovieDal : EfEntityRepositoryBase<Movie, SqlContext>, IMovieDal
    {
        public List<MovieDetailDto> GetMovieDetails()
        {
            using (SqlContext context = new SqlContext())
            {
                var result = from p in context.Movies
                             join g in context.Genres on p.GenreId equals g.GenreId
                             select new MovieDetailDto
                             {
                                 MovieId = p.MovieId,
                                 MovieName = p.MovieName,
                                 GenreName = g.GenreName,
                                 MovieYear = p.MovieYear
                             };
                return result.ToList();
            }
        }
    }
}
