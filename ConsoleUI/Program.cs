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
            foreach (var genre in genreManager.GetAll().Data)
            {
                Console.WriteLine(genre.GenreName);
            }
        }

        private static void MovieTest()
        {
            MovieManager movieManager = new MovieManager(new EfMovieDal(), new GenreManager(new EfGenreDal()));

            var result = movieManager.GetMovieDetails();

            if (result.Success==true)
            {
                foreach (var movie in result.Data)
                {
                    Console.WriteLine(movie.MovieName + "/" + movie.GenreName);
                }
            }
            else
            {
                Console.WriteLine(result.Message);
            }
        }
    }
}
