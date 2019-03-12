namespace WineTasting.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Rating : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Rating",
                c => new
                    {
                        RatingId = c.Int(nullable: false, identity: true),
                        OwnerId = c.Guid(nullable: false),
                        PointRating = c.Double(nullable: false),
                        Comments = c.String(),
                        CreatedUtc = c.DateTimeOffset(nullable: false, precision: 7),
                        ModifiedUtc = c.DateTimeOffset(precision: 7),
                        Tasting_TastingId = c.Int(),
                        Wine_WineId = c.Int(),
                    })
                .PrimaryKey(t => t.RatingId)
                .ForeignKey("dbo.Tasting", t => t.Tasting_TastingId)
                .ForeignKey("dbo.Wine", t => t.Wine_WineId)
                .Index(t => t.Tasting_TastingId)
                .Index(t => t.Wine_WineId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Rating", "Wine_WineId", "dbo.Wine");
            DropForeignKey("dbo.Rating", "Tasting_TastingId", "dbo.Tasting");
            DropIndex("dbo.Rating", new[] { "Wine_WineId" });
            DropIndex("dbo.Rating", new[] { "Tasting_TastingId" });
            DropTable("dbo.Rating");
        }
    }
}
