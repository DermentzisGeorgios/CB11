using System;
using System.Collections.Generic;
using System.Linq;
using Individual_Project_Part_A.Infrastructure;
using Individual_Project_Part_A.Models;
using Individual_Project_Part_A.Validations;

namespace Individual_Project_Part_A.SyntheticData
{
    class MockData
    {
        private static bool created = false;

        public static void Create()
        {
            if (created == false)
            {
                CreateCourses();
                CreateStudents();
                CreateTrainers();
                CreateAssignments();
                CreateStudentsPerCourse();
                CreateTrainersPerCourse();
                CreateAssignmentsPerCourse();
                CreateAssignmentsPerStudent();
                created = true;
            }
            else
            {
                Helper.ErrorMsg("You have already created synthetic data!");
            }
        }

        private static void CreateCourses()
        {
            var list = new List<Course>
            {
                new Course(1, "CB11", "C#", "Part Time", new DateTime(2020, 06, 15), new DateTime(2021, 01, 15)),
                new Course(2, "CB11", "Java", "Full Time", new DateTime(2020, 06, 15), new DateTime(2020, 10, 15)),
                new Course(3, "CB10", "JavaScript", "Part Time", new DateTime(2019, 09, 10), new DateTime(2020, 03, 10)),
                new Course(4, "CB12", "Python", "Full Time", new DateTime(2020, 10, 21), new DateTime(2021, 01, 21))
            };

            Context.Courses.AddRange(list);
        }

        private static void CreateStudents()
        {
            var list = new List<Student>
            {
                new Student(1, "George", "Dermentzis", new DateTime(1995, 11, 06), 1800),
                new Student(2, "Afroditi", "Vlachou", new DateTime(1995, 08, 18), 2200),
                new Student(3, "Giannis", "Grigoriou", new DateTime(1995, 05, 08), 2500),
                new Student(4, "Vasilis", "Papasopoulos", new DateTime(1994, 03, 08), 2250)
            };

            Context.Students.AddRange(list);
        }

        private static void CreateTrainers()
        {
            var list = new List<Trainer>
            {
                new Trainer(1, "Mixalis", "Xamilos", "C#"),
                new Trainer(2, "Hector", "Gkatsos", "JavaScript"),
                new Trainer(3, "Periklis", "Aidinopoulos", "C#"),
                new Trainer(4, "George", "Pasparakis", "Java")
            };

            Context.Trainers.AddRange(list);
        }

        private static void CreateAssignments()
        {
            var list = new List<Assignment>
            {
                new Assignment(1, "Individual Project 1", "", new DateTime(2020, 06, 28), 30, 70),
                new Assignment(2, "School Project", "", new DateTime(2020, 09, 18), 40, 80),
                new Assignment(3, "Individual Project 2", "", new DateTime(2020, 07, 27), 35, 75),
                new Assignment(4, "Odd-Even", "", new DateTime(2020, 08, 01), 50, 90)
            };

            Context.Assignments.AddRange(list);
        }

        private static void CreateStudentsPerCourse()
        {
            var students = Context.Students.Where(s => s.Id == 1 || s.Id == 4).ToList();
            Context.StudentsPerCourse.Add(1, students);

            students = Context.Students.Where(s => s.Id == 2 || s.Id == 3).ToList();
            Context.StudentsPerCourse.Add(2, students);

            students = Context.Students.Where(s => s.Id == 3).ToList();
            Context.StudentsPerCourse.Add(3, students);

            students = Context.Students.Where(s => s.Id == 1 || s.Id == 2 || s.Id == 3).ToList();
            Context.StudentsPerCourse.Add(4, students);
        }

        private static void CreateTrainersPerCourse()
        {
            var trainers = Context.Trainers.Where(t => t.Id == 2 || t.Id == 3).ToList();
            Context.TrainersPerCourse.Add(1, trainers);

            trainers = Context.Trainers.Where(t => t.Id == 3 || t.Id == 4).ToList();
            Context.TrainersPerCourse.Add(2, trainers);

            trainers = Context.Trainers.Where(t => t.Id == 1 || t.Id == 4).ToList();
            Context.TrainersPerCourse.Add(3, trainers);

            trainers = Context.Trainers.Where(t => t.Id == 2 || t.Id == 3 || t.Id == 4).ToList();
            Context.TrainersPerCourse.Add(4, trainers);
        }

        private static void CreateAssignmentsPerCourse()
        {
            var assignments = Context.Assignments.Where(a => a.Id == 1 || a.Id == 3 || a.Id == 4).ToList();
            Context.AssignmentsPerCourse.Add(1, assignments);

            assignments = Context.Assignments.Where(a => a.Id == 1 || a.Id == 3).ToList();
            Context.AssignmentsPerCourse.Add(2, assignments);

            assignments = Context.Assignments.Where(a => a.Id == 2 || a.Id == 4).ToList();
            Context.AssignmentsPerCourse.Add(3, assignments);

            assignments = Context.Assignments.Where(a => a.Id == 4).ToList();
            Context.AssignmentsPerCourse.Add(4, assignments);
        }

        private static void CreateAssignmentsPerStudent()
        {
            var assignments = Context.Assignments.Where(a => a.Id == 1 || a.Id == 3 || a.Id == 4).ToList();
            Context.AssignmentsPerStudent.Add(1, assignments);

            Context.AssignmentsPerStudent.Add(2, assignments);

            Context.AssignmentsPerStudent.Add(3, Context.Assignments);

            Context.AssignmentsPerStudent.Add(4, assignments);
        }
    }
}