using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface IGenreService
    {
        List<Genre> GetAll();
        Genre GetByGenreId(int genreId);
    }
}
