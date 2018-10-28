using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BestMovies.Models
{
    public class Customers
    {
        public int CustomersId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public virtual ICollection<Movies> Movies { get; set; }
        public int MoviesId { get; set; }

    }
}