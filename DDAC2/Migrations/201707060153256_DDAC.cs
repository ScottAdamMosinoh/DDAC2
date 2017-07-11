namespace DDAC2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DDAC : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Containers",
                c => new
                    {
                        ContainerID = c.Int(nullable: false, identity: true),
                        ContainerName = c.String(),
                        ContainerWeight = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ContainerID);
            
            CreateTable(
                "dbo.Ships",
                c => new
                    {
                        ShipID = c.Int(nullable: false, identity: true),
                        ShipName = c.String(),
                    })
                .PrimaryKey(t => t.ShipID);
            
            CreateTable(
                "dbo.ShipYards",
                c => new
                    {
                        ShipYardID = c.Int(nullable: false, identity: true),
                        ShipYardName = c.String(),
                    })
                .PrimaryKey(t => t.ShipYardID);
            
            CreateTable(
                "dbo.Transports",
                c => new
                    {
                        TransportID = c.Int(nullable: false, identity: true),
                        ShipID = c.Int(nullable: false),
                        ContainerID = c.Int(nullable: false),
                        ArrivalTime = c.DateTime(nullable: false),
                        DepartureTime = c.DateTime(nullable: false),
                        Price = c.Double(nullable: false),
                        ArrivalShipyardID = c.Int(nullable: false),
                        DepartureShipyardID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.TransportID)
                .ForeignKey("dbo.Containers", t => t.ContainerID, cascadeDelete: false)
                .ForeignKey("dbo.Ships", t => t.ShipID, cascadeDelete: false)
                .ForeignKey("dbo.ShipYards", t => t.ArrivalShipyardID, cascadeDelete: false)
                .ForeignKey("dbo.ShipYards", t => t.DepartureShipyardID, cascadeDelete: false)
                .Index(t => t.ShipID)
                .Index(t => t.ContainerID)
                .Index(t => t.ArrivalShipyardID)
                .Index(t => t.DepartureShipyardID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Transports", "DepartureShipyardID", "dbo.ShipYards");
            DropForeignKey("dbo.Transports", "ArrivalShipyardID", "dbo.ShipYards");
            DropForeignKey("dbo.Transports", "ShipID", "dbo.Ships");
            DropForeignKey("dbo.Transports", "ContainerID", "dbo.Containers");
            DropIndex("dbo.Transports", new[] { "DepartureShipyardID" });
            DropIndex("dbo.Transports", new[] { "ArrivalShipyardID" });
            DropIndex("dbo.Transports", new[] { "ContainerID" });
            DropIndex("dbo.Transports", new[] { "ShipID" });
            DropTable("dbo.Transports");
            DropTable("dbo.ShipYards");
            DropTable("dbo.Ships");
            DropTable("dbo.Containers");
        }
    }
}
