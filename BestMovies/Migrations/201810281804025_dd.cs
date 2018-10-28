namespace BestMovies.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class dd : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.MembershipTypes", "DomainModelId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.MembershipTypes", "DomainModelId", c => c.Int(nullable: false));
        }
    }
}
