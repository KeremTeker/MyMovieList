using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.EntityFramework
{
    //NuGet
    public class EfMovieDal : IMovieDal
    {
        public void Add(Movie entity)
        {
            //IDisposable pattern implementation of c#
            using (SqlContext context = new SqlContext())
            {
                var addedEntity = context.Entry(entity);
                addedEntity.State = EntityState.Added;
                context.SaveChanges();
            }
        }

        public void Delete(Movie entity)
        {
            using (SqlContext context = new SqlContext())
            {
                var deletedEntity = context.Entry(entity);
                deletedEntity.State = EntityState.Deleted;
                context.SaveChanges();
            }
        }

        public Movie Get(Expression<Func<Movie, bool>> filter = null)
        {
            using (SqlContext context = new SqlContext())
            {
                return context.Set<Movie>().SingleOrDefault(filter);
            }
        }

        public List<Movie> GetAll(Expression<Func<Movie, bool>> filter = null)
        {
            using (SqlContext context = new SqlContext())
            {
                return filter == null ? context.Set<Movie>().ToList() : context.Set<Movie>().Where(filter).ToList();
            }
        }

        public void Update(Movie entity)
        {
            using (SqlContext context = new SqlContext())
            {
                var uptadedEntity = context.Entry(entity);
                uptadedEntity.State = EntityState.Modified;
                context.SaveChanges();
            }
        }
    }
}
