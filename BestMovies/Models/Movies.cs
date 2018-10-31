using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace BestMovies.Models
{
    public class Movies
    {
        public int MoviesId { get; set; }
        [DisplayName("Name")]
        [Required]
        public string Title { get; set; }

        [Required]
        public virtual Genre Genre { get; set; }

        [DisplayName("Release Date")]
        [Required]
        public DateTimeOffset ReleaseDate { get; set; }

        [Required]
        public DateTimeOffset Added { get; set; }

        [DisplayName("Number in Stock")]
        [Required]
        public int NumberInStock { get; set; }
        public virtual ICollection<Customers> Customers { get; set; }

    }


}