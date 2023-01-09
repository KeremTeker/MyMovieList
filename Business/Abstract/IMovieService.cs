using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface IMovieService
    {
        List<Movie> GetAll();
        List<Movie> GetAllByGenreId(int id);
        List<Movie> GetAllByMovieMyPoint(double min, double max);
    }
}
