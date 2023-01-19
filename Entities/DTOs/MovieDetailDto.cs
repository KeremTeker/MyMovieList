using Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.DTOs
{
    public class MovieDetailDto:IDto
    {
        public int MovieId { get; set; }
        public string GenreName { get; set; }
        public string MovieName { get; set; }
        public int MovieYear { get; set; }

    }
}
