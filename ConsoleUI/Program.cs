using Business.Concrete;
using DataAccess.Concrete.InMemory;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Abstract;
using System;

namespace ConsoleUI
{
    //SOLID
    //Open Closed Principle
    class Program
    {
        static void Main(string[] args)
        {

            MovieManager movieManager = new MovieManager(new EfMovieDal());
            foreach (var movie in movieManager.GetAll()) 
            {
                Console.WriteLine(movie.MovieDirector);
            }
        }
    }
}
