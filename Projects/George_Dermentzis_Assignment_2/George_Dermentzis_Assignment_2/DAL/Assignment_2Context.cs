using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;
using George_Dermentzis_Assignment_2.Models;
using Microsoft.Ajax.Utilities;

namespace George_Dermentzis_Assignment_2.DAL
{
    public class Assignment_2Context : DbContext
    {
        public DbSet<Course> Courses { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<Trainer> Trainers { get; set; }
        public DbSet<Assignment> Assignments { get; set; }

        public Assignment_2Context() : base("Assignment_2Context")
        { }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

            modelBuilder.Entity<Course>()
                .HasMany(c => c.Students)
                .WithMany(s => s.Courses)
                .Map(sc => sc.MapLeftKey("CourseID")
                .MapRightKey("StudentID")
                .ToTable("StudentsPerCourse"));

            modelBuilder.Entity<Course>()
                .HasMany(c => c.Trainers)
                .WithMany(t => t.Courses)
                .Map(tc => tc.MapLeftKey("CourseID")
                .MapRightKey("TrainerID")
                .ToTable("TrainersPerCourse"));

            modelBuilder.Entity<Course>()
                .HasMany(c => c.Assignments)
                .WithMany(a => a.Courses)
                .Map(ac => ac.MapLeftKey("CourseID")
                .MapRightKey("AssignmentID")
                .ToTable("AssignmentsPerCourse"));
        }
    }
}