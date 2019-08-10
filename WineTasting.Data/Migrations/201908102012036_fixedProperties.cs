namespace WineTasting.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class fixedProperties : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Rating", "Tasting_TastingId", c => c.Int());
            AddColumn("dbo.Wine", "CodeForTasting", c => c.Int(nullable: false));
            CreateIndex("dbo.Rating", "Tasting_TastingId");
            AddForeignKey("dbo.Rating", "Tasting_TastingId", "dbo.Tasting", "TastingId");
            DropColumn("dbo.Wine", "CodeForBlindTasting");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Wine", "CodeForBlindTasting", c => c.Int(nullable: false));
            DropForeignKey("dbo.Rating", "Tasting_TastingId", "dbo.Tasting");
            DropIndex("dbo.Rating", new[] { "Tasting_TastingId" });
            DropColumn("dbo.Wine", "CodeForTasting");
            DropColumn("dbo.Rating", "Tasting_TastingId");
        }
    }
}
