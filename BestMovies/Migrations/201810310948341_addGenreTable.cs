namespace BestMovies.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addGenreTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Genres",
                c => new
                    {
                        GenreId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.GenreId);
            
            AddColumn("dbo.Movies", "Genre_GenreId", c => c.Int());
            CreateIndex("dbo.Movies", "Genre_GenreId");
            AddForeignKey("dbo.Movies", "Genre_GenreId", "dbo.Genres", "GenreId");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Movies", "Genre_GenreId", "dbo.Genres");
            DropIndex("dbo.Movies", new[] { "Genre_GenreId" });
            DropColumn("dbo.Movies", "Genre_GenreId");
            DropTable("dbo.Genres");
        }
    }
}
