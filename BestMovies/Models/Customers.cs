using System;
using System.Collections.Generic;

namespace BestMovies.Models
{
    public class Customers
    {
        public int CustomersId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public virtual ICollection<Movies> Movies { get; set; }
        public int MoviesId { get; set; }
        public virtual MembershipType MembershipType { get; set; }
        public int MembershipTypeId { get; set; }
        public bool IsSubscribedToNewsLetter { get; set; }
        public DateTimeOffset? Birthday { get; set; }

    }
}