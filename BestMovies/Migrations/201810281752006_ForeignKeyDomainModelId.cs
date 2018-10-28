namespace BestMovies.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ForeignKeyDomainModelId : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.MembershipTypes", "DomainModelId", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.MembershipTypes", "DomainModelId");
        }
    }
}
