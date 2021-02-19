using System;
using System.Globalization;
using System.Text.RegularExpressions;

namespace Individual_Project_Part_A.Validations
{
    static class Helper
    {
        public static string ValidateString(string request, bool isName = false)
        {
            string answer;
            bool notValid;
            string message = "That's not a valid input!";
            do
            {
                Console.WriteLine(request);
                answer = Console.ReadLine();
                notValid = string.IsNullOrWhiteSpace(answer);
                if (isName)
                {
                    notValid = !Regex.IsMatch(answer, @"^[A-Za-z']+$");
                    message = "Only letters and the character ' are accepted!";
                }

                if (notValid) ErrorMsg(message);

            } while (notValid);

            return answer;
        }

        public static int ValidateInt(string request, int? min = null, int? max = null)
        {
            int answer;
            bool notValid;
            do
            {
                Console.WriteLine(request);
                notValid = !int.TryParse(Console.ReadLine(), out answer) || OutOfBounds(answer, min, max);
                if (notValid) ErrorMsg("That's not a valid input!");

            } while (notValid);

            return answer;
        }

        public static double ValidateDouble(string request, int? min = null, int? max = null)
        {
            double answer;
            bool notValid;
            do
            {
                Console.WriteLine(request);
                notValid = !double.TryParse(Console.ReadLine(), out answer) || OutOfBounds(answer, min, max);
                if (notValid) ErrorMsg("That's not a valid input!");

            } while (notValid);

            return answer;
        }

        public static DateTime ValidateDate(string request)
        {
            DateTime answer;
            bool notValid;
            do
            {
                Console.WriteLine(request);
                notValid = !DateTime.TryParse(Console.ReadLine(), CultureInfo.GetCultureInfo("el-GR"), DateTimeStyles.None, out answer);
                if (notValid) ErrorMsg("That's not a valid input!");

            } while (notValid);

            return answer;
        }

        private static bool OutOfBounds(double n, int? min, int? max)
        {
            if (!min.HasValue && !max.HasValue) return false;
            if (!min.HasValue) return n > max;
            if (!max.HasValue) return n < min;
            return n < min || n > max;
        }

        public static void ErrorMsg(string message)
        {
            Console.Write($"{message} ", Console.ForegroundColor = ConsoleColor.Red);
            Console.WriteLine("Please try again!", Console.ForegroundColor = ConsoleColor.Gray);
        }
    }
}