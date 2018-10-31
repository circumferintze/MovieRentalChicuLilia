namespace BestMovies.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class removDomainModel : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Customers", "DomainModel_DomainModelId", "dbo.DomainModels");
            DropForeignKey("dbo.DomainModels", "MembershipTypeId", "dbo.MembershipTypes");
            DropIndex("dbo.Customers", new[] { "DomainModel_DomainModelId" });
            DropIndex("dbo.DomainModels", new[] { "MembershipTypeId" });
            AddColumn("dbo.Customers", "MembershipTypeId", c => c.Int(nullable: false));
            AddColumn("dbo.Customers", "IsSubscribedToNewsLetter", c => c.Boolean(nullable: false));
            CreateIndex("dbo.Customers", "MembershipTypeId");
            AddForeignKey("dbo.Customers", "MembershipTypeId", "dbo.MembershipTypes", "MembershipTypeId", cascadeDelete: true);
            DropColumn("dbo.Customers", "DomainModel_DomainModelId");
            DropTable("dbo.DomainModels");
        }

        public override void Down()
        {
            CreateTable(
                "dbo.DomainModels",
                c => new
                {
                    DomainModelId = c.Int(nullable: false, identity: true),
                    MembershipTypeId = c.Int(nullable: false),
                    IsSubscribedToNewsLetter = c.Boolean(nullable: false),
                })
                .PrimaryKey(t => t.DomainModelId);

            AddColumn("dbo.Customers", "DomainModel_DomainModelId", c => c.Int());
            DropForeignKey("dbo.Customers", "MembershipTypeId", "dbo.MembershipTypes");
            DropIndex("dbo.Customers", new[] { "MembershipTypeId" });
            DropColumn("dbo.Customers", "IsSubscribedToNewsLetter");
            DropColumn("dbo.Customers", "MembershipTypeId");
            CreateIndex("dbo.DomainModels", "MembershipTypeId");
            CreateIndex("dbo.Customers", "DomainModel_DomainModelId");
            AddForeignKey("dbo.DomainModels", "MembershipTypeId", "dbo.MembershipTypes", "MembershipTypeId", cascadeDelete: true);
            AddForeignKey("dbo.Customers", "DomainModel_DomainModelId", "dbo.DomainModels", "DomainModelId");
        }
    }
}
