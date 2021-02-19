using System;
using Individual_Project_Part_A.Interfaces;

namespace Individual_Project_Part_A.Models
{
    class Course : IModel
    {
        public int Id { get; private set; }
        public string Title { get; private set; }
        public string Stream { get; private set; }
        public string Type { get; private set; }
        public DateTime StartDate { get; private set; }
        public DateTime EndDate { get; private set; }


        public Course() { }

        public Course(int id, string title, string stream, string type, DateTime startDate, DateTime endDate)
        {
            Id = id;
            Title = title;
            Stream = stream;
            Type = type;
            StartDate = startDate;
            EndDate = endDate;
        }

        public void Print()
        {
            Console.WriteLine("{0, -20}{1, -20}{2, -20}{3, -20}{4, -20}{5, -20}", "Row Number:", "Title:", "Stream:", "Type:", "Start Date:", "End Date:", Console.ForegroundColor = ConsoleColor.Yellow);
            Console.WriteLine("{0, -20}{1, -20}{2, -20}{3, -20}{4, -20}{5, -20}", Id + ".", Title, Stream, Type, StartDate.ToShortDateString(), EndDate.ToShortDateString(), Console.ForegroundColor = ConsoleColor.Gray);
        }
    }
}