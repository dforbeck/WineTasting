namespace WineTasting.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedWineTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Wine",
                c => new
                    {
                        WineId = c.Int(nullable: false, identity: true),
                        OwnerId = c.Guid(nullable: false),
                        Brand = c.String(nullable: false),
                        SubBrand = c.String(),
                        WineVarietal = c.Int(nullable: false),
                        Region = c.String(nullable: false),
                        Year = c.Int(nullable: false),
                        CodeForBlindTasting = c.Int(nullable: false),
                        CreatedUtc = c.DateTimeOffset(nullable: false, precision: 7),
                        ModifiedUtc = c.DateTimeOffset(precision: 7),
                        TastingId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.WineId)
                .ForeignKey("dbo.Tasting", t => t.TastingId, cascadeDelete: true)
                .Index(t => t.TastingId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Wine", "TastingId", "dbo.Tasting");
            DropIndex("dbo.Wine", new[] { "TastingId" });
            DropTable("dbo.Wine");
        }
    }
}
