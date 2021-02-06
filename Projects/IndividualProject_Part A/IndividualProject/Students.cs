using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IndividualProject
{
    class Students
    {
        string firstName { get;}
        string lastName { get;}
        DateTime dateOfBirth { get;}
        double tuitionFees { get;}
        readonly int ID;

        public Students(string firstName, string lastName, DateTime dateOfBirth, double tuitionFees, int ID)
        {
            this.firstName = firstName;
            this.lastName = lastName;
            this.dateOfBirth = dateOfBirth;
            this.tuitionFees = tuitionFees;
            this.ID = ID;
        }

        public void ShowStudents()
        {
            Console.WriteLine($"{ID}. {lastName} {firstName} born in {dateOfBirth.ToString("dd/MM/yyyy")}. The tuition fees are {tuitionFees}$.");
        }

        public bool NotEquals(Students student1, Students student2)
        {
            bool notEquals;
            if (student1.firstName != student2.firstName || student1.lastName != student2.lastName || student1.dateOfBirth != student2.dateOfBirth || student1.tuitionFees != student2.tuitionFees)
                notEquals = true;
            else
                notEquals = false;
            return notEquals;
        }
    }

    class StudentsPerCourse
    {
        Courses _course;
        List<Students> _studentsPerCourseList;

        public StudentsPerCourse(Courses course, List<Students> studentsPerCourseList)
        {
            _course = course;
            _studentsPerCourseList = studentsPerCourseList;
        }

        public Courses course
        {
            get { return _course; }
            set { _course = value; }
        }

        public List<Students> studentsPerCourseList
        {
            get { return _studentsPerCourseList; }
            set { _studentsPerCourseList = value; }
        }

        public void ShowStudentsPerCourse()
        {
            try
            {
                Console.WriteLine("\nCourse:");
                _course.ShowCourses();
                Console.WriteLine("\nStudents:");
                foreach (Students obj in _studentsPerCourseList)
                {
                    obj.ShowStudents();
                }
                Console.WriteLine();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
