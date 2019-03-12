namespace WineTasting.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ratings : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Rating", "GuestRating", c => c.Double(nullable: false));
            AddColumn("dbo.Wine", "OverallRating", c => c.Double(nullable: false));
            DropColumn("dbo.Rating", "PointRating");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Rating", "PointRating", c => c.Double(nullable: false));
            DropColumn("dbo.Wine", "OverallRating");
            DropColumn("dbo.Rating", "GuestRating");
        }
    }
}
