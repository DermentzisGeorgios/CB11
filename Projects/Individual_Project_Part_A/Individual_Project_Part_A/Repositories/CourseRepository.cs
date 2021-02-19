using System;
using System.Collections.Generic;
using System.Linq;
using Individual_Project_Part_A.Infrastructure;
using Individual_Project_Part_A.Interfaces;
using Individual_Project_Part_A.Models;
using Individual_Project_Part_A.Validations;

namespace Individual_Project_Part_A.Repositories
{
    class CourseRepository
    {
        public void AddCourse(IEqualityComparer<IModel> comparer)
        {
            var course = GetCourse();
            while (Context.Courses.Contains(course, comparer))
            {
                Helper.ErrorMsg($"That course already exists!");
                course = GetCourse();
            }

            Context.Courses.Add(course);
        }

        private Course GetCourse()
        {
            return new Course
            (
                Context.Courses.Count + 1,
                Helper.ValidateString("Title:"),
                Helper.ValidateString("Stream:"),
                Helper.ValidateString("Type:"),
                Helper.ValidateDate("Start Date:"),
                Helper.ValidateDate("End Date:")
            );
        }

        public int GetCourseId()
        {
            foreach (var course in Context.Courses)
            {
                course.Print();
            }
            return Helper.ValidateInt($"\nPlease choose a course from 1 - {Context.Courses.Count}, or 0 if you want to exit", 0, Context.Courses.Count);
        }
    }
}