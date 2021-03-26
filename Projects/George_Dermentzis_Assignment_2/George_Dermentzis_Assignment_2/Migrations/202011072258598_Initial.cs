namespace George_Dermentzis_Assignment_2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Assignment",
                c => new
                    {
                        AssignmentID = c.Int(nullable: false, identity: true),
                        Title = c.String(nullable: false, maxLength: 40),
                        Description = c.String(),
                        SubmissionDate = c.DateTime(nullable: false),
                        OralMark = c.Int(),
                        TotalMark = c.Int(),
                    })
                .PrimaryKey(t => t.AssignmentID);
            
            CreateTable(
                "dbo.Course",
                c => new
                    {
                        CourseID = c.Int(nullable: false, identity: true),
                        Title = c.String(nullable: false, maxLength: 40),
                        Stream = c.String(nullable: false, maxLength: 40),
                        Type = c.Int(),
                        StartDate = c.DateTime(nullable: false),
                        EndDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.CourseID);
            
            CreateTable(
                "dbo.Student",
                c => new
                    {
                        StudentID = c.Int(nullable: false, identity: true),
                        FirstName = c.String(nullable: false, maxLength: 40),
                        LastName = c.String(nullable: false, maxLength: 40),
                        DateOfBirth = c.DateTime(),
                        TuitionFees = c.Decimal(precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.StudentID);
            
            CreateTable(
                "dbo.Trainer",
                c => new
                    {
                        TrainerID = c.Int(nullable: false, identity: true),
                        FirstName = c.String(nullable: false, maxLength: 40),
                        LastName = c.String(nullable: false, maxLength: 40),
                        Subject = c.String(maxLength: 40),
                    })
                .PrimaryKey(t => t.TrainerID);
            
            CreateTable(
                "dbo.AssignmentsPerCourse",
                c => new
                    {
                        CourseID = c.Int(nullable: false),
                        AssignmentID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.CourseID, t.AssignmentID })
                .ForeignKey("dbo.Course", t => t.CourseID, cascadeDelete: true)
                .ForeignKey("dbo.Assignment", t => t.AssignmentID, cascadeDelete: true)
                .Index(t => t.CourseID)
                .Index(t => t.AssignmentID);
            
            CreateTable(
                "dbo.StudentsPerCourse",
                c => new
                    {
                        CourseID = c.Int(nullable: false),
                        StudentID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.CourseID, t.StudentID })
                .ForeignKey("dbo.Course", t => t.CourseID, cascadeDelete: true)
                .ForeignKey("dbo.Student", t => t.StudentID, cascadeDelete: true)
                .Index(t => t.CourseID)
                .Index(t => t.StudentID);
            
            CreateTable(
                "dbo.TrainersPerCourse",
                c => new
                    {
                        CourseID = c.Int(nullable: false),
                        TrainerID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.CourseID, t.TrainerID })
                .ForeignKey("dbo.Course", t => t.CourseID, cascadeDelete: true)
                .ForeignKey("dbo.Trainer", t => t.TrainerID, cascadeDelete: true)
                .Index(t => t.CourseID)
                .Index(t => t.TrainerID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.TrainersPerCourse", "TrainerID", "dbo.Trainer");
            DropForeignKey("dbo.TrainersPerCourse", "CourseID", "dbo.Course");
            DropForeignKey("dbo.StudentsPerCourse", "StudentID", "dbo.Student");
            DropForeignKey("dbo.StudentsPerCourse", "CourseID", "dbo.Course");
            DropForeignKey("dbo.AssignmentsPerCourse", "AssignmentID", "dbo.Assignment");
            DropForeignKey("dbo.AssignmentsPerCourse", "CourseID", "dbo.Course");
            DropIndex("dbo.TrainersPerCourse", new[] { "TrainerID" });
            DropIndex("dbo.TrainersPerCourse", new[] { "CourseID" });
            DropIndex("dbo.StudentsPerCourse", new[] { "StudentID" });
            DropIndex("dbo.StudentsPerCourse", new[] { "CourseID" });
            DropIndex("dbo.AssignmentsPerCourse", new[] { "AssignmentID" });
            DropIndex("dbo.AssignmentsPerCourse", new[] { "CourseID" });
            DropTable("dbo.TrainersPerCourse");
            DropTable("dbo.StudentsPerCourse");
            DropTable("dbo.AssignmentsPerCourse");
            DropTable("dbo.Trainer");
            DropTable("dbo.Student");
            DropTable("dbo.Course");
            DropTable("dbo.Assignment");
        }
    }
}
