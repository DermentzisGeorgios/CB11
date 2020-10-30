using System;
using System.Data.Entity.Infrastructure;
using System.Linq;
using IndividualProject.Entities;

namespace IndividualProject
{
    class Menu
    {
        public void Welcome()
        {
            bool flag1 = true;
            Console.WriteLine("-------WELCOME!-------");
            while (flag1)
            {
                int answer = Helper.ChooseNumber("\nPlease enter a number according to your choice:\n1. Add Data\n2. Show Data\n3. Exit", 3);
                switch (answer)
                {
                    case 1:
                        AddData();
                        break;
                    case 2:
                        ShowData();
                        break;
                    default:
                        flag1 = false;
                        break;
                }
            }
        }

        public void AddData()
        {
            bool flag2 = true;
            while (flag2)
            {
                int answer = Helper.ChooseNumber("\nWhat would you like to add?\n1. Course\n2. Student\n3. Trainer\n4. Assignment\n5. Back", 5);
                switch (answer)
                {
                    case 1:
                        AddCourse();
                        break;
                    case 2:
                        AddStudent();
                        break;
                    case 3:
                        AddTrainer();
                        break;
                    case 4:
                        AddAssignment();
                        break;
                    default:
                        flag2 = false;
                        break;
                }
            }
        }
        public void ShowData()
        {
            bool flag3 = true;
            while (flag3)
            {
                int answer = Helper.ChooseNumber("\nWhat would you like to see?\n1. Courses\n2. Students\n3. Trainers\n4. Assignments\n5. Students per course\n6. Trainers per course\n7. Assignments per course\n8. Assignments per student per course\n9. Students with more than one courses\n10. Back", 10);
                if (answer != 10)
                    Show.Lists(answer);
                else
                    flag3 = false;
            }
        }

        void FillCourse(Courses course)
        {
            course.title = Helper.FixInput("Please enter the title:");
            course.stream = Helper.FixInput("Please enter the stream:");
            course.type = Helper.FixInput("Please enter the type:");
            course.start_date = Helper.FixDate("Please enter the starting date(yyyy/mm/dd):");
            course.end_date = Helper.FixDate("Please enter the end date(yyyy/mm/dd):");
        }
        void AddCourse()
        {
            using (IndividualProject_Model IP = new IndividualProject_Model())
            {
                try
                {
                    Courses course = new Courses();
                    FillCourse(course);
                    bool flag = true;
                    while (flag) //check duplicates
                    {
                        foreach (var item in IP.Courses)
                        {
                            if (Helper.NotEquals(course, item))
                                flag = false;
                            else
                            {
                                flag = true;
                                Console.WriteLine("The course you would like to add already exists! Please add a different course:");
                                course = new Courses();
                                FillCourse(course);
                                break;
                            }
                        }
                    }
                    IP.Courses.Add(course);
                    IP.SaveChanges();
                }
                catch (DbUpdateException ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }

        void FillStudent(Students student)
        {
            student.firstName = Helper.FixInput("Please enter the firstname:");
            student.lastName = Helper.FixInput("Please enter the lastname:");
            student.dateOfBirth = Helper.FixDate("Please enter the date of birth(yyyy/mm/dd):");
            student.tuitionFees = Helper.FixDecimal("Please enter the tuition fees:");
        }
        void StudentToCourse(Students student)
        {
            using (IndividualProject_Model IP = new IndividualProject_Model())
            {
                try
                {
                    int answer;
                    int coursesTaken = 0;
                    bool flag;
                    do //add more courses to student
                    {
                        do //check if the student has already taken the chosen course
                        {
                            flag = false;
                            Console.WriteLine($"Please choose a course from the list below for the current student to take(1-{IP.Courses.Count()}):\n");
                            Show.ShowCourses(IP);
                            answer = Helper.ChooseNumber("", IP.Courses.Count());
                            foreach (var item in IP.StudentsPerCourse)
                            {
                                if (student.studentID == item.student_ID && answer == item.course_ID)
                                {
                                    Console.WriteLine("ERROR! The current student has already taken the course you chose!");
                                    flag = true;
                                    break;
                                }
                            }
                        } while (flag);
                        StudentsPerCourse SpC = new StudentsPerCourse();
                        SpC.course_ID = answer;
                        coursesTaken++;
                        SpC.student_ID = student.studentID;
                        IP.StudentsPerCourse.Add(SpC);
                        Console.WriteLine("Success! The current student will take course you chose.");
                        if (IP.Courses.Count() <= coursesTaken)
                        {
                            Console.WriteLine("There aren't any more courses you can choose from the list!");
                            break;
                        }
                        else
                            answer = Helper.ChooseNumber("Do you want to choose another course for the current student to take?\n1. Yes\n2. No", 2);
                    } while (answer == 1);
                    IP.SaveChanges();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }
        void AddStudent()
        {
            using (IndividualProject_Model IP = new IndividualProject_Model())
            {
                try
                {
                    Students student = new Students();
                    FillStudent(student);
                    bool flag = true;
                    while (flag)
                    {
                        foreach (var item in IP.Students)
                        {
                            if (Helper.NotEquals(student, item))
                                flag = false;
                            else
                            {
                                flag = true;
                                Console.WriteLine("The student you would like to add already exists! Please add a different student:");
                                student = new Students();
                                FillStudent(student);
                                break;
                            }
                        }
                    }
                    IP.Students.Add(student);
                    IP.SaveChanges();
                    StudentToCourse(student);
                }
                catch (DbUpdateException ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }

        void FillTrainer(Trainers trainer)
        {
            trainer.firstName = Helper.FixInput("Please enter the firstname:");
            trainer.lastName = Helper.FixInput("Please enter the lastname:");
            trainer.subject = Helper.FixInput("Please enter the subject:");
        }
        void TrainerToCourse(Trainers trainer)
        {
            using (IndividualProject_Model IP = new IndividualProject_Model())
            {
                try
                {
                    int answer;
                    int coursesTaken = 0;
                    bool flag;
                    do //add more courses to student
                    {
                        do //check if the student has already taken the chosen course
                        {
                            flag = false;
                            Console.WriteLine($"Please choose a course from the list below for the current trainer to take(1-{IP.Courses.Count()}):\n");
                            Show.ShowCourses(IP);
                            answer = Helper.ChooseNumber("", IP.Courses.Count());
                            foreach (var item in IP.TrainersPerCourse)
                            {
                                if (trainer.trainerID == item.trainer_ID && answer == item.course_ID)
                                {
                                    Console.WriteLine("ERROR! The current trainer has already taken the course you chose!");
                                    flag = true;
                                    break;
                                }
                            }
                        } while (flag);
                        TrainersPerCourse TpC = new TrainersPerCourse();
                        TpC.course_ID = answer;
                        coursesTaken++;
                        TpC.trainer_ID = trainer.trainerID;
                        IP.TrainersPerCourse.Add(TpC);
                        Console.WriteLine("Success! The current trainer will take the course you chose.");
                        if (IP.Courses.Count() <= coursesTaken)
                        {
                            Console.WriteLine("There aren't any more courses you can choose from the list!");
                            break;
                        }
                        else
                            answer = Helper.ChooseNumber("Do you want to choose another course for the current trainer to take?\n1. Yes\n2. No", 2);
                    } while (answer == 1);
                    IP.SaveChanges();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }
        void AddTrainer()
        {
            using (IndividualProject_Model IP = new IndividualProject_Model())
            {
                try
                {
                    Trainers trainer = new Trainers();
                    FillTrainer(trainer);
                    bool flag = true;
                    while (flag)
                    {
                        foreach (var item in IP.Trainers)
                        {
                            if (Helper.NotEquals(trainer, item))
                                flag = false;
                            else
                            {
                                flag = true;
                                Console.WriteLine("The trainer you would like to add already exists! Please add a different trainer:");
                                trainer = new Trainers();
                                FillTrainer(trainer);
                                break;
                            }
                        }
                    }
                    IP.Trainers.Add(trainer);
                    IP.SaveChanges();
                    TrainerToCourse(trainer);
                }
                catch (DbUpdateException ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }

        void FillAssignment(Assignments assignment)
        {
            assignment.title = Helper.FixInput("Please enter the title:");
            assignment.description = Helper.FixInput("Please enter the description:");
            assignment.subDateTime = Helper.FixDate("Please enter the sub date(yyyy/mm/dd):");
            assignment.oralMark = Helper.FixInt("Please enter the oral mark:");
            assignment.totalMark = Helper.FixInt("Please enter the total mark:");
        }
        void AssignmentToCourse(Assignments assignment)
        {
            using (IndividualProject_Model IP = new IndividualProject_Model())
            {
                try
                {
                    int answer;
                    int coursesTaken = 0;
                    bool flag;
                    do //add more courses to student
                    {
                        do //check if the student has already taken the chosen course
                        {
                            flag = false;
                            Console.WriteLine($"Please choose a course from the list below to have the current assignment(1-{IP.Courses.Count()}):\n");
                            Show.ShowCourses(IP);
                            answer = Helper.ChooseNumber("", IP.Courses.Count());
                            foreach (var item in IP.AssignmentsPerCourse)
                            {
                                if (assignment.assignmentID == item.assignment_ID && answer == item.course_ID)
                                {
                                    Console.WriteLine("ERROR! The course you chose already has the current assignment!");
                                    flag = true;
                                    break;
                                }
                            }
                        } while (flag);
                        AssignmentsPerCourse ApC = new AssignmentsPerCourse();
                        ApC.course_ID = answer;
                        coursesTaken++;
                        ApC.assignment_ID = assignment.assignmentID;
                        IP.AssignmentsPerCourse.Add(ApC);
                        Console.WriteLine("Success! The the course you chose will have the current assignment.");
                        if (IP.Courses.Count() <= coursesTaken)
                        {
                            Console.WriteLine("There aren't any more courses you can choose from the list!");
                            break;
                        }
                        else
                            answer = Helper.ChooseNumber("Do you want to choose another course to have the current assignment?\n1. Yes\n2. No", 2);
                    } while (answer == 1);
                    IP.SaveChanges();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }
        void AddAssignment()
        {
            using (IndividualProject_Model IP = new IndividualProject_Model())
            {
                try
                {
                    Assignments assignment = new Assignments();
                    FillAssignment(assignment);
                    bool flag = true;
                    while (flag)
                    {
                        foreach (var item in IP.Assignments)
                        {
                            if (Helper.NotEquals(assignment, item))
                                flag = false;
                            else
                            {
                                flag = true;
                                Console.WriteLine("The assignment you would like to add already exists! Please add a different assignment:");
                                assignment = new Assignments();
                                FillAssignment(assignment);
                                break;
                            }
                        }
                    }
                    IP.Assignments.Add(assignment);
                    IP.SaveChanges();
                    AssignmentToCourse(assignment);
                }
                catch (DbUpdateException ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }
    }
}
