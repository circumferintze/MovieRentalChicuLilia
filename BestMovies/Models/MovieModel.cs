using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace BestMovies.Models
{
    public class MovieModel
    {
        [DisplayName("Title")]
        [Required(ErrorMessage = "Title is requiered")]
        [RegularExpression("^[a-zA-Z0-9]*$", ErrorMessage = "Only Alphabets and Numbers allowed.")]
        public string Title { get; set; }

        [DisplayName("Confirm Title ")]
        [Compare("Title", ErrorMessage = "The Title and Confirm Title fields do not match.")]
        public string ConfirmTitle { get; set; }

        [Required(ErrorMessage = "Genre is requiered")]
        public string Genre { get; set; }

        [DisplayName("Release Date")]
        [Required(ErrorMessage = "Release date is requiered")]
        public DateTimeOffset? ReleaseDate { get; set; }

        [Required(ErrorMessage = "Number in stock is requiered")]
        [Range(1, 10, ErrorMessage = "Number in stock must be between 1 and 10")]
        [DisplayName("Number in Stock")]
        public int NumberInStock { get; set; }

        public IEnumerable<string> Genres { get; set; }
    }
}