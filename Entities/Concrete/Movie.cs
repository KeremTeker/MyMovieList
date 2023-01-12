using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Concrete
{
    public class Movie:IEntity
    {
        public int MovieId { get; set; }
        public int GenreId { get; set; }
        public string MovieName { get; set; }
        public int MovieYear { get; set; }
        public int MovieDuration { get; set; }
        public double MovieMyMovieListPoint { get; set; }
        public double MovieImdbPoint { get; set; }
        public double MovieMyPoint { get; set; }
        public string MovieTopic { get; set; }
        public string MovieDirector { get; set; }
        public int MovieListedOn { get; set; }
    }
}
