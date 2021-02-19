using System;
using Individual_Project_Part_A.Interfaces;

namespace Individual_Project_Part_A.Models
{
    class Student : IModel
    {
        public int Id { get; private set; }
        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        public DateTime DateOfBirth { get; private set; }
        public double TuitionFees { get; private set; }


        public Student() { }

        public Student(int id, string firstname, string lastname, DateTime dateOfBirth, double tuitionFees)
        {
            Id = id;
            FirstName = firstname;
            LastName = lastname;
            DateOfBirth = dateOfBirth;
            TuitionFees = tuitionFees;
        }

        public void Print()
        {
            Console.WriteLine("{0, -20}{1, -20}{2, -20}{3, -20}{4, -20}", "Row Number:", "First Name:", "Last Name:", "Date of Birth:", "Tuition Fees:", Console.ForegroundColor = ConsoleColor.Yellow);
            Console.WriteLine("{0, -20}{1, -20}{2, -20}{3, -20}{4, -20}", Id + ".", FirstName, LastName, DateOfBirth.ToShortDateString(), TuitionFees, Console.ForegroundColor = ConsoleColor.Gray);
        }
    }
}