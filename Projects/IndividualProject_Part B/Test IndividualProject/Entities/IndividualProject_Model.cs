namespace IndividualProject.Entities
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class IndividualProject_Model : DbContext
    {
        public IndividualProject_Model()
            : base("name=IndividualProject_Model")
        {
        }

        public virtual DbSet<Assignments> Assignments { get; set; }
        public virtual DbSet<AssignmentsPerCourse> AssignmentsPerCourse { get; set; }
        public virtual DbSet<Courses> Courses { get; set; }
        public virtual DbSet<Students> Students { get; set; }
        public virtual DbSet<StudentsPerCourse> StudentsPerCourse { get; set; }
        public virtual DbSet<Trainers> Trainers { get; set; }
        public virtual DbSet<TrainersPerCourse> TrainersPerCourse { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Assignments>()
                .HasMany(e => e.AssignmentsPerCourse)
                .WithRequired(e => e.Assignments)
                .HasForeignKey(e => e.assignment_ID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Courses>()
                .HasMany(e => e.AssignmentsPerCourse)
                .WithRequired(e => e.Courses)
                .HasForeignKey(e => e.course_ID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Courses>()
                .HasMany(e => e.StudentsPerCourse)
                .WithRequired(e => e.Courses)
                .HasForeignKey(e => e.course_ID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Courses>()
                .HasMany(e => e.TrainersPerCourse)
                .WithRequired(e => e.Courses)
                .HasForeignKey(e => e.course_ID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Students>()
                .Property(e => e.tuitionFees)
                .HasPrecision(8, 2);

            modelBuilder.Entity<Students>()
                .HasMany(e => e.StudentsPerCourse)
                .WithRequired(e => e.Students)
                .HasForeignKey(e => e.student_ID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Trainers>()
                .HasMany(e => e.TrainersPerCourse)
                .WithRequired(e => e.Trainers)
                .HasForeignKey(e => e.trainer_ID)
                .WillCascadeOnDelete(false);
        }
    }
}
