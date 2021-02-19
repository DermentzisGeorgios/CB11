using System;
using System.Collections.Generic;
using System.Linq;
using Individual_Project_Part_A.Infrastructure;
using Individual_Project_Part_A.Interfaces;
using Individual_Project_Part_A.Models;
using Individual_Project_Part_A.Validations;

namespace Individual_Project_Part_A.Repositories
{
    class StudentRepository
    {


        public void AddStudent(IEqualityComparer<IModel> comparer)
        {
            var student = GetStudent();
            while (Context.Students.Contains(student, comparer))
            {
                Helper.ErrorMsg($"That student already exists!");
                student = GetStudent();
            }

            Context.Students.Add(student);
        }

        private Student GetStudent()
        {
            return new Student
            (
                Context.Students.Count + 1,
                Helper.ValidateString("First Name:", true),
                Helper.ValidateString("Last Name:", true),
                Helper.ValidateDate("Date of Birth:"),
                Helper.ValidateDouble("Tuition Fees:", 0)
            );
        }

        public void AddStudentsPerCourse(CourseRepository courseRepository, IEqualityComparer<IModel> comparer)
        {
            var courseId = courseRepository.GetCourseId();
            if (courseId == 0) return;

            var studentPicked = GetStudentById();
            if (studentPicked == null) return;

            AddStudentPerCourse(courseId, studentPicked, comparer);
        }

        private Student GetStudentById()
        {
            foreach (var student in Context.Students)
            {
                student.Print();
            }
            var studentId = Helper.ValidateInt($"\nPlease choose a student from 1 - {Context.Students.Count}, or 0 if you want to exit", 0, Context.Students.Count);
            if (studentId == 0) return null;

            return Context.Students.SingleOrDefault(s => s.Id == studentId);
        }

        private void AddStudentPerCourse(int courseId, Student student, IEqualityComparer<IModel> comparer)
        {
            if (Context.StudentsPerCourse.ContainsKey(courseId))
            {
                if (Context.StudentsPerCourse[courseId].Contains(student, comparer))
                {
                    Helper.ErrorMsg("You have already assigned this student to the current course!");
                    AddStudentPerCourse(courseId, GetStudentById(), comparer);
                }
                else
                    Context.StudentsPerCourse[courseId].Add(student);
            }
            else
                Context.StudentsPerCourse.Add(courseId, new List<Student> { student });
        }
    }
}