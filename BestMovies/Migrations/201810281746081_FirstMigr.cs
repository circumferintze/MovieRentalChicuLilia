namespace BestMovies.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FirstMigr : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Customers",
                c => new
                    {
                        CustomersId = c.Int(nullable: false, identity: true),
                        FirstName = c.String(),
                        LastName = c.String(),
                        MoviesId = c.Int(nullable: false),
                        DomainModel_DomainModelId = c.Int(),
                    })
                .PrimaryKey(t => t.CustomersId)
                .ForeignKey("dbo.DomainModels", t => t.DomainModel_DomainModelId)
                .Index(t => t.DomainModel_DomainModelId);
            
            CreateTable(
                "dbo.Movies",
                c => new
                    {
                        MoviesId = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        CustomersId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.MoviesId);
            
            CreateTable(
                "dbo.DomainModels",
                c => new
                    {
                        DomainModelId = c.Int(nullable: false, identity: true),
                        MembershipTypeId = c.Int(nullable: false),
                        IsSubscribedToNewsLetter = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.DomainModelId);
            
            CreateTable(
                "dbo.MembershipTypes",
                c => new
                    {
                        MembershipTypeId = c.Int(nullable: false, identity: true),
                        Type = c.String(),
                        Duration = c.Byte(nullable: false),
                        SignUpFee = c.Int(nullable: false),
                        DiscountRate = c.Byte(nullable: false),
                    })
                .PrimaryKey(t => t.MembershipTypeId);
            
            CreateTable(
                "dbo.MoviesCustomers",
                c => new
                    {
                        MoviesId = c.Int(nullable: false),
                        CustomersId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.MoviesId, t.CustomersId })
                .ForeignKey("dbo.Movies", t => t.MoviesId, cascadeDelete: true)
                .ForeignKey("dbo.Customers", t => t.CustomersId, cascadeDelete: true)
                .Index(t => t.MoviesId)
                .Index(t => t.CustomersId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Customers", "DomainModel_DomainModelId", "dbo.DomainModels");
            DropForeignKey("dbo.MoviesCustomers", "CustomersId", "dbo.Customers");
            DropForeignKey("dbo.MoviesCustomers", "MoviesId", "dbo.Movies");
            DropIndex("dbo.MoviesCustomers", new[] { "CustomersId" });
            DropIndex("dbo.MoviesCustomers", new[] { "MoviesId" });
            DropIndex("dbo.Customers", new[] { "DomainModel_DomainModelId" });
            DropTable("dbo.MoviesCustomers");
            DropTable("dbo.MembershipTypes");
            DropTable("dbo.DomainModels");
            DropTable("dbo.Movies");
            DropTable("dbo.Customers");
        }
    }
}
