using System;
using System.Collections.Generic;
using Individual_Project_Part_A.Models;

namespace Individual_Project_Part_A.Infrastructure
{
    class Context
    {
        public static List<Course> Courses { get; set; }
        public static List<Student> Students { get; set; }
        public static List<Trainer> Trainers { get; set; }
        public static List<Assignment> Assignments { get; set; }
        public static Dictionary<int, List<Student>> StudentsPerCourse { get; set; }
        public static Dictionary<int, List<Trainer>> TrainersPerCourse { get; set; }
        public static Dictionary<int, List<Assignment>> AssignmentsPerCourse { get; set; }
        public static Dictionary<int, List<Assignment>> AssignmentsPerStudent { get; set; }

        static Context()
        {
            Courses = new List<Course>();
            Students = new List<Student>();
            Trainers = new List<Trainer>();
            Assignments = new List<Assignment>();
            StudentsPerCourse = new Dictionary<int, List<Student>>();
            TrainersPerCourse = new Dictionary<int, List<Trainer>>();
            AssignmentsPerCourse = new Dictionary<int, List<Assignment>>();
            AssignmentsPerStudent = new Dictionary<int, List<Assignment>>();
        }
    }
}