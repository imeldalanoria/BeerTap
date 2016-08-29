namespace BeerTap.DataPersistance.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.OfficeInfos",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        OfficeId = c.Int(nullable: false),
                        Beertype = c.String(),
                        Milliliter = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Office", t => t.OfficeId, cascadeDelete: true)
                .Index(t => t.OfficeId);
            
            CreateTable(
                "dbo.Office",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        OfficeName = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.OfficeInfos", "OfficeId", "dbo.Office");
            DropIndex("dbo.OfficeInfos", new[] { "OfficeId" });
            DropTable("dbo.Office");
            DropTable("dbo.OfficeInfos");
        }
    }
}
