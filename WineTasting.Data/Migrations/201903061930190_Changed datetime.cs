namespace WineTasting.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Changeddatetime : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Tasting", "TastingDate", c => c.DateTimeOffset(nullable: false, precision: 7));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Tasting", "TastingDate", c => c.DateTime(nullable: false));
        }
    }
}
