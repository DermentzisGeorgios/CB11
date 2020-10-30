namespace FInalProject1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Skill : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Skill", "Developer_DeveloperID", "dbo.Developer");
            DropIndex("dbo.Skill", new[] { "Developer_DeveloperID" });
            CreateTable(
                "dbo.Developers_Skills",
                c => new
                    {
                        DeveloperID = c.Int(nullable: false),
                        ID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.DeveloperID, t.ID })
                .ForeignKey("dbo.Developer", t => t.DeveloperID, cascadeDelete: true)
                .ForeignKey("dbo.Skill", t => t.ID, cascadeDelete: true)
                .Index(t => t.DeveloperID)
                .Index(t => t.ID);
            
            AlterColumn("dbo.Skill", "Name", c => c.String(maxLength: 40));
            DropColumn("dbo.Skill", "Developer_DeveloperID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Skill", "Developer_DeveloperID", c => c.Int());
            DropForeignKey("dbo.Developers_Skills", "ID", "dbo.Skill");
            DropForeignKey("dbo.Developers_Skills", "DeveloperID", "dbo.Developer");
            DropIndex("dbo.Developers_Skills", new[] { "ID" });
            DropIndex("dbo.Developers_Skills", new[] { "DeveloperID" });
            AlterColumn("dbo.Skill", "Name", c => c.String());
            DropTable("dbo.Developers_Skills");
            CreateIndex("dbo.Skill", "Developer_DeveloperID");
            AddForeignKey("dbo.Skill", "Developer_DeveloperID", "dbo.Developer", "DeveloperID");
        }
    }
}
