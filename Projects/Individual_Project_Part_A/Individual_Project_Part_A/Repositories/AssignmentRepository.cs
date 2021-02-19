using System;
using System.Collections.Generic;
using System.Linq;
using Individual_Project_Part_A.Infrastructure;
using Individual_Project_Part_A.Interfaces;
using Individual_Project_Part_A.Models;
using Individual_Project_Part_A.Validations;

namespace Individual_Project_Part_A.Repositories
{
    class AssignmentRepository
    {
        public void AddAssignment(IEqualityComparer<IModel> comparer)
        {
            var assignment = GetAssignment();
            while (Context.Assignments.Contains(assignment, comparer))
            {
                Helper.ErrorMsg($"That assignment already exists!");
                assignment = GetAssignment();
            }

            Context.Assignments.Add(assignment);
        }

        private Assignment GetAssignment()
        {
            return new Assignment
            (
                Context.Assignments.Count + 1,
                Helper.ValidateString("Title"),
                Helper.ValidateString("Description"),
                Helper.ValidateDate("Submission Date:"),
                Helper.ValidateInt("Oral Mark %:", 0, 100),
                Helper.ValidateInt("Total Mark %:",0, 100)
            );
        }

        public void AddAssignmentsPerCourse(CourseRepository courseRepository, IEqualityComparer<IModel> comparer)
        {
            var courseId = courseRepository.GetCourseId();
            if (courseId == 0) return;

            var assignmentPicked = GetAssignmentById();
            if (assignmentPicked == null) return;

            AddAssignmentPerCourse(courseId, assignmentPicked, comparer);
        }

        private Assignment GetAssignmentById()
        {
            foreach (var assignment in Context.Assignments)
            {
                assignment.Print();
            }
            var assignmentId = Helper.ValidateInt($"\nPlease choose an assignment from 1 - {Context.Assignments.Count}, or 0 if you want to exit", 0, Context.Assignments.Count);
            if (assignmentId == 0) return null;

            return Context.Assignments.SingleOrDefault(a => a.Id == assignmentId);
        }

        private void AddAssignmentPerCourse(int courseId, Assignment assignment, IEqualityComparer<IModel> comparer)
        {
            if (Context.AssignmentsPerCourse.ContainsKey(courseId))
            {
                if (Context.AssignmentsPerCourse[courseId].Contains(assignment, comparer))
                {
                    Helper.ErrorMsg("You have already assigned this assignment to the current course!");
                    AddAssignmentPerCourse(courseId, GetAssignmentById(), comparer);
                }
                else
                    Context.AssignmentsPerCourse[courseId].Add(assignment);
            }
            else
                Context.AssignmentsPerCourse.Add(courseId, new List<Assignment> { assignment });
        }
    }
}