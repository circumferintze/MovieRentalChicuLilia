using BestMovies.Models;
using System.Data.Entity;

namespace BestMovies.BestMoviesDB
{
    public class MovieContext : DbContext
    {

        public MovieContext() : base(@"server=(localdb)\MSSQLLocalDB;database=MoviesDB;trusted_connection=true;")
        //<add name = "CONNECTION_STRING_NAME" connectionString="Data Source=.;Initial Catalog=DATABASE_NAME;Integrated Security=True;" />
        {
        }
        public virtual DbSet<Customers> Customers { get; set; }
        public virtual DbSet<Movies> Movies { get; set; }
        public virtual DbSet<MembershipType> MembershipTypes { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Movies>()
                .HasMany(c => c.Customers)
                .WithMany(m => m.Movies)
                .Map(ca =>
                {
                    ca.MapLeftKey("MoviesId");
                    ca.MapRightKey("CustomersId");
                    ca.ToTable("MoviesCustomers");
                });

        }
    }
}