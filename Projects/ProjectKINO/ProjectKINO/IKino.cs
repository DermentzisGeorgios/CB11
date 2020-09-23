using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectKINO
{
    interface IKino
    {
        int moneyBet { get; set; }
        int numberofDraws { get; set; }
        int totalEarnings { get; set; }

        void ShowDrawNumbers();
        void calcEarning();
        void runDraw();
    }

    class Kino : IKino
    {
        public int moneyBet { get; set; }
        public int numberofDraws { get; set; }
        public int totalEarnings { get; set; }

        public Kino(int Bet, int Draws, int Earnings)
        {
            moneyBet = Bet;
            numberofDraws = Draws;
            totalEarnings = Earnings;
        }

        public void calcEarning() {}

        public void calcEarning(string answer)
        {
            switch (answer)
            {
                case "DRAW":
                    totalEarnings += 4 * moneyBet;
                    break;
                default:
                    totalEarnings += 2 * moneyBet;
                    break;
            }
        }

        public void runDraw() {}
        
        public void runDraw(out int odd_Count, out int even_Count)
        {
            odd_Count = 0;
            even_Count = 0;
            int[] numbersDrawn = new int[20];
            int r;
            Random random = new Random();
            for (int i = 0; i < 20; i++)
            {
                do
                {
                    r = random.Next(1, 81);
                } while (numbersDrawn.Contains(r)); //no duplicates
                numbersDrawn[i] = r;
                if (numbersDrawn[i] % 2 != 0)
                    odd_Count++;
                else
                    even_Count++;
            }
            Array.Sort(numbersDrawn);
            for (int i = 0; i < 20; i++)
                ShowDrawNumbers(numbersDrawn[i]);
            Console.WriteLine($"\nOdd: {odd_Count}\nEven: {even_Count}");
        }

        public void ShowDrawNumbers() {}

        public void ShowDrawNumbers(int n)
        {
            Console.Write($"{n} ");
        }

        string Result(int odd_Count, int even_Count)
        {
            if (odd_Count > even_Count)
                return "ODD";
            else if (odd_Count < even_Count)
                return "EVEN";
            else
                return "DRAW";
        }

        void Choose(string str, int[] array, string answer)
        {
            Console.WriteLine(str);
            for (int i = 1; i <= array.Length; i++)
                ShowDrawNumbers(array[i - 1]);
            Console.WriteLine();
            if (array.Contains(1)) //To calculate the right properties according to the given array
                moneyBet = Helper.ChooseNumberFromArray(array);
            else
            {
                answer = Helper.YesOrNo();
                if (answer == "YES")
                    numberofDraws = Helper.ChooseNumberFromArray(array);
            }
        }

        public void Run()
        {
            string answer = "";
            int odd_Count;
            int even_Count;
            int[] bets = { 1, 2, 3, 5, 10, 15, 20, 30, 50, 100 };
            int[] draws = { 2, 3, 4, 5, 6, 10, 20, 50, 100, 200 };
            Console.WriteLine("Welcome!\nIn this game you can bet if most of the KINO lottery numbers will be Odd, Even or if there will be a Draw.\n");
            Choose("How much money per draw do you want to bet?", bets, answer);
            Choose("Do you want to bet on more than one draw?", draws, answer);
            for (int i = 1; i <= numberofDraws; i++)
            {
                answer = Helper.OddEvenDraw("A new draw is about to begin! Please place your bet:\nOdd  Even  Draw");
                runDraw(out odd_Count, out even_Count);
                if (answer == Result(odd_Count, even_Count))
                {
                    calcEarning(answer);
                    Console.WriteLine("Congratulations you won!\n");
                }
                else
                    Console.WriteLine("Sorry you did not win!\n");
            }
            Console.OutputEncoding = Encoding.UTF8;
            Console.WriteLine($"The total sum you've earned is {totalEarnings}€!");
            Console.ReadKey();
        }
    }
}
