using System;
using System.Collections.Generic;

namespace IndividualProject
{
    class Assignments
    {
        string title { get;}
        string description { get;}
        DateTime subDateTime;
        int oralMark { get;}
        int totalMark { get;}
        readonly int ID;

        public Assignments(string title, string description, DateTime subDateTime, int oralMark, int totalMark, int ID)
        {
            this.title = title;
            this.description = description;
            this.subDateTime = subDateTime;
            this.oralMark = oralMark;
            this.totalMark = totalMark;
            this.ID = ID;
        }

        public DateTime subDt
        {
            get { return subDateTime; }
            set { subDateTime = value; }
        }

        public void ShowAssignments()
        {
            Console.WriteLine($"{ID}. Title: {title}, Description: {description}. The assignment was submitted in {subDateTime.ToString("dd/MM/yyyy")}. The student's oral mark was {oralMark}% while the total mark was {totalMark}%.");
        }

        public bool NotEquals(Assignments assignment1, Assignments assignment2)
        {
            bool notEquals;
            if (assignment1.title != assignment2.title || assignment1.description != assignment2.description || assignment1.subDateTime != assignment2.subDateTime || assignment1.oralMark != assignment2.oralMark || assignment1.totalMark != assignment2.totalMark)
                notEquals = true;
            else
                notEquals = false;
            return notEquals;
        }
    }

    class AssignmentsPerCourse
    {
        Courses _course;
        List<Assignments> _assignmentsPerCourseList;

        public AssignmentsPerCourse(Courses course, List<Assignments> assignmentsPerCourseList)
        {
            _course = course;
            _assignmentsPerCourseList = assignmentsPerCourseList;
        }

        public Courses course
        {
            get { return _course; }
            set { _course = value; }
        }

        public List<Assignments> assignmentsPerCourseList
        {
            get { return _assignmentsPerCourseList; }
            set { _assignmentsPerCourseList = value; }
        }

        public void ShowAssignmentsPerCourse()
        {
            try
            {
                Console.WriteLine("\nCourse:");
                _course.ShowCourses();
                Console.WriteLine("\nAssignments:");
                foreach (Assignments obj in _assignmentsPerCourseList)
                {
                    obj.ShowAssignments();
                }
                Console.WriteLine();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }

    class AssignmentsPerStudent
    {
        Students _student;
        List<Assignments> _assignmentsPerStudentPerCourseList;

        public AssignmentsPerStudent() { }

        public Students student
        {
            get { return _student; }
            set { _student = value; }
        }

        public List<Assignments> assignmentsPerStudentPerCourseList
        {
            get { return _assignmentsPerStudentPerCourseList; }
            set { _assignmentsPerStudentPerCourseList = value; }
        }

        public AssignmentsPerStudent(Students student, List<Assignments> assignmentsPerStudentPerCourseList)
        {
            _student = student;
            _assignmentsPerStudentPerCourseList = assignmentsPerStudentPerCourseList;
        }

        public void ShowAssignmentsPerStudentPerCourse(List<CoursesPerStudent> coursesPerStudent)
        {
            try
            {
                Console.WriteLine("\nStudent:");
                _student.ShowStudents();
                Console.WriteLine("\nAssignments:");
                foreach (Assignments item in _assignmentsPerStudentPerCourseList)
                {
                    item.ShowAssignments();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public void ShowStudentAssignmentWeek(List<DateTime> dateWeek, List<AssignmentsPerStudent> assignmentPerStudent)
        {
            try
            {
                DateTime dt = Helper.FixDate("a date:").Date;
                Helper.CheckDayOfWeek(dt, ref dateWeek);
                foreach (AssignmentsPerStudent obj in assignmentPerStudent)
                {
                    foreach (Assignments item in obj.assignmentsPerStudentPerCourseList)
                    {
                        if (dateWeek.Contains(item.subDt.Date))
                        {
                            obj.student.ShowStudents();
                            Console.WriteLine();
                            break;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}