namespace BestMovies.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addDbSetGenre : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Movies", "Genre_GenreId", "dbo.Genres");
            DropIndex("dbo.Movies", new[] { "Genre_GenreId" });
            AddColumn("dbo.Movies", "ReleaseDate", c => c.DateTimeOffset(nullable: false, precision: 7));
            AddColumn("dbo.Movies", "Added", c => c.DateTimeOffset(nullable: false, precision: 7));
            AddColumn("dbo.Movies", "NumberInStock", c => c.Int(nullable: false));
            AlterColumn("dbo.Movies", "Title", c => c.String(nullable: false));
            AlterColumn("dbo.Movies", "Genre_GenreId", c => c.Int(nullable: false));
            CreateIndex("dbo.Movies", "Genre_GenreId");
            AddForeignKey("dbo.Movies", "Genre_GenreId", "dbo.Genres", "GenreId", cascadeDelete: true);
            DropColumn("dbo.Movies", "CustomersId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Movies", "CustomersId", c => c.Int(nullable: false));
            DropForeignKey("dbo.Movies", "Genre_GenreId", "dbo.Genres");
            DropIndex("dbo.Movies", new[] { "Genre_GenreId" });
            AlterColumn("dbo.Movies", "Genre_GenreId", c => c.Int());
            AlterColumn("dbo.Movies", "Title", c => c.String());
            DropColumn("dbo.Movies", "NumberInStock");
            DropColumn("dbo.Movies", "Added");
            DropColumn("dbo.Movies", "ReleaseDate");
            CreateIndex("dbo.Movies", "Genre_GenreId");
            AddForeignKey("dbo.Movies", "Genre_GenreId", "dbo.Genres", "GenreId");
        }
    }
}
