namespace Base.Data1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class office_Migration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.HajjOffice",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        OfficeName = c.String(nullable: false, maxLength: 50),
                        OfficeRepresentativeID = c.Int(nullable: false),
                        OfficePhone = c.String(maxLength: 12),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Users", t => t.OfficeRepresentativeID, cascadeDelete: true)
                .Index(t => t.OfficeRepresentativeID);
            
            CreateTable(
                "dbo.HajjReq",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 50),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.OfficeReq",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        officeID = c.Int(nullable: false),
                        reqID = c.Int(nullable: false),
                        isBool = c.Boolean(nullable: false),
                        Amount = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.HajjOffice", t => t.officeID, cascadeDelete: true)
                .ForeignKey("dbo.HajjReq", t => t.reqID, cascadeDelete: true)
                .Index(t => t.officeID)
                .Index(t => t.reqID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.OfficeReq", "reqID", "dbo.HajjReq");
            DropForeignKey("dbo.OfficeReq", "officeID", "dbo.HajjOffice");
            DropForeignKey("dbo.HajjOffice", "OfficeRepresentativeID", "dbo.Users");
            DropIndex("dbo.OfficeReq", new[] { "reqID" });
            DropIndex("dbo.OfficeReq", new[] { "officeID" });
            DropIndex("dbo.HajjOffice", new[] { "OfficeRepresentativeID" });
            DropTable("dbo.OfficeReq");
            DropTable("dbo.HajjReq");
            DropTable("dbo.HajjOffice");
        }
    }
}
