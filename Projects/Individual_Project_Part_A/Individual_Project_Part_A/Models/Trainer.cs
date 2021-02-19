using System;
using Individual_Project_Part_A.Interfaces;

namespace Individual_Project_Part_A.Models
{
    class Trainer : IModel
    {
        public int Id { get; private set; }
        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        public string Subject { get; private set; }


        public Trainer() { }

        public Trainer(int id, string firstname, string lastname, string subject)
        {
            Id = id;
            FirstName = firstname;
            LastName = lastname;
            Subject = subject;
        }

        public void Print()
        {
            Console.WriteLine("{0, -20}{1, -20}{2, -20}{3, -20}", "Row Number:", "First Name:", "Last Name:", "Subject:", Console.ForegroundColor = ConsoleColor.Yellow);
            Console.WriteLine("{0, -20}{1, -20}{2, -20}{3, -20}", Id + ".", FirstName, LastName, Subject, Console.ForegroundColor = ConsoleColor.Gray);
        }
    }
}