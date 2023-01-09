using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfGenreDal : IGenreDal
    {
        public void Add(Genre entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(Genre entity)
        {
            throw new NotImplementedException();
        }

        public Genre Get(Expression<Func<Genre, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        public List<Genre> GetAll(Expression<Func<Genre, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        public void Update(Genre entity)
        {
            throw new NotImplementedException();
        }
    }
}
