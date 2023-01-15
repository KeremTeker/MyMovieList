using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class GenreManager : IGenreService
    {
        IGenreDal _genreDal;

        public GenreManager(IGenreDal genreDal)
        {
            _genreDal = genreDal;
        }

        public List<Genre> GetAll()
        {
            return _genreDal.GetAll();
        }

        public List<Genre> GetById(int genreId)
        {
            return _genreDal.Get(g => g.GenreId == genreId);
        }
    }
}
