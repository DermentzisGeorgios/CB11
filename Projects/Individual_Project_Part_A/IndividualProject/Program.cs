using System;
using System.Collections.Generic;
using System.Linq;

namespace IndividualProject
{
    class Program
    {
        static void Main(string[] args)
        {
            Menu();
        }

        public static void Menu()
        {
            List<Courses> courseList = new List<Courses>();
            List<CoursesPerStudent> coursesPerStudent = new List<CoursesPerStudent>();
            List<Trainers> trainerList = new List<Trainers>();
            List<TrainersPerCourse> trainersPerCourse = new List<TrainersPerCourse>();
            List<Students> studentList = new List<Students>();
            List<StudentsPerCourse> studentsPerCourse = new List<StudentsPerCourse>();
            List<Assignments> assignmentList = new List<Assignments>();
            List<AssignmentsPerCourse> assignmentsPerCourse = new List<AssignmentsPerCourse>();
            List<AssignmentsPerStudent> assignmentsPerStudent = new List<AssignmentsPerStudent>();
            List<Students> someStudentList = new List<Students>();
            List<DateTime> dateWeek = new List<DateTime>();
            bool flag1 = true;
            int answer;
            int count = 0;
            Console.WriteLine("-------WELCOME!-------");
            while (flag1)
            {
                answer = Helper.ChooseNumber("\nPlease enter a number according to your choice:\n1. Add Data\n2. Show Data\n3. Exit", 3);
                switch (answer)
                {
                    case 1:
                        bool flag2 = true;
                        while (flag2)
                        {
                            answer = Helper.ChooseNumber("\nWhat would you like to add?\n1. Course\n2. Student\n3. Trainer\n4. Assignment\n5. Synthetic Data\n6. Back", 6);
                            switch (answer)
                            {
                                case 1:
                                    AddCourse(ref courseList, ref studentList, ref trainerList, ref assignmentList, ref studentsPerCourse, ref trainersPerCourse, ref assignmentsPerCourse, assignmentsPerStudent, someStudentList, dateWeek, coursesPerStudent);
                                    break;
                                case 2:
                                    AddStudent(ref studentList);
                                    break;
                                case 3:
                                    AddTrainer(ref trainerList);
                                    break;
                                case 4:
                                    AddAssignment(ref assignmentList);
                                    break;
                                case 5:
                                    AddSyntheticData(ref count, ref courseList, ref studentList, ref trainerList, ref assignmentList, ref studentsPerCourse, ref trainersPerCourse, ref assignmentsPerCourse);
                                    break;
                                default:
                                    flag2 = false;
                                    break;
                            }
                        }
                        break;
                    case 2:
                        bool flag3 = true;
                        while (flag3)
                        {
                            answer = Helper.ChooseNumber("\nWhat would you like to see?\n1. Courses\n2. Students\n3. Trainers\n4. Assignments\n5. Students per course\n6. Trainers per course\n7. Assignments per course\n8. Assignments per student\n9. Students with more than one courses\n10. Students who need to submit their assignments on a certain calendar week\n11. Back", 11);
                            if (answer != 11)
                            {
                                assignmentsPerStudent = new List<AssignmentsPerStudent>();
                                coursesPerStudent = new List<CoursesPerStudent>();
                                Helper.FillAssignmentsPerStudent(ref assignmentsPerStudent, ref coursesPerStudent, studentList, studentsPerCourse, assignmentsPerCourse);
                                someStudentList = new List<Students>();
                                Helper.FillSomeStudentList(ref someStudentList, coursesPerStudent);
                                dateWeek = new List<DateTime>();
                                Show.Lists(courseList, studentList, trainerList, assignmentList, studentsPerCourse, trainersPerCourse, assignmentsPerCourse, assignmentsPerStudent, someStudentList, dateWeek, coursesPerStudent, answer);
                                Console.WriteLine();
                            }
                            else
                                flag3 = false;
                        }
                        break;
                    default:
                        flag1 = false;
                        break;
                }
            }
        }


        public static void AddCourse(ref List<Courses> courseList, ref List<Students> studentList, ref List<Trainers> trainerList, ref List<Assignments> assignmentList, ref List<StudentsPerCourse> studentsPerCourse, ref List<TrainersPerCourse> trainersPerCourse, ref List<AssignmentsPerCourse> assignmentsPerCourse, List<AssignmentsPerStudent> assignmentsPerStudent, List<Students> someStudentList, List<DateTime> dateWeek, List<CoursesPerStudent> coursesPerStudent)
        {
            try
            {
                Courses course = new Courses(Helper.FixInput("title").ToUpper(), Helper.FixInput("stream").ToUpper(), Helper.FixInput("type").ToLower(), Helper.FixDate("the starting date"), Helper.FixDate("the end date"), courseList.Count() + 1);
                if (courseList.Count() > 0)
                {
                    bool flag = true;
                    while (flag)
                    {
                        foreach (var item in courseList)
                        {
                            if (course.NotEquals(course, item))
                                flag = false;
                            else
                            {
                                flag = true;
                                Console.WriteLine("The course you would like to add already exists! Please add a different course:");
                                course = new Courses(Helper.FixInput("title").ToUpper(), Helper.FixInput("stream").ToUpper(), Helper.FixInput("type").ToLower(), Helper.FixDate("the starting date"), Helper.FixDate("the end date"), courseList.Count() + 1);
                                break;
                            }
                        }
                    }
                }
                courseList.Add(course);

                int answer;
                if (studentList.Count() > 0)
                {
                    List<Students> studentsPerCourseList = new List<Students>();
                    do
                    {
                        do
                        {
                            Console.WriteLine($"Please choose a student from the list below to take the current course(1-{ studentList.Count()}):\n");
                            Show.Lists(courseList, studentList, trainerList, assignmentList, studentsPerCourse, trainersPerCourse, assignmentsPerCourse, assignmentsPerStudent, someStudentList, dateWeek, coursesPerStudent, 2);
                            answer = Helper.ChooseNumber("", studentList.Count());
                            if (studentsPerCourseList.Contains(studentList[answer - 1]))
                            {
                                Console.WriteLine("ERROR! The student you chose has already taken the current course!");
                                continue;
                            }
                            else
                                break;
                        } while (studentsPerCourseList.Contains(studentList[answer - 1]));
                        studentsPerCourseList.Add(studentList[answer - 1]);
                        Console.WriteLine("Success! The student you chose will take the current course.");
                        if (studentList.Count() <= studentsPerCourseList.Count())
                        {
                            Console.WriteLine("There aren't any more students you can choose from the list!");
                            break;
                        }
                        else
                            answer = Helper.ChooseNumber("Do you want to choose another student for the current course?\n1. Yes\n2. No", 2);
                    } while (answer == 1);
                    StudentsPerCourse SpC = new StudentsPerCourse(course, studentsPerCourseList);
                    studentsPerCourse.Add(SpC);
                }

                if (trainerList.Count() > 0)
                {
                    List<Trainers> trainersPerCourseList = new List<Trainers>();
                    do
                    {
                        do
                        {
                            Console.WriteLine($"Please choose a trainer from the list below to teach the current course(1-{trainerList.Count()}):\n");
                            Show.Lists(courseList, studentList, trainerList, assignmentList, studentsPerCourse, trainersPerCourse, assignmentsPerCourse, assignmentsPerStudent, someStudentList, dateWeek, coursesPerStudent, 3);
                            answer = Helper.ChooseNumber("", trainerList.Count());
                            if (trainersPerCourseList.Contains(trainerList[answer - 1]))
                            {
                                Console.WriteLine("ERROR! The trainer you chose already teaches the current course!");
                                continue;
                            }
                            else
                                break;
                        } while (trainersPerCourseList.Contains(trainerList[answer - 1]));
                        trainersPerCourseList.Add(trainerList[answer - 1]);
                        if (trainerList.Count() <= trainersPerCourseList.Count())
                        {
                            Console.WriteLine("There aren't any more trainers you can choose from the list!");
                            break;
                        }
                        else
                            answer = Helper.ChooseNumber("Do you want to choose another trainer for the current course?\n1. Yes\n2. No", 2);
                    } while (answer == 1);
                    TrainersPerCourse TpC = new TrainersPerCourse(course, trainersPerCourseList);
                    trainersPerCourse.Add(TpC);
                }

                if (assignmentList.Count() > 0)
                {
                    List<Assignments> assignmentsPerCourseList = new List<Assignments>();
                    do
                    {
                        do
                        {
                            Console.WriteLine($"Please choose an assignment from the list below to belong to the current course(1-{ assignmentList.Count()}):\n");
                            Show.Lists(courseList, studentList, trainerList, assignmentList, studentsPerCourse, trainersPerCourse, assignmentsPerCourse, assignmentsPerStudent, someStudentList, dateWeek, coursesPerStudent, 4);
                            answer = Helper.ChooseNumber("", assignmentList.Count());
                            if (assignmentsPerCourseList.Contains(assignmentList[answer - 1]))
                            {
                                Console.WriteLine("ERROR! The assignment you chose already belongs to the current course!");
                                continue;
                            }
                            else
                                break;
                        } while (assignmentsPerCourseList.Contains(assignmentList[answer - 1]));
                        assignmentsPerCourseList.Add(assignmentList[answer - 1]);
                        if (assignmentList.Count() <= assignmentsPerCourseList.Count())
                        {
                            Console.WriteLine("There aren't any more assignments you can choose from the list!");
                            break;
                        }
                        else
                            answer = Helper.ChooseNumber("Do you want to choose another assignment for the current course?\n1. Yes\n2. No", 2);
                    } while (answer == 1);
                    AssignmentsPerCourse ApC = new AssignmentsPerCourse(course, assignmentsPerCourseList);
                    assignmentsPerCourse.Add(ApC);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public static void AddStudent(ref List<Students> studentList)
        {
            try
            {
                Students student = new Students(Helper.FixInput("first name").ToUpper(), Helper.FixInput("last name").ToUpper(), Helper.FixDate("the date of birth"), Helper.FixDouble("tuition fees"), studentList.Count() + 1);
                if (studentList.Count() > 0)
                {
                    bool flag = true;
                    while (flag)
                    {
                        foreach (var item in studentList)
                        {
                            if (student.NotEquals(student, item))
                                flag = false;
                            else
                            {
                                flag = true;
                                Console.WriteLine("The student you would like to add already exists! Please add a different student:");
                                student = new Students(Helper.FixInput("first name").ToUpper(), Helper.FixInput("last name").ToUpper(), Helper.FixDate("the date of birth"), Helper.FixDouble("tuition fees"), studentList.Count() + 1);
                                break;
                            }
                        }
                    }
                }
                studentList.Add(student);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public static void AddTrainer(ref List<Trainers> trainerList)
        {
            try
            {
                Trainers trainer = new Trainers(Helper.FixInput("first name").ToUpper(), Helper.FixInput("last name").ToUpper(), Helper.FixInput("subject").ToUpper(), trainerList.Count() + 1);
                if (trainerList.Count() > 0)
                {
                    bool flag = true;
                    while (flag)
                    {
                        foreach (var item in trainerList)
                        {
                            if (trainer.NotEquals(trainer, item))
                                flag = false;
                            else
                            {
                                flag = true;
                                Console.WriteLine("The trainer you would like to add already exists! Please add a different trainer:");
                                trainer = new Trainers(Helper.FixInput("first name").ToUpper(), Helper.FixInput("last name").ToUpper(), Helper.FixInput("subject").ToUpper(), trainerList.Count() + 1);
                                break;
                            }
                        }
                    }
                }
                trainerList.Add(trainer);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public static void AddAssignment(ref List<Assignments> assignmentList)
        {
            try
            {
                Assignments assignment = new Assignments(Helper.FixInput("title").ToUpper(), Helper.FixInput("description").ToLower(), Helper.FixDate("the date of submission"), Helper.FixInt("oral mark"), Helper.FixInt("total mark"), assignmentList.Count() + 1);
                if (assignmentList.Count() > 0)
                {
                    bool flag = true;
                    while (flag)
                    {
                        foreach (var item in assignmentList)
                        {
                            if (assignment.NotEquals(assignment, item))
                                flag = false;
                            else
                            {
                                flag = true;
                                Console.WriteLine("The assignment you would like to add already exists! Please add a different assignment:");
                                assignment = new Assignments(Helper.FixInput("title").ToUpper(), Helper.FixInput("description").ToLower(), Helper.FixDate("the date of submission"), Helper.FixInt("oral mark"), Helper.FixInt("total mark"), assignmentList.Count() + 1);
                                break;
                            }
                        }
                    }
                }
                assignmentList.Add(assignment);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public static void AddSyntheticData(ref int count, ref List<Courses> courseList, ref List<Students> studentList, ref List<Trainers> trainerList, ref List<Assignments> assignmentList, ref List<StudentsPerCourse> studentsPerCourse, ref List<TrainersPerCourse> trainersPerCourse, ref List<AssignmentsPerCourse> assignmentsPerCourse)
        {
            try
            {
                if (count == 0)
                {
                    Helper.SyntheticData(ref courseList, ref studentList, ref trainerList, ref assignmentList, ref studentsPerCourse, ref trainersPerCourse, ref assignmentsPerCourse);
                    Console.WriteLine("Synthetic Data have been added!");
                }
                else
                    Console.WriteLine("You cannot add more synthetic data!");
                count = 1;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }

    public class TestMethod //Similar to some Helper class methods
    {
        public string CheckInput(string str)
        {
            if (string.IsNullOrWhiteSpace(str))
                Console.WriteLine("Error! This is not a valid sentence");
            else
                Console.WriteLine(str);
            return str;
        }

        public int ConvertToInt(string input)
        {
            int.TryParse(input, out int output);
            if (output.GetType() != input.GetType())
                Console.WriteLine("Success!");
            else
                Console.WriteLine("Fail!");
            return output;
        }
    }
}