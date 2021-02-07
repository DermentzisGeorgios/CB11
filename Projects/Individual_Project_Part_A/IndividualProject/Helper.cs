using System;
using System.Collections.Generic;
using System.Linq;

namespace IndividualProject
{
    static class Helper
    {
        public static int ChooseNumber(string str, int b)
        {
            int answer;
            do
            {
                Console.WriteLine(str);
            } while (!int.TryParse(Console.ReadLine(), out answer) || answer < 1 || answer > b);
            return answer;
        }
        public static string FixInput(string str)
        {
            string answer;
            do
            {
                Console.WriteLine($"Please enter the {str}");
                answer = Console.ReadLine();
            } while (string.IsNullOrWhiteSpace(answer));
            return answer;
        }

        public static int FixInt(string str)
        {
            int answer;
            string input;
            do
            {
                Console.WriteLine($"Please enter the {str}");
                input = Console.ReadLine();
            } while (!int.TryParse(input, out answer) || answer < 0);
            return answer;
        }

        public static double FixDouble(string str)
        {
            double answer;
            string input;
            do
            {
                Console.WriteLine($"Please enter the {str}");
                input = Console.ReadLine();
            } while (!double.TryParse(input, out answer) || answer < 0);
            return answer;
        }

        public static DateTime FixDate(string str) //fix better
        {
            
            DateTime answer;
            string input;
            do
            {
                Console.WriteLine($"Please enter {str}");
                input = Console.ReadLine();
            } while (!DateTime.TryParse(input, out answer));
            return answer;
        }

        public static void FillAssignmentsPerStudent(ref List<AssignmentsPerStudent> assignmentsPerStudent, ref List<CoursesPerStudent> coursesPerStudent, List<Students> studentsList, List<StudentsPerCourse> studentsPerCourse, List<AssignmentsPerCourse> assignmentsPerCourse)
        {
            try
            {
                foreach (Students item in studentsList)
                {
                    CoursesPerStudent CpS = new CoursesPerStudent();
                    CpS.student = item;
                    CpS.coursesPerStudentList = new List<Courses>();
                    foreach (StudentsPerCourse obj in studentsPerCourse)
                    {
                        if (obj.studentsPerCourseList.Contains(item))
                        {
                            CpS.coursesPerStudentList.Add(obj.course);
                        }
                    }
                    coursesPerStudent.Add(CpS);
                }
            
                foreach (CoursesPerStudent cps in coursesPerStudent)
                {
                    AssignmentsPerStudent ApS = new AssignmentsPerStudent();
                    ApS.student = cps.student;
                    ApS.assignmentsPerStudentPerCourseList = new List<Assignments>();
                    foreach (AssignmentsPerCourse apc in assignmentsPerCourse)
                    {
                        if (cps.coursesPerStudentList.Contains(apc.course))
                        {
                            foreach (Assignments ass in apc.assignmentsPerCourseList)
                            {
                                if (!ApS.assignmentsPerStudentPerCourseList.Contains(ass))
                                    ApS.assignmentsPerStudentPerCourseList.Add(ass);
                            }
                        }
                    }
                    assignmentsPerStudent.Add(ApS);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public static void FillSomeStudentList(ref List<Students> someStudentList, List<CoursesPerStudent> coursesPerStudent)
        {
            try
            {
                foreach (CoursesPerStudent obj in coursesPerStudent)
                {
                    if (obj.coursesPerStudentList.Count() > 1)
                        someStudentList.Add(obj.student);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public static void CheckDayOfWeek(DateTime dt, ref List<DateTime> dateWeek)
        {
            try
            {
                switch (dt.DayOfWeek)
                {
                    case DayOfWeek.Monday:
                        for (int i = 0; i <= 4; i++)
                        {
                            dateWeek.Add(dt.AddDays(i));
                        }
                        break;
                    case DayOfWeek.Tuesday:
                        for (int i = -1; i <= 3; i++)
                        {
                            dateWeek.Add(dt.AddDays(i));
                        }
                        break;
                    case DayOfWeek.Wednesday:
                        for (int i = -2; i <= 2; i++)
                        {
                            dateWeek.Add(dt.AddDays(i));
                        }
                        break;
                    case DayOfWeek.Thursday:
                        for (int i = -3; i <= 1; i++)
                        {
                            dateWeek.Add(dt.AddDays(i));
                        }
                        break;
                    case DayOfWeek.Friday:
                        for (int i = 0; i <= 4; i++)
                        {
                            dateWeek.Add(dt.AddDays(-i));
                        }
                        break;
                    case DayOfWeek.Saturday:
                        for (int i = 1; i <= 5; i++)
                        {
                            dateWeek.Add(dt.AddDays(-i));
                        }
                        break;
                    case DayOfWeek.Sunday:
                        for (int i = 2; i <= 6; i++)
                        {
                            dateWeek.Add(dt.AddDays(-i));
                        }
                        break;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public static void SyntheticData(ref List<Courses> courselist, ref List<Students> studentlist, ref List<Trainers> trainerlist, ref List<Assignments> assignmentlist, ref List<StudentsPerCourse> studentPerCourse, ref List<TrainersPerCourse> trainerPerCourse, ref List<AssignmentsPerCourse> assignmentPerCourse)
        {
            Courses course1 = new Courses("CB11", "C#", "Part Time", new DateTime(2020, 6, 15), new DateTime(2021, 1, 15), 1);
            Courses course2 = new Courses("CB11", "Java", "Part Time", new DateTime(2020, 6, 15), new DateTime(2021, 1, 15), 2);
            Courses course3 = new Courses("CB12", "Python", "Part Time", new DateTime(2020, 10, 5), new DateTime(2021, 4, 5), 3);
            courselist.Add(course1); courselist.Add(course2); courselist.Add(course3);

            Students student1 = new Students("George", "Dermentzis", new DateTime(1995, 11, 6), 1800, 1);
            Students student2 = new Students("Afroditi", "Vlachou", new DateTime(1995, 8, 18), 2200, 2);
            Students student3 = new Students("Vasilis", "Papadopoulos", new DateTime(1994, 3, 8), 2250, 3);
            studentlist.Add(student1); studentlist.Add(student2); studentlist.Add(student3);

            List<Students> studentPerCourseList1 = new List<Students> { student1 };
            List<Students> studentPerCourseList2 = new List<Students> { student2 };
            List<Students> studentPerCourseList3 = new List<Students> { student3 };
            StudentsPerCourse studentPerCourse1 = new StudentsPerCourse(course1, studentPerCourseList1);
            StudentsPerCourse studentPerCourse2 = new StudentsPerCourse(course2, studentPerCourseList2);
            StudentsPerCourse studentPerCourse3 = new StudentsPerCourse(course3, studentPerCourseList3);
            studentPerCourse.Add(studentPerCourse1); studentPerCourse.Add(studentPerCourse2); studentPerCourse.Add(studentPerCourse3);

            Trainers trainer1 = new Trainers("Mixalis", "Xamilos", "C#", 1);
            Trainers trainer2 = new Trainers("George", "Pasparakis", "Java", 2);
            Trainers trainer3 = new Trainers("Aggelos", "Vegkos", "Java", 3);
            trainerlist.Add(trainer1); trainerlist.Add(trainer2); trainerlist.Add(trainer3);

            List<Trainers> trainerPerCourseList1 = new List<Trainers> { trainer1 };
            List<Trainers> trainerPerCourseList2 = new List<Trainers> { trainer2 };
            List<Trainers> trainerPerCourseList3 = new List<Trainers> { trainer3 };
            TrainersPerCourse trainerPerCourse1 = new TrainersPerCourse(course1, trainerPerCourseList1);
            TrainersPerCourse trainerPerCourse2 = new TrainersPerCourse(course2, trainerPerCourseList2);
            TrainersPerCourse trainerPerCourse3 = new TrainersPerCourse(course3, trainerPerCourseList3);
            trainerPerCourse.Add(trainerPerCourse1); trainerPerCourse.Add(trainerPerCourse2); trainerPerCourse.Add(trainerPerCourse3);

            Assignments assignment1 = new Assignments("Individual Project 2 Part A", "On this project you are required to build a command prompt (console) application", new DateTime(2020, 7, 27), 40, 75, 1);
            Assignments assignment2 = new Assignments("Individual Project 2", "During the development of this project you need to do the implementation of a private school structure", new DateTime(2020, 9, 18), 40, 80, 2);
            Assignments assignment3 = new Assignments("Individual Project 1", "Ask from the user the following questions and store the answers to appropriate variables", new DateTime(2020, 6, 28), 30, 70, 3);
            assignmentlist.Add(assignment1); assignmentlist.Add(assignment2); assignmentlist.Add(assignment3);

            List<Assignments> assignmentPerCourseList1 = new List<Assignments> { assignment1 };
            List<Assignments> assignmentPerCourseList2 = new List<Assignments> { assignment2 };
            List<Assignments> assignmentPerCourseList3 = new List<Assignments> { assignment3 };
            AssignmentsPerCourse assignmentPerCourse1 = new AssignmentsPerCourse(course1, assignmentPerCourseList1);
            AssignmentsPerCourse assignmentPerCourse2 = new AssignmentsPerCourse(course2, assignmentPerCourseList2);
            AssignmentsPerCourse assignmentPerCourse3 = new AssignmentsPerCourse(course3, assignmentPerCourseList3);
            assignmentPerCourse.Add(assignmentPerCourse1); assignmentPerCourse.Add(assignmentPerCourse2); assignmentPerCourse.Add(assignmentPerCourse3);
        }
    }
}