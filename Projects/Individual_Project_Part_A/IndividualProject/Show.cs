using System;
using System.Collections.Generic;

namespace IndividualProject
{
    static class Show
    {
        public static void Lists(List<Courses> courseList, List<Students> studentList, List<Trainers> trainerList, List<Assignments> assignmentList, List<StudentsPerCourse> studentsPerCourse, List<TrainersPerCourse> trainersPerCourse, List<AssignmentsPerCourse> assignmentsPerCourse, List<AssignmentsPerStudent> assignmentsPerStudent, List<Students> someStudentList, List<DateTime> dateWeek, List<CoursesPerStudent> coursesPerStudent, int x)
        {
            try
            {
                switch (x)
                {
                    case 1:
                        foreach (Courses obj in courseList)
                        {
                            obj.ShowCourses();
                        }
                        break;
                    case 2:
                        foreach (Students obj in studentList)
                        {
                            obj.ShowStudents();
                        }
                        break;
                    case 3:
                        foreach (Trainers obj in trainerList)
                        {
                            obj.ShowTrainers();
                        }
                        break;
                    case 4:
                        foreach (Assignments obj in assignmentList)
                        {
                            obj.ShowAssignments();
                        }
                        break;
                    case 5:
                        foreach (StudentsPerCourse obj in studentsPerCourse)
                        {
                            obj.ShowStudentsPerCourse();
                        }
                        break;
                    case 6:
                        foreach (TrainersPerCourse obj in trainersPerCourse)
                        {
                            obj.ShowTrainersPerCourse();
                        }
                        break;
                    case 7:
                        foreach (AssignmentsPerCourse obj in assignmentsPerCourse)
                        {
                            obj.ShowAssignmentsPerCourse();
                        }
                        break;
                    case 8:
                        foreach (AssignmentsPerStudent obj in assignmentsPerStudent)
                        {
                            obj.ShowAssignmentsPerStudentPerCourse(coursesPerStudent);
                        }
                        break;
                    case 9:
                        foreach (Students obj in someStudentList)
                        {
                            obj.ShowStudents();
                        }
                        break;
                    case 10:
                        AssignmentsPerStudent temp = new AssignmentsPerStudent();
                        temp.ShowStudentAssignmentWeek(dateWeek, assignmentsPerStudent);
                        break;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}