using System;
using Individual_Project_Part_A.Interfaces;

namespace Individual_Project_Part_A.Models
{
    class Assignment : IModel
    {
        public int Id { get; private set; }
        public string Title { get; private set; }
        public string Description { get; private set; }
        public DateTime SubmissionDate { get; private set; }
        public int OralMark { get; private set; }
        public int TotalMark { get; private set; }


        public Assignment() { }

        public Assignment(int id, string title, string description, DateTime submissionDate, int oralMark, int totalMark)
        {
            Id = id;
            Title = title;
            Description = description;
            SubmissionDate = submissionDate;
            OralMark = oralMark;
            TotalMark = totalMark;
        }

        public void Print()
        {
            Console.WriteLine("{0, -20}{1, -20}{2, -20}{3, -20}{4, -20}{5, -20}", "Row Number:", "Title:", "Description:", "Submission Date:", "Oral Mark:", "Total Mark:", Console.ForegroundColor = ConsoleColor.Yellow);
            Console.WriteLine("{0, -20}{1, -20}{2, -20}{3, -20}{4, -20}{5, -20}", Id + ".", Title, Description, SubmissionDate.ToShortDateString(), OralMark, TotalMark, Console.ForegroundColor = ConsoleColor.Gray);
        }
    }
}