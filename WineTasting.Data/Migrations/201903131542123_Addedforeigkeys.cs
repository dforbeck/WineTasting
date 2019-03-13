namespace WineTasting.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Addedforeigkeys : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Rating", "Tasting_TastingId", "dbo.Tasting");
            DropForeignKey("dbo.Rating", "Wine_WineId", "dbo.Wine");
            DropIndex("dbo.Rating", new[] { "Tasting_TastingId" });
            DropIndex("dbo.Rating", new[] { "Wine_WineId" });
            RenameColumn(table: "dbo.Rating", name: "Tasting_TastingId", newName: "TastingId");
            RenameColumn(table: "dbo.Rating", name: "Wine_WineId", newName: "WineId");
            DropPrimaryKey("dbo.IdentityUserRole");
            AlterColumn("dbo.Rating", "TastingId", c => c.Int(nullable: false));
            AlterColumn("dbo.Rating", "WineId", c => c.Int(nullable: false));
            AlterColumn("dbo.IdentityUserRole", "RoleId", c => c.String());
            AlterColumn("dbo.IdentityUserRole", "UserId", c => c.String(nullable: false, maxLength: 128));
            AddPrimaryKey("dbo.IdentityUserRole", "UserId");
            CreateIndex("dbo.Rating", "WineId");
            CreateIndex("dbo.Rating", "TastingId");
            AddForeignKey("dbo.Rating", "TastingId", "dbo.Tasting", "TastingId", cascadeDelete: true);
            AddForeignKey("dbo.Rating", "WineId", "dbo.Wine", "WineId", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Rating", "WineId", "dbo.Wine");
            DropForeignKey("dbo.Rating", "TastingId", "dbo.Tasting");
            DropIndex("dbo.Rating", new[] { "TastingId" });
            DropIndex("dbo.Rating", new[] { "WineId" });
            DropPrimaryKey("dbo.IdentityUserRole");
            AlterColumn("dbo.IdentityUserRole", "UserId", c => c.String());
            AlterColumn("dbo.IdentityUserRole", "RoleId", c => c.String(nullable: false, maxLength: 128));
            AlterColumn("dbo.Rating", "WineId", c => c.Int());
            AlterColumn("dbo.Rating", "TastingId", c => c.Int());
            AddPrimaryKey("dbo.IdentityUserRole", "RoleId");
            RenameColumn(table: "dbo.Rating", name: "WineId", newName: "Wine_WineId");
            RenameColumn(table: "dbo.Rating", name: "TastingId", newName: "Tasting_TastingId");
            CreateIndex("dbo.Rating", "Wine_WineId");
            CreateIndex("dbo.Rating", "Tasting_TastingId");
            AddForeignKey("dbo.Rating", "Wine_WineId", "dbo.Wine", "WineId");
            AddForeignKey("dbo.Rating", "Tasting_TastingId", "dbo.Tasting", "TastingId");
        }
    }
}
