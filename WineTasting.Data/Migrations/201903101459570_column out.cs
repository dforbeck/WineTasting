namespace WineTasting.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class columnout : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Wine", "TastingId", "dbo.Tasting");
            DropIndex("dbo.Wine", new[] { "TastingId" });
            RenameColumn(table: "dbo.Wine", name: "TastingId", newName: "Tasting_TastingId");
            AlterColumn("dbo.Wine", "Tasting_TastingId", c => c.Int());
            CreateIndex("dbo.Wine", "Tasting_TastingId");
            AddForeignKey("dbo.Wine", "Tasting_TastingId", "dbo.Tasting", "TastingId");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Wine", "Tasting_TastingId", "dbo.Tasting");
            DropIndex("dbo.Wine", new[] { "Tasting_TastingId" });
            AlterColumn("dbo.Wine", "Tasting_TastingId", c => c.Int(nullable: false));
            RenameColumn(table: "dbo.Wine", name: "Tasting_TastingId", newName: "TastingId");
            CreateIndex("dbo.Wine", "TastingId");
            AddForeignKey("dbo.Wine", "TastingId", "dbo.Tasting", "TastingId", cascadeDelete: true);
        }
    }
}
