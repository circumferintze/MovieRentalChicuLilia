namespace BestMovies.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class newRelDomainandMembTypes : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Customers", "DomainModel_MembershipTypeId", "dbo.DomainModels");
            RenameColumn(table: "dbo.Customers", name: "DomainModel_MembershipTypeId", newName: "DomainModel_DomainModelId");
            RenameIndex(table: "dbo.Customers", name: "IX_DomainModel_MembershipTypeId", newName: "IX_DomainModel_DomainModelId");
            DropPrimaryKey("dbo.DomainModels");
            AlterColumn("dbo.DomainModels", "MembershipTypeId", c => c.Int(nullable: false));
            AlterColumn("dbo.DomainModels", "DomainModelId", c => c.Int(nullable: false, identity: true));
            AddPrimaryKey("dbo.DomainModels", "DomainModelId");
            CreateIndex("dbo.DomainModels", "MembershipTypeId");
            AddForeignKey("dbo.DomainModels", "MembershipTypeId", "dbo.MembershipTypes", "MembershipTypeId", cascadeDelete: true);
            AddForeignKey("dbo.Customers", "DomainModel_DomainModelId", "dbo.DomainModels", "DomainModelId");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Customers", "DomainModel_DomainModelId", "dbo.DomainModels");
            DropForeignKey("dbo.DomainModels", "MembershipTypeId", "dbo.MembershipTypes");
            DropIndex("dbo.DomainModels", new[] { "MembershipTypeId" });
            DropPrimaryKey("dbo.DomainModels");
            AlterColumn("dbo.DomainModels", "DomainModelId", c => c.Int(nullable: false));
            AlterColumn("dbo.DomainModels", "MembershipTypeId", c => c.Int(nullable: false, identity: true));
            AddPrimaryKey("dbo.DomainModels", "MembershipTypeId");
            RenameIndex(table: "dbo.Customers", name: "IX_DomainModel_DomainModelId", newName: "IX_DomainModel_MembershipTypeId");
            RenameColumn(table: "dbo.Customers", name: "DomainModel_DomainModelId", newName: "DomainModel_MembershipTypeId");
            AddForeignKey("dbo.Customers", "DomainModel_MembershipTypeId", "dbo.DomainModels", "MembershipTypeId");
        }
    }
}
