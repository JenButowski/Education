namespace L15.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.CarOwners",
                c => new
                    {
                        DriversLicenseCode = c.String(nullable: false, maxLength: 128),
                        Firstname = c.String(),
                        Lastname = c.String(),
                        Surname = c.String(),
                        Address = c.String(),
                        PhoneNumber = c.String(),
                    })
                .PrimaryKey(t => t.DriversLicenseCode);
            
            CreateTable(
                "dbo.Vehicles",
                c => new
                    {
                        Number = c.String(nullable: false, maxLength: 128),
                        Brand = c.String(),
                        Model = c.String(),
                        Color = c.String(),
                        ProductionYear = c.DateTime(nullable: false),
                        DateofRegistration = c.DateTime(nullable: false),
                        Owner_DriversLicenseCode = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Number)
                .ForeignKey("dbo.CarOwners", t => t.Owner_DriversLicenseCode)
                .Index(t => t.Owner_DriversLicenseCode);
            
            CreateTable(
                "dbo.Violations",
                c => new
                    {
                        Code = c.String(nullable: false, maxLength: 128),
                        Date = c.DateTime(nullable: false),
                        District = c.String(),
                        IsPaid = c.Boolean(nullable: false),
                        InspectorNumber = c.String(),
                        CarOwner_DriversLicenseCode = c.String(maxLength: 128),
                        Type_Code = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Code)
                .ForeignKey("dbo.CarOwners", t => t.CarOwner_DriversLicenseCode)
                .ForeignKey("dbo.ViolationTypes", t => t.Type_Code)
                .Index(t => t.CarOwner_DriversLicenseCode)
                .Index(t => t.Type_Code);
            
            CreateTable(
                "dbo.ViolationTypes",
                c => new
                    {
                        Code = c.String(nullable: false, maxLength: 128),
                        Name = c.String(),
                        PenaltySumm = c.Double(nullable: false),
                        DrivingDeprivationDate = c.DateTimeOffset(nullable: false, precision: 7),
                    })
                .PrimaryKey(t => t.Code);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Violations", "Type_Code", "dbo.ViolationTypes");
            DropForeignKey("dbo.Violations", "CarOwner_DriversLicenseCode", "dbo.CarOwners");
            DropForeignKey("dbo.Vehicles", "Owner_DriversLicenseCode", "dbo.CarOwners");
            DropIndex("dbo.Violations", new[] { "Type_Code" });
            DropIndex("dbo.Violations", new[] { "CarOwner_DriversLicenseCode" });
            DropIndex("dbo.Vehicles", new[] { "Owner_DriversLicenseCode" });
            DropTable("dbo.ViolationTypes");
            DropTable("dbo.Violations");
            DropTable("dbo.Vehicles");
            DropTable("dbo.CarOwners");
        }
    }
}
