namespace BestMovies.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class relationDomModelandMembershipType : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Customers", "DomainModel_DomainModelId", "dbo.DomainModels");
            RenameColumn(table: "dbo.Customers", name: "DomainModel_DomainModelId", newName: "DomainModel_MembershipTypeId");
            RenameIndex(table: "dbo.Customers", name: "IX_DomainModel_DomainModelId", newName: "IX_DomainModel_MembershipTypeId");
            DropPrimaryKey("dbo.DomainModels");
            AlterColumn("dbo.DomainModels", "DomainModelId", c => c.Int(nullable: false));
            AlterColumn("dbo.DomainModels", "MembershipTypeId", c => c.Int(nullable: false, identity: true));
            AddPrimaryKey("dbo.DomainModels", "MembershipTypeId");
            AddForeignKey("dbo.Customers", "DomainModel_MembershipTypeId", "dbo.DomainModels", "MembershipTypeId");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Customers", "DomainModel_MembershipTypeId", "dbo.DomainModels");
            DropPrimaryKey("dbo.DomainModels");
            AlterColumn("dbo.DomainModels", "MembershipTypeId", c => c.Int(nullable: false));
            AlterColumn("dbo.DomainModels", "DomainModelId", c => c.Int(nullable: false, identity: true));
            AddPrimaryKey("dbo.DomainModels", "DomainModelId");
            RenameIndex(table: "dbo.Customers", name: "IX_DomainModel_MembershipTypeId", newName: "IX_DomainModel_DomainModelId");
            RenameColumn(table: "dbo.Customers", name: "DomainModel_MembershipTypeId", newName: "DomainModel_DomainModelId");
            AddForeignKey("dbo.Customers", "DomainModel_DomainModelId", "dbo.DomainModels", "DomainModelId");
        }
    }
}
