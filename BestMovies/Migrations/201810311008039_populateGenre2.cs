using BestMovies.BestMoviesDB;

namespace BestMovies.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class populateGenre2 : DbMigration
    {
        public override void Up()
        {
            using (var movieContext = new MovieContext())
            {
                movieContext.Database.ExecuteSqlCommand(
                    "INSERT INTO dbo.Genres (Name)"
                    + " VALUES ('Drama')"
                );
                movieContext.Database.ExecuteSqlCommand(
                    "INSERT INTO dbo.Genres (Name)"
                    + " VALUES ('Horror')"
                );
                movieContext.Database.ExecuteSqlCommand(
                    "INSERT INTO dbo.Genres (Name)"
                    + " VALUES ('Fantasy')"
                );
                movieContext.Database.ExecuteSqlCommand(
                    "INSERT INTO dbo.Genres (Name)"
                    + " VALUES ('Sci-fi')"
                );
                movieContext.Database.ExecuteSqlCommand(
                    "INSERT INTO dbo.Genres (Name)"
                    + " VALUES ('Comedy')"
                );
                movieContext.Database.ExecuteSqlCommand(
                    "INSERT INTO dbo.Genres (Name)"
                    + " VALUES ('Action')"
                );
            }
        }

        public override void Down()
        {
        }
    }
}
