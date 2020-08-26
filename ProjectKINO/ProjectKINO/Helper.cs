using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace ProjectKINO
{
    static class Helper
    {
        public static int ChooseNumber(int a, int b)
        {
            int answer;
            do
            {
                Console.WriteLine($"Please choose a number from {a} to {b}:");
            } while (!int.TryParse(Console.ReadLine(), out answer) || answer < a || answer > b);
            return answer;
        }

        public static string OddEvenDraw(string str)
        {
            string answer;
            do
            {
                Console.WriteLine(str);
                answer = Console.ReadLine().ToUpper();
            } while (answer != "ODD" && answer != "EVEN" && answer != "DRAW");
            return answer;
        }

        public static string YesOrNo()
        {
            string answer;
            do
            {
                Console.WriteLine("Yes/No?");
                answer = Console.ReadLine().ToUpper();
            } while (answer != "YES" && answer != "NO");
            return answer;
        }

        public static int ChooseNumberFromArray(int[] array)
        {
            int answer;
            do
            {
                Console.WriteLine("Please choose from the numbers above:");
            } while (!int.TryParse(Console.ReadLine(), out answer) || !array.Contains(answer));
            return answer;
        }
    }
}
