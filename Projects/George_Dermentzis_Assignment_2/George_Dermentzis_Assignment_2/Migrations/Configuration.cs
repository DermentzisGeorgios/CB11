namespace George_Dermentzis_Assignment_2.Migrations
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using George_Dermentzis_Assignment_2.DAL;
    using George_Dermentzis_Assignment_2.enums;
    using George_Dermentzis_Assignment_2.Models;

    internal sealed class Configuration : DbMigrationsConfiguration<DAL.Assignment_2Context>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(DAL.Assignment_2Context context)
        {
            //var courses = new List<Course>
            //{
            //    new Course {Title = "CB11", Stream = "C#", Type = CourseType.Part_Time, StartDate = DateTime.Parse("2020-06-15"), EndDate = DateTime.Parse("2021-01-15"),
            //    Students = new List<Student>(),
            //    Trainers = new List<Trainer>(),
            //    Assignments = new List<Assignment>()},
            //    new Course {Title = "CB11", Stream = "Java", Type = CourseType.Full_Time, StartDate = DateTime.Parse("2020-06-15"), EndDate = DateTime.Parse("2020-10-15"),
            //    Students = new List<Student>(),
            //    Trainers = new List<Trainer>(),
            //    Assignments = new List<Assignment>()},
            //    new Course {Title = "CB10", Stream = "JavaScript", Type = CourseType.Part_Time, StartDate = DateTime.Parse("2019-09-10"), EndDate = DateTime.Parse("2020-03-10"),
            //    Students = new List<Student>(),
            //    Trainers = new List<Trainer>(),
            //    Assignments = new List<Assignment>()},
            //    new Course {Title = "CB12", Stream = "Python", Type = CourseType.Full_Time, StartDate = DateTime.Parse("2020-10-21"), EndDate = DateTime.Parse("2021-01-21"),
            //    Students = new List<Student>(),
            //    Trainers = new List<Trainer>(),
            //    Assignments = new List<Assignment>()}
            //};
            //courses.ForEach(c => context.Courses.AddOrUpdate(x => x.Stream, c));
            //context.SaveChanges();

            //var students = new List<Student>
            //{
            //    new Student {FirstName = "George", LastName = "Dermentzis", DateOfBirth = DateTime.Parse("1995-11-06"), TuitionFees = 1800},
            //    new Student {FirstName = "Afroditi", LastName = "Vlachou", DateOfBirth = DateTime.Parse("1995-08-18"), TuitionFees = 2200},
            //    new Student {FirstName = "Giannis", LastName = "Grigoriou", DateOfBirth = DateTime.Parse("1995-05-08"), TuitionFees = 2500},
            //    new Student {FirstName = "Vasilis", LastName = "Papadopoulos", DateOfBirth = DateTime.Parse("1994-03-08"), TuitionFees = 2250}
            //};
            //students.ForEach(s => context.Students.AddOrUpdate(p => p.LastName, s));
            //context.SaveChanges();

            //var trainers = new List<Trainer>
            //{
            //    new Trainer {FirstName = "Mixalis",   LastName = "Xamilos", Subject = "C#"},
            //    new Trainer {FirstName = "Ektoras", LastName = "Gkatsos", Subject = "JavaScript"},
            //    new Trainer {FirstName = "Periklis",   LastName = "Aidinopoulos", Subject = "C#"},
            //    new Trainer {FirstName = "George",    LastName = "Pasparakis", Subject = "Java"}
            //};
            //trainers.ForEach(s => context.Trainers.AddOrUpdate(p => p.LastName, s));
            //context.SaveChanges();

            //var assignments = new List<Assignment>
            //{
            //    new Assignment {Title = "Individual Project 1", SubmissionDate = DateTime.Parse("2020-06-28"), OralMark = 30, TotalMark = 70},
            //    new Assignment {Title = "School Project", SubmissionDate = DateTime.Parse("2020-09-18"), OralMark = 40, TotalMark = 80},
            //    new Assignment {Title = "Individual Project 2", SubmissionDate = DateTime.Parse("2020-07-27"), OralMark = 35, TotalMark = 75},
            //    new Assignment {Title = "Odd-Even", SubmissionDate = DateTime.Parse("2020-08-01"), OralMark = 50, TotalMark = 90}
            //};
            //assignments.ForEach(a => context.Assignments.AddOrUpdate(x => x.Title, a));
            //context.SaveChanges();

            //AddOrUpdateStudentsPerCourse(context, 1, 1);
            //AddOrUpdateStudentsPerCourse(context, 1, 4);
            //AddOrUpdateStudentsPerCourse(context, 2, 2);
            //AddOrUpdateStudentsPerCourse(context, 2, 3);
            //AddOrUpdateStudentsPerCourse(context, 3, 3);
            //AddOrUpdateStudentsPerCourse(context, 4, 1);
            //AddOrUpdateStudentsPerCourse(context, 4, 2);
            //AddOrUpdateStudentsPerCourse(context, 4, 3);

            //AddOrUpdateTrainersPerCourse(context, 1, 2);
            //AddOrUpdateTrainersPerCourse(context, 1, 3);
            //AddOrUpdateTrainersPerCourse(context, 2, 3);
            //AddOrUpdateTrainersPerCourse(context, 2, 4);
            //AddOrUpdateTrainersPerCourse(context, 3, 1);
            //AddOrUpdateTrainersPerCourse(context, 3, 4);
            //AddOrUpdateTrainersPerCourse(context, 4, 2);
            //AddOrUpdateTrainersPerCourse(context, 4, 3);
            //AddOrUpdateTrainersPerCourse(context, 4, 4);

            //AddOrUpdateAssignmentsPerCourse(context, 1, 1);
            //AddOrUpdateAssignmentsPerCourse(context, 1, 3);
            //AddOrUpdateAssignmentsPerCourse(context, 1, 4);
            //AddOrUpdateAssignmentsPerCourse(context, 2, 1);
            //AddOrUpdateAssignmentsPerCourse(context, 2, 3);
            //AddOrUpdateAssignmentsPerCourse(context, 3, 2);
            //AddOrUpdateAssignmentsPerCourse(context, 3, 4);
            //AddOrUpdateAssignmentsPerCourse(context, 4, 4);
        }

        private void AddOrUpdateStudentsPerCourse(Assignment_2Context context, int courseID, int studentID)
        {
            var course = context.Courses
                                .Include(c => c.Students)
                                .Include(c => c.Trainers)
                                .Include(c => c.Assignments)
                                .SingleOrDefault(c => c.CourseID == courseID);
            var student = course.Students.SingleOrDefault(s => s.StudentID == studentID);
            if (student == null)
                course.Students.Add(context.Students.Single(s => s.StudentID == studentID));
        }

        private void AddOrUpdateTrainersPerCourse(Assignment_2Context context, int courseID, int trainerID)
        {
            var course = context.Courses
                                .Include(c => c.Students)
                                .Include(c => c.Trainers)
                                .Include(c => c.Assignments)
                                .SingleOrDefault(c => c.CourseID == courseID);
            var trainer = course.Trainers.SingleOrDefault(t => t.TrainerID == trainerID);
            if (trainer == null)
                course.Trainers.Add(context.Trainers.Single(t => t.TrainerID == trainerID));
        }

        private void AddOrUpdateAssignmentsPerCourse(Assignment_2Context context, int courseID, int assignmentID)
        {
            var course = context.Courses
                                .Include(c => c.Students)
                                .Include(c => c.Trainers)
                                .Include(c => c.Assignments)
                                .SingleOrDefault(c => c.CourseID == courseID);
            var assignment = course.Assignments.SingleOrDefault(a => a.AssignmentID == assignmentID);
            if (assignment == null)
                course.Assignments.Add(context.Assignments.Single(a => a.AssignmentID == assignmentID));
        }
    }
}