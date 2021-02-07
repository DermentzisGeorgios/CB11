using System;
using System.Collections.Generic;

namespace IndividualProject
{
    class Courses
    {
        string title { get;}
        string stream { get;}
        string type { get;}
        DateTime start_date { get;}
        DateTime end_date { get;}
        readonly int ID;

        public Courses(string title, string stream, string type, DateTime startDate, DateTime endDate, int ID)
        {
            this.title = title;
            this.stream = stream;
            this.type = type;
            this.start_date = startDate;
            this.end_date = endDate;
            this.ID = ID;
        }

        public void ShowCourses()
        {
            Console.WriteLine($"{ID}. Title: {title}, Stream: {stream}, Type: {type}, The course starts in {start_date.ToString("dd/MM/yyyy")} and ends in {end_date.ToString("dd/MM/yyyy")}.");
        }

        public bool NotEquals(Courses course1, Courses course2)
        {
            bool notEquals;
            if (course1.title != course2.title || course1.stream != course2.stream || course1.type != course2.type || course1.start_date != course2.start_date || course1.end_date != course2.end_date)
                notEquals = true;
            else
                notEquals = false;
            return notEquals;
        }
    }

    class CoursesPerStudent
    {
        Students _student;
        List<Courses> _coursesPerStudentList;

        public Students student
        {
            get { return _student; }
            set { _student = value; }
        }

        public List<Courses> coursesPerStudentList
        {
            get { return _coursesPerStudentList; }
            set { _coursesPerStudentList = value; }
        }

        public void ShowCoursesPerStudent()
        {
            try
            {
                Console.WriteLine("\nStudent:");
                _student.ShowStudents();
                Console.WriteLine("\nCourses:");
                foreach (Courses item in _coursesPerStudentList)
                {
                    item.ShowCourses();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}