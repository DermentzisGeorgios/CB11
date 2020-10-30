namespace FInalProject1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ContactInfo",
                c => new
                    {
                        ContactInfoID = c.Int(nullable: false),
                        FirstName = c.String(nullable: false, maxLength: 40),
                        LastName = c.String(nullable: false, maxLength: 40),
                        DateOfBirth = c.DateTime(),
                        City = c.String(nullable: false, maxLength: 40),
                        PostalCode = c.Int(),
                        Phone = c.String(maxLength: 10),
                    })
                .PrimaryKey(t => t.ContactInfoID)
                .ForeignKey("dbo.Developer", t => t.ContactInfoID)
                .Index(t => t.ContactInfoID);
            
            CreateTable(
                "dbo.Developer",
                c => new
                    {
                        DeveloperID = c.Int(nullable: false, identity: true),
                        Email = c.String(nullable: false),
                        Password = c.String(nullable: false, maxLength: 40),
                    })
                .PrimaryKey(t => t.DeveloperID);
            
            CreateTable(
                "dbo.Education",
                c => new
                    {
                        EducationID = c.Int(nullable: false),
                        School = c.String(nullable: false, maxLength: 100),
                        Degree = c.String(),
                        Field = c.String(),
                        Grade = c.Double(),
                        StartYear = c.Int(),
                        EndYear = c.Int(),
                    })
                .PrimaryKey(t => t.EducationID)
                .ForeignKey("dbo.Developer", t => t.EducationID)
                .Index(t => t.EducationID);
            
            CreateTable(
                "dbo.Skill",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Developer_DeveloperID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Developer", t => t.Developer_DeveloperID)
                .Index(t => t.Developer_DeveloperID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ContactInfo", "ContactInfoID", "dbo.Developer");
            DropForeignKey("dbo.Skill", "Developer_DeveloperID", "dbo.Developer");
            DropForeignKey("dbo.Education", "EducationID", "dbo.Developer");
            DropIndex("dbo.Skill", new[] { "Developer_DeveloperID" });
            DropIndex("dbo.Education", new[] { "EducationID" });
            DropIndex("dbo.ContactInfo", new[] { "ContactInfoID" });
            DropTable("dbo.Skill");
            DropTable("dbo.Education");
            DropTable("dbo.Developer");
            DropTable("dbo.ContactInfo");
        }
    }
}
