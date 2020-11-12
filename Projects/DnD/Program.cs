using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DnD
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> attributes = new List<string>
            {
                "strength",
                "dexterity",
                "constitution",
                "intelligence",
                "wisdom",
                "charisma"
            };
            List<int> stats = CreateStats();
            int hitpoints = Calchitpoints(stats[2], out double dmg);
            string charClass = SelectClass();
            stats = ChangeAttributes(stats, charClass);
            double xphas =0;
            double xpgain = Xp_gain();
            int lvl = Level(xphas, xpgain);
            Console.WriteLine("Class: {0}\nLvl: {1}\nHP: {2}", charClass, lvl, hitpoints);
            for (int i = 0; i < 6; i++)
                Console.WriteLine("{0}: {1}", attributes[i], stats[i]);
        }

        public static List<int> CreateStats()
        {
            List<int> stats = new List<int>();
            Random rand = new Random();
            int sum;
            int i = 0;
            while (i < 6)
            {
                sum = 0;
                for (int j = 0; j < 4; j++)
                {
                    sum += rand.Next(1, 7);
                }
                if (sum >= 14 && sum <= 20)
                {
                    stats.Add(sum);
                    i++;
                }
            }
            return stats;
        }

        public static int Calchitpoints(int cons, out double dmg)
        {
            double hitpoints = (10 - cons) / 2.0;
            hitpoints += 0.01;
            hitpoints = 10 + Math.Round(hitpoints);
            dmg = 4 * hitpoints;
            return Convert.ToInt32(hitpoints);
        }

        public static string SelectClass()
        {
            Console.WriteLine("Please select your class");
            string[] classes = new string[12] { "Barbarian", "Fighter",
                                                "Bard", "Sorcerer", "Paladin", "Warlock",
                                                "Cleric", "Druid", "Monk",
                                                "Rogue", "Ranger",
                                                "Wizard" };
            int intClass;
            bool flag = false;
            do
            {
                for (int i = 1; i <= 12; i++)
                {
                    Console.WriteLine("{0}. {1}", i, classes[i - 1]);
                }
                if (int.TryParse(Console.ReadLine(), out intClass))
                    flag = true;
            } while (!flag || intClass < 1 || intClass > 12);
            return classes[intClass - 1];
        }

        public static List<int> ChangeAttributes(List<int> stats, string charClass)
        {
            switch (charClass)
            {
                case "Barbarian":
                case "Fighter":
                    stats = ChangeStats(stats, 0);
                    break;
                case "Bard":
                case "Sorcerer":
                case "Warlock":
                    stats = ChangeStats(stats, 5);
                    break;
                case "Cleric":
                case "Druid":
                case "Monk":
                    ChangeStats(stats, 4);
                    break;
                case "Rogue":
                case "Ranger":
                    stats = ChangeStats(stats, 1);
                    break;
                case "Wizard":
                    stats = ChangeStats(stats, 3);
                    break;
                case "Paladin":
                    stats = PaladinStats(stats);
                    break;
            }
            return stats;
        }

        public static List<int> ChangeStats(List<int> stats, int p)
        {
            for (int i = 0; i < 6; i++)
            {
                if (i == p)
                    stats[i] = stats[i] * 2;
                else
                {
                    double tmp = stats[i] * 0.8;
                    tmp += 0.01;
                    stats[i] = Convert.ToInt32(Math.Round(tmp));
                }
            }
            return stats;
        }

        public static List<int> PaladinStats(List<int> stats)
        {
            for (int i = 0; i < 6; i++)
            {
                if (i == 0 || i == 5)
                    stats[i] = stats[i] * 2;
                else
                {
                    double tmp = stats[i] * 0.8;
                    tmp += 0.01;
                    stats[i] = Convert.ToInt32(Math.Round(tmp));
                }
            }
            return stats;
        }

        public static int Level(double xphas, double xpgain)
        {
            int lvl = 0;
            int diff = 0;
            if (xpgain >= 100)
            {
                do
                {
                    lvl++;
                    diff += 100;
                    xphas += diff;
                } while (xpgain >= xphas);
            }
            else
                lvl = 1;
            return lvl;
        }

        public static double Xp_gain()
        {
            double xpgain;
            do
            {
                Console.WriteLine("How many xp have you gained?");
            } while (!double.TryParse(Console.ReadLine(), out xpgain) || xpgain < 0);
            return xpgain;
        }
    }
}
