namespace WineTasting.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class deletedwinedate : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Wine", "TastingDate");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Wine", "TastingDate", c => c.DateTimeOffset(nullable: false, precision: 7));
        }
    }
}
