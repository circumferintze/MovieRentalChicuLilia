using System.Collections.Generic;

namespace BestMovies.Models
{
    public class Movies
    {
        public int MoviesId { get; set; }
        public string Title { get; set; }
        public virtual ICollection<Customers> Customers { get; set; }
        public int CustomersId { get; set; }
        public virtual Genre Genre { get; set; }

    }
}