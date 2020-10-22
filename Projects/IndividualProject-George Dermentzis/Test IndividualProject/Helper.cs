using System;
using System.Reflection;
using IndividualProject.Entities;

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
                Console.WriteLine(str);
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
                Console.WriteLine(str);
                input = Console.ReadLine();
            } while (!int.TryParse(input, out answer) || answer < 0);
            return answer;
        }
        public static decimal FixDecimal(string str)
        {
            decimal answer;
            string input;
            do
            {
                Console.WriteLine(str);
                input = Console.ReadLine();
            } while (!decimal.TryParse(input, out answer) || answer < 0);
            return answer;
        }
        public static DateTime FixDate(string str)
        {
            DateTime answer;
            string input;
            do
            {
                Console.WriteLine(str);
                input = Console.ReadLine();
            } while (!DateTime.TryParse(input, out answer));
            return answer;
        }
        public static bool NotEquals<T>(T obj1, T obj2) where T : class
        {
            bool notEquals = false;
            object prop1;
            object prop2;
            Type type = typeof(T);
            if (type == typeof(Courses))
            {
                foreach (PropertyInfo property in type.GetProperties())
                {
                    if (property.Name == "title" || property.Name == "stream" || property.Name == "type" || property.Name == "start_date" || property.Name == "end_date") //compare relevant properties
                    {
                        prop1 = type.GetProperty(property.Name).GetValue(obj1);
                        prop2 = type.GetProperty(property.Name).GetValue(obj2);
                        if (property.Name == "start_date" || property.Name == "end_date") //does not work properly, needs casting
                        {
                            if ((DateTime)prop1 != (DateTime)prop2)
                                notEquals = true;
                        }
                        else
                        {
                            if (prop1 != prop2)
                                notEquals = true;
                        }
                    }
                }
            }
            else if (type == typeof(Students))
            {
                foreach (PropertyInfo property in type.GetProperties())
                {
                    if (property.Name == "firstName" || property.Name == "lastName" || property.Name == "dateOfBirth" || property.Name == "tuitionFees")
                    {
                        prop1 = type.GetProperty(property.Name).GetValue(obj1);
                        prop2 = type.GetProperty(property.Name).GetValue(obj2);
                        if (property.Name == "dateOfBirth")
                        {
                            if ((DateTime)prop1 != (DateTime)prop2)
                                notEquals = true;
                        }
                        else if (property.Name == "tuitionFees") //must check every differnt variable type in a separate if for the casting to work
                        {
                            if ((decimal)prop1 != (decimal)prop2)
                                notEquals = true;
                        }
                        else
                        {
                            if (prop1 != prop2)
                                notEquals = true;
                        }
                    }
                }
            }
            else if (type == typeof(Trainers))
            {
                foreach (PropertyInfo property in type.GetProperties())
                {
                    if (property.Name == "firstName" || property.Name == "lastName" || property.Name == "subject")
                    {
                        prop1 = type.GetProperty(property.Name).GetValue(obj1;
                        prop2 = type.GetProperty(property.Name).GetValue(obj2);
                        if (prop1 != prop2)
                            notEquals = true;
                    }
                }
            }
            else if (type == typeof(Assignments))
            {
                foreach (PropertyInfo property in type.GetProperties())
                {
                    if (property.Name == "title" || property.Name == "description" || property.Name == "subDateTime" || property.Name == "oralMark" || property.Name == "totalMark")
                    {
                        prop1 = type.GetProperty(property.Name).GetValue(obj1;
                        prop2 = type.GetProperty(property.Name).GetValue(obj2);
                        if (property.Name == "subDateTime")
                        {
                            if ((DateTime)prop1 != (DateTime)prop2)
                                notEquals = true;
                        }
                        else if (property.Name == "oralMark" || property.Name == "totalMark")
                        {
                            if ((int)prop1 != (int)prop2)
                                notEquals = true;
                        }
                        else
                        {
                            if (prop1 != prop2)
                                notEquals = true;
                        }
                    }
                }
            }
            return notEquals;
        }
    }
}
