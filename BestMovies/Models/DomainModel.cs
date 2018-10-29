using System.Collections.Generic;
namespace BestMovies.Models
{
    public class DomainModel
    {
      public int DomainModelId { get; set; }
      public virtual ICollection<Customers> Customers { get; set; }
      public virtual MembershipType MembershipType { get; set; }
      public int MembershipTypeId { get; set; }
      public bool IsSubscribedToNewsLetter { get; set; }   
    }
}