namespace L15.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FixViolationType : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.ViolationTypes", "DrivingDeprivationDate", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.ViolationTypes", "DrivingDeprivationDate", c => c.DateTimeOffset(nullable: false, precision: 7));
        }
    }
}
