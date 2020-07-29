using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.SqlServer.Server;

namespace Exercise28._7
{
    interface IGame
    {
        string _username { get; set; }
        int _score { get; set; }
        int _gamesPlayed { get; set; }
        void PlayGame();
    }

    class Crown : IGame
    {
        public string _username { get; set; }
        public int _score { get; set; }
        public int _gamesPlayed { get; set; }

        public Crown(string username, int score, int gamesPlayed)
        {
            _username = username;
            _score = score;
            _gamesPlayed = gamesPlayed;
        }

        public void PlayGame()
        {
            int answer;
            int coinflip;
            Random rng = new Random();
            Console.WriteLine($"Welcome {_username}! You have 3 chances to flip the coin and call it right. Choose a number according to your choice");
            for (int i = 1; i <= 3; i++)
            {
                answer = ChooseNumber("Heads or Tails?\n1. Heads\n2. Tails?", 2);
                coinflip = rng.Next(1, 3);
                Console.WriteLine($"coinflip = {coinflip}");
                if (answer == coinflip)
                {
                    _score++;
                }
                _gamesPlayed = i;
            }
            if (_score >= 2)
                Console.WriteLine("Congratulations you've won!");
            else
                Console.WriteLine("Sorry you've lost!");
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
    }

    class Quiz : IGame
    {
        public string _username { get; set; }
        public int _score { get; set; }
        public int _gamesPlayed { get; set; }

        public Quiz(string username, int score)
        {
            _username = username;
            _score = score;
        }

        public void PlayGame()
        {
            int answer;
            Console.WriteLine($"Welcome {_username}! There are 3 questions. Please give the correct answer\n");
            answer = ChooseNumber("What is your name?\n1. Mixalis\n2. George\n3. Vasilis", 3);
            if (answer == 2)
                _score++;
            answer = ChooseNumber("What year were you born?\n1. 1995\n2. 1986\n3. 2001", 3);
            if (answer == 1)
                _score++;
            answer = ChooseNumber("What is your favourite type of music?\n1. Techno\n2. Rock\n3. EDM", 3);
            if (answer == 3)
                _score++;

            if (_score >= 2)
                Console.WriteLine("Congratulations you've won!");
            else
                Console.WriteLine("Sorry you've lost!");
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
    }

    class Hang : IGame
    {
        public string _username { get; set; }
        public int _score { get; set; }
        public int _gamesPlayed { get; set; }

        public Hang(string username, int gamesPlayed)
        {
            _username = username;
            _gamesPlayed = gamesPlayed;
        }

        public void PlayGame()
        {
            char answer;
            string word = "summer";
            Console.WriteLine($"Welcome {_username}! You have 6 attempts to solve the hangman");
            do
            {
                answer = FixInput("Please enter a letter:");
                if (word.Contains(answer))
                {
                    Console.WriteLine("You got it!");
                    if (answer == 'm')
                        word.Remove(word.IndexOf(answer), 2);
                    else
                        word.Remove(word.IndexOf(answer), 1);
                }
                else
                    Console.WriteLine("Sorry try again");
                _gamesPlayed++;
            } while (_gamesPlayed < 6 && word != "");
            if (word == "")
                Console.WriteLine("Congratulations you've won!");
            else
                Console.WriteLine("Sorry you've lost!");
        }

        public static char FixInput(string str)
        {
            char answer;
            do
            {
                Console.WriteLine(str);
            } while (!char.TryParse(Console.ReadLine(), out answer));
            return answer;
        }
    }
}
