using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace BestMovies.Models
{
    public class MovieModel
    {
        [DisplayName("Name")]
        public string Title { get; set; }

        public string Genre { get; set; }

        [DisplayName("Release Date")]
        public DateTimeOffset ReleaseDate { get; set; }

        [DisplayName("Number in Stock")]
        public int NumberInStock { get; set; }

        public IEnumerable<string> Genres { get; set; }
    }
}