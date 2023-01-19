using Business.Concrete;
using Business.Abstract;
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
            MovieTest();
            //GenreTest();

        }

        private static void GenreTest()
        {
            GenreManager genreManager = new GenreManager(new EfGenreDal());
            foreach (var genre in genreManager.GetAll())
            {
                Console.WriteLine(genre.GenreName);
            }
        }

        private static void MovieTest()
        {
            MovieManager movieManager = new MovieManager(new EfMovieDal());
            foreach (var movie in movieManager.GetMovieDetails())
            {
                Console.WriteLine(movie.GenreName);
            }
        }
    }
}
