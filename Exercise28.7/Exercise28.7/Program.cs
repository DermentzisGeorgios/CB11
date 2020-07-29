using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise28._7
{
    class Program
    {
        static void Main(string[] args)
        {
            IGame game;
            string username = FixInput("Please enter your username:");
            int answer = ChooseNumber("Please choose the game you want to play\n1. Crown\n2. Quiz\n3. Hang", 3);
            switch (answer)
            {
                case 1:
                    game = new Crown(username, 0, 0);
                    game.PlayGame();
                    break;
                case 2:
                    game = new Quiz(username, 0);
                    game.PlayGame();
                    break;
                default:
                    game = new Hang(username, 0);
                    game.PlayGame();
                    break;
            }
        }

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
    }
}
