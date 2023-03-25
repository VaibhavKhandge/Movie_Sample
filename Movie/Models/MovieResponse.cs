using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace moie.Models
{
    public class MovieResponse
    {
        public List<Movie> Movies { get; set; }

        public MovieResponse()
        {
            this.Movies = new List<Movie>();
        }
        public string Message { get; set; }
    }
}
