namespace Infinity.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class v1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Orders",
                c => new
                    {
                        OrderID = c.Int(nullable: false, identity: true),
                        UserID = c.String(nullable: false),
                        UserAddress = c.String(nullable: false),
                        OrderDetails = c.String(),
                        TotalPrice = c.Int(nullable: false),
                        Date = c.String(),
                        Status = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.OrderID);
            
            CreateTable(
                "dbo.Products",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Image = c.String(nullable: false),
                        Model = c.String(nullable: false),
                        Cost = c.Int(nullable: false),
                        Brand = c.String(nullable: false),
                        Desktop = c.Boolean(nullable: false),
                        TwoInOne = c.Boolean(nullable: false),
                        Touch = c.Boolean(nullable: false),
                        Laptop = c.Boolean(nullable: false),
                        Gaming = c.Boolean(nullable: false),
                        Workstation = c.Boolean(nullable: false),
                        Core = c.Int(nullable: false),
                        Generation = c.Int(nullable: false),
                        Processor = c.String(nullable: false),
                        Size = c.Single(nullable: false),
                        Resolution = c.String(nullable: false),
                        Length = c.Single(nullable: false),
                        Width = c.Single(nullable: false),
                        Height = c.Single(nullable: false),
                        Weight = c.Single(nullable: false),
                        RAM = c.Int(nullable: false),
                        DriveType = c.Boolean(nullable: false),
                        DiskSpace = c.Int(nullable: false),
                        USBA = c.Int(nullable: false),
                        USBC = c.Int(nullable: false),
                        Ethernet = c.Int(nullable: false),
                        HDMI = c.Int(nullable: false),
                        VGA = c.Int(nullable: false),
                        AudioJack = c.Boolean(nullable: false),
                        DVDPlayer = c.Boolean(nullable: false),
                        Feature = c.String(nullable: false),
                        Software = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Products");
            DropTable("dbo.Orders");
        }
    }
}
