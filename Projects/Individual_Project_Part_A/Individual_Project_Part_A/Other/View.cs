using System;
using System.Collections.Generic;
using System.Linq;
using Individual_Project_Part_A.Infrastructure;
using Individual_Project_Part_A.Models;
using Individual_Project_Part_A.Validations;

namespace Individual_Project_Part_A.Other
{
    class View
    {
        public static void CheckList<T>(IList<T> list) where T : class
        {
            if (list.Count == 0)
            {
                Helper.ErrorMsg("No data available!");
                return;
            }

            foreach (var item in list)
            {
                item.GetType().GetMethod("Print").Invoke(item, null);
            }
        }

        public static void CheckDictionaryPerCourse<T>(IDictionary<int, List<T>> dictionary) where T : class
        {
            if (dictionary.Count == 0)
            {
                Helper.ErrorMsg("No data available!");
                return;
            }

            foreach (var item in dictionary)
            {
                var course = Context.Courses.SingleOrDefault(c => c.Id == item.Key);
                Console.WriteLine("\n-----------------------------------------------Course:-----------------------------------------------");
                course.Print();
                var s = item.Value.GetType().GetGenericArguments()[0].ToString();
                Console.WriteLine($"-----------------------------------------------{s.Substring(s.LastIndexOf('.') + 1)}s:---------------------------------------------");
                foreach (var value in item.Value)
                {
                    value.GetType().GetMethod("Print").Invoke(value, null);
                }
            }
        }

        //Can I merge it with the above method?
        public static void CheckAssignmentsPerStudent(IDictionary<int, List<Assignment>> dictionary)
        {
            if (dictionary.Count == 0)
            {
                Helper.ErrorMsg("No data available!");
                return;
            }

            foreach (var item in dictionary)
            {
                var student = Context.Students.SingleOrDefault(s => s.Id == item.Key);
                Console.WriteLine("\n-----------------------------------------------Student:-----------------------------------------------");
                student.Print();
                Console.WriteLine("\n-----------------------------------------------Assignments:-------------------------------------------");
                foreach (var value in item.Value)
                {
                    value.Print();
                }
            }
        }

        public static void CheckStudentsWithMoreThanOneCourse(IDictionary<int, List<Student>> dictionary)
        {
            if (dictionary.Count <= 1)
            {
                Helper.ErrorMsg("No data available!");
                return;
            }

            var studentIds = GetStudentIds(dictionary);
            foreach (var id in studentIds)
            {
                Context.Students.SingleOrDefault(s => s.Id == id).Print();
            }
        }

        private static IEnumerable<int> GetStudentIds(IDictionary<int, List<Student>> dictionary)
        {
            var studentList = new List<Student>();
            foreach (var list in dictionary.Values)
            {
                studentList.AddRange(list);
            }

            return studentList.GroupBy(s => s.Id).Where(g => g.Count() > 1).Select(d => d.Key);
        }

        public static void CheckStudentsPerDate(IDictionary<int, List<Assignment>> dictionary)
        {
            var date = Helper.ValidateDate("Please give a date to check all the students bound to submit their assignment(s) on the same week:");
            int count = 0;
            foreach (var item in dictionary)
            {
                foreach (var assignment in item.Value)
                {
                    var dateDiff = (date - assignment.SubmissionDate).Days;
                    if (0 < dateDiff && dateDiff < 7)
                    {
                        Context.Students.SingleOrDefault(s => s.Id == item.Key).Print();
                        count++;
                        break;
                    }
                }
            }

            if (count == 0) Helper.ErrorMsg("No data available!");
        }
    }
}