using System;
using System.Linq;
using IndividualProject.Entities;

namespace IndividualProject
{
    static class Show
    {
        public static void Lists(int answer)
        {
            using (IndividualProject_Model IP = new IndividualProject_Model())
            {
                try
                {
                    switch (answer)
                    {
                        case 1:
                            ShowCourses(IP);
                            break;
                        case 2:
                            ShowStudents(IP);
                            break;
                        case 3:
                            ShowTrainers(IP);
                            break;
                        case 4:
                            ShowAssignments(IP);
                            break;
                        case 5:
                            ShowStudentsPerCourse(IP);
                            break;
                        case 6:
                            ShowTrainersPerCourse(IP);
                            break;
                        case 7:
                            ShowAssignmentsPerCourse(IP);
                            break;
                        case 8:
                            ShowAssignmentsPerStudentPerCourse(IP);
                            break;
                        case 9:
                            ShowStudentsWithMoreThanOneCourses(IP);
                            break;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }
        public static void ShowCourses(IndividualProject_Model IP)
        {
            Console.WriteLine("| |Title|Stream|Type|Start Date|End Date|\n");
            foreach (Courses c in IP.Courses.ToList())
                Console.WriteLine($"|{c.courseID}|{c.title}|{c.stream}|{c.type}|{c.start_date}|{c.end_date}|");
        }
        public static void ShowStudents(IndividualProject_Model IP)
        {
            Console.WriteLine("| |First Name|Last Name|Date of Birth|Tuition Fees|\n");
            foreach (Students s in IP.Students.ToList())
                Console.WriteLine($"|{s.studentID}|{s.firstName}|{s.lastName}|{s.dateOfBirth}|{s.tuitionFees}|");
        }
        public static void ShowTrainers(IndividualProject_Model IP)
        {
            Console.WriteLine("| |First Name|Last Name|Subject|\n");
            foreach (Trainers t in IP.Trainers.ToList())
                Console.WriteLine($"|{t.trainerID}|{t.firstName}|{t.lastName}|{t.subject}|");
        }
        public static void ShowAssignments(IndividualProject_Model IP)
        {
            Console.WriteLine("| |Title|Description|Sub Date|Oral Mark(/100)|Total Mark(/100)|\n");
            foreach (Assignments a in IP.Assignments.ToList())
                Console.WriteLine($"|{a.assignmentID}|{a.title}|{a.description}|{a.subDateTime}|{a.oralMark}|{a.totalMark}|");
        }
        public static void ShowStudentsPerCourse(IndividualProject_Model IP)
        {
            var courseList = IP.Courses.ToList();
            var studentList = IP.Students.ToList();
            var studentCourseList = IP.StudentsPerCourse.ToList();
            var studentsPerCourseList = (courseList
                .Join(studentCourseList, c => c.courseID, s => s.course_ID, (c, s) => new { c, s })
                .Join(studentList, cs => cs.s.student_ID, s => s.studentID, (cs, s) => new { cs, s }))
                .OrderBy(x=>x.cs.c.title);
            Console.WriteLine("|Title|Stream|Type|Start Date|End Date|First Name|Last Name|Date of Birth|Tuition Fees|\n");
            foreach (var item in studentsPerCourseList)
                Console.WriteLine($"|{item.cs.c.title}|{item.cs.c.stream}|{item.cs.c.type}|{item.cs.c.start_date}|{item.cs.c.end_date}|{item.s.firstName}|{item.s.lastName}|{item.s.dateOfBirth}|{item.s.tuitionFees}|");
        }
        public static void ShowTrainersPerCourse(IndividualProject_Model IP)
        {
            var courseList = IP.Courses.ToList();
            var trainerList = IP.Trainers.ToList();
            var trainerCourseList = IP.TrainersPerCourse.ToList();
            var trainersPerCourseList = courseList
                .Join(trainerCourseList, c => c.courseID, t => t.course_ID, (c, t) => new { c, t })
                .Join(trainerList, ct => ct.t.trainer_ID, t => t.trainerID, (ct, t) => new { ct, t })
                .OrderBy(x=>x.ct.c.title);
            Console.WriteLine("|Title|Stream|Type|Start Date|End Date|First Name|Last Name|Subject|\n");
            foreach (var item in trainersPerCourseList)
                Console.WriteLine($"|{item.ct.c.title}|{item.ct.c.stream}|{item.ct.c.type}|{item.ct.c.start_date}|{item.ct.c.end_date}|{item.t.firstName}|{item.t.lastName}|{item.t.subject}|");
        }
        public static void ShowAssignmentsPerCourse(IndividualProject_Model IP)
        {
            var courseList = IP.Courses.ToList();
            var assignmentList = IP.Assignments.ToList();
            var assignmentCourseList = IP.AssignmentsPerCourse.ToList();
            var assignmentsPerCourseList = courseList
                .Join(assignmentCourseList, c => c.courseID, a => a.course_ID, (c, a) => new { c, a })
                .Join(assignmentList, ca => ca.a.assignment_ID, a => a.assignmentID, (ca, a) => new { ca, a })
                .OrderBy(x=>x.ca.c.title);
            Console.WriteLine("|Title|Stream|Type|Start Date|End Date|Title|Description|Sub Date|Oral Mark|Total Mark|\n");
            foreach (var item in assignmentsPerCourseList)
                Console.WriteLine($"|{item.ca.c.title}|{item.ca.c.stream}|{item.ca.c.type}|{item.ca.c.start_date}|{item.ca.c.end_date}|{item.a.title}|{item.a.description}|{item.a.subDateTime}|{item.a.oralMark}|{item.a.totalMark}|");
        }
        static void ShowAssignmentsPerStudentPerCourse(IndividualProject_Model IP)
        {
            var studentList = IP.Students.ToList();
            var assignmentList = IP.Assignments.ToList();
            var studentCourseList = IP.StudentsPerCourse.ToList();
            var assignmentCourseList = IP.AssignmentsPerCourse.ToList();
            var AssignmentsPerStudentPerCourseList = studentList
                .Join(studentCourseList, s => s.studentID, c => c.student_ID, (s, c) => new { s, c })
                .Join(assignmentCourseList, sc => sc.c.course_ID, a => a.course_ID, (sc, a) => new { sc, a })
                .Join(assignmentList, sca => sca.a.assignment_ID, a => a.assignmentID, (sca, a) => new { sca, a })
                .OrderBy(x => x.sca.sc.s.studentID);
            Console.WriteLine("|First Name|Last Name|Date of Birth|Tuition Fees|Title|Description|Sub Date|Oral Mark|Total Mark|\n");
            foreach (var item in AssignmentsPerStudentPerCourseList)
                Console.WriteLine($"|{item.sca.sc.s.firstName}|{item.sca.sc.s.lastName}|{item.sca.sc.s.dateOfBirth}|{item.sca.sc.s.tuitionFees}|{item.a.title}|{item.a.description}|{item.a.subDateTime}|{item.a.oralMark}|{item.a.totalMark}|");
        }
        static void ShowStudentsWithMoreThanOneCourses(IndividualProject_Model IP)
        {
            var courseList = IP.Courses.ToList();
            var studentList = IP.Students.ToList();
            var studentCourseList = IP.StudentsPerCourse.ToList();
            var studentsWithMoreCoursesList = courseList
                .Join(studentCourseList, c => c.courseID, s => s.course_ID, (c, s) => new { c, s })
                .Join(studentList, cs => cs.s.student_ID, s => s.studentID, (cs, s) => new { cs, s })
                .GroupBy(a => new { a.s.firstName, a.s.lastName, a.s.dateOfBirth, a.s.tuitionFees })
                .Where(a => a.Count() > 1);
            Console.WriteLine("|First Name|Last Name|Date of Birth|Tuition Fees|\n");
            foreach (var s in studentsWithMoreCoursesList)
                Console.WriteLine($"|{s.Key.firstName}|{s.Key.lastName}|{s.Key.dateOfBirth}|{s.Key.tuitionFees}|");
        }
    }
}
