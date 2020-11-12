using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project1
{
    class Program
    {
        static void Main(string[] args)
        {
            string output;
            string FavColor;
            Console.WriteLine("What is your name?");
            string Name = Console.ReadLine();
            Console.WriteLine("What year you where born?");
            int BirthYear;
            while (int.TryParse(Console.ReadLine(), out BirthYear) == false || BirthYear < 1900)
            {
                Console.WriteLine("That's not a valid year. Please try again.");
                Console.WriteLine("What year you where born?");
            }
            int Age = DateTime.Now.Year - BirthYear;
            Console.WriteLine("What is the name of the city you where born?");
            string BirthCity = Console.ReadLine();
            Console.WriteLine("Are you married?");
            string married = Console.ReadLine().ToLower();
            if (married == "yes")
            {
                Console.WriteLine("How many years have you been married?");
                int YearsMarried;
                while (int.TryParse(Console.ReadLine(), out YearsMarried) == false || YearsMarried < 0 || YearsMarried >= Age)
                {
                    Console.WriteLine("That's not a valid year. Please try again.");
                    Console.WriteLine("How many years have you been married?");
                }
                int YearOfMarriage = DateTime.Now.Year - YearsMarried;
                Console.WriteLine("Do you have any children?");
                string children = Console.ReadLine().ToLower();
                if (children == "yes")
                {
                    Console.WriteLine("How many children do you have?");
                    int ChildrenNumber;
                    while (int.TryParse(Console.ReadLine(), out ChildrenNumber) == false || ChildrenNumber <= 0)
                    {
                        Console.WriteLine("That's not a valid number. Please try again.");
                        Console.WriteLine("How many children do you have?");
                    }
                    string[] ChildName = new string[ChildrenNumber];
                    int[] ChildAge = new int[ChildrenNumber];
                    output = "Dear " + Name + ", you were born in " + BirthYear + " so you are " + Age + " and born in the city of " + BirthCity + ".\nYou have been married for " + YearsMarried + " and you got married in " + YearOfMarriage + " and you have " + ChildrenNumber + " children.\n";
                    for (int i = 0; i < ChildrenNumber; i++)
                    {
                        Console.WriteLine("What is the name of your {0} child?", i + 1);
                        ChildName[i] = Console.ReadLine();
                        Console.WriteLine("What is the age of your {0} child?", i + 1);
                        while (int.TryParse(Console.ReadLine(), out ChildAge[i]) == false || ChildAge[i] < 0 || ChildAge[i] >= Age)
                        {
                            Console.WriteLine("That's not a valid age. Please try again.");
                            Console.WriteLine("What is the age of your {0} child?", i + 1);
                        }
                        output = output + "The name of your " + (i+1) + " child is " + ChildName[i] + " and was born in the year of " + ChildAge[i] + ".\n";
                    }
                    output = output + "Your favourite color is ";
                }
                else
                    output = "Dear " + Name + ", you were born in " + BirthYear + " so you are " + Age + " and born in the city of " + BirthCity + ".\nYou have been married for " + YearsMarried + " and you got married in " + YearOfMarriage + " and you don't have any children.\nYour favourite color is ";
            }
            else
                output = "Dear " + Name + ", you were born in " + BirthYear + " so you are " + Age + " and born in the city of " + BirthCity + ".\nYou are not married and your favourite color is ";
            Console.WriteLine("What is your favourite color?");
            FavColor = Console.ReadLine();
            Console.WriteLine(output + FavColor + ".");
        }
    }
}
