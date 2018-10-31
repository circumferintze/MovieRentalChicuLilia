using BestMovies.BestMoviesDB;

namespace BestMovies.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class maefielBirthdayOptionl : DbMigration
    {
        public override void Up()
        {
            
        }

        public override void Down()
        {
            AlterColumn("dbo.Customers", "Birthday", c => c.DateTimeOffset(nullable: false, precision: 7));
        }
    }
}
