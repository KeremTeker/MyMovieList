using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Concrete
{
    public class Genre:IEntity
    {
        public int GenreId { get; set; }
        public string GenreName { get; set; }
    }
}
