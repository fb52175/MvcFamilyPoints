namespace FamilyPoints.Service.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Families",
                c => new
                    {
                        FamilyId = c.Int(nullable: false, identity: true),
                        FamilyName = c.String(),
                    })
                .PrimaryKey(t => t.FamilyId);
            
            CreateTable(
                "dbo.Parents",
                c => new
                    {
                        ParentId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Password = c.String(),
                        FamilyId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ParentId)
                .ForeignKey("dbo.Families", t => t.FamilyId, cascadeDelete: true)
                .Index(t => t.FamilyId);
            
            CreateTable(
                "dbo.Children",
                c => new
                    {
                        ChildId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Password = c.String(),
                        FamilyId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ChildId)
                .ForeignKey("dbo.Families", t => t.FamilyId, cascadeDelete: true)
                .Index(t => t.FamilyId);
            
            CreateTable(
                "dbo.Behaviors",
                c => new
                    {
                        BehaviorID = c.Int(nullable: false, identity: true),
                        Description = c.String(),
                        Points = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.BehaviorID);
            
            CreateTable(
                "dbo.Rewards",
                c => new
                    {
                        RewardID = c.Int(nullable: false, identity: true),
                        Description = c.String(),
                        Points = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.RewardID);
            
            CreateTable(
                "dbo.Transactions",
                c => new
                    {
                        TransactionID = c.Int(nullable: false, identity: true),
                        Date = c.DateTime(nullable: false),
                        ChildId = c.Int(nullable: false),
                        ParentId = c.Int(nullable: false),
                        PointType = c.String(),
                        Description = c.String(),
                        Points = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.TransactionID);
            
        }
        
        public override void Down()
        {
            DropIndex("dbo.Children", new[] { "FamilyId" });
            DropIndex("dbo.Parents", new[] { "FamilyId" });
            DropForeignKey("dbo.Children", "FamilyId", "dbo.Families");
            DropForeignKey("dbo.Parents", "FamilyId", "dbo.Families");
            DropTable("dbo.Transactions");
            DropTable("dbo.Rewards");
            DropTable("dbo.Behaviors");
            DropTable("dbo.Children");
            DropTable("dbo.Parents");
            DropTable("dbo.Families");
        }
    }
}
