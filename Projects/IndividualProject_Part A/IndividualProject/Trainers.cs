using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IndividualProject
{
    class Trainers
    {
        string firstName { get;}
        string lastName { get; }
        string subject { get;}
        readonly int ID;

        public Trainers(string firstName, string lastName, string subject, int ID)
        {
            this.firstName = firstName;
            this.lastName = lastName;
            this.subject = subject;
            this.ID = ID;
        }

        public void ShowTrainers()
        {
            Console.WriteLine($"{ID}. {lastName} {firstName}, works on {subject}.");
        }

        public bool NotEquals(Trainers trainer1, Trainers trainer2)
        {
            bool notEquals;
            if (trainer1.firstName != trainer2.firstName || trainer1.lastName != trainer2.lastName || trainer1.subject != trainer2.subject)
                notEquals = true;
            else
                notEquals = false;
            return notEquals;
        }
    }

    class TrainersPerCourse
    {
        Courses _course { get;}
        List<Trainers> _trainersPerCourseList { get;}

        public TrainersPerCourse(Courses course, List<Trainers> trainersPerCourseList)
        {
            _course = course;
            _trainersPerCourseList = trainersPerCourseList;
        }

        public void ShowTrainersPerCourse()
        {
            try
            {
                Console.WriteLine("\nCourse:");
                _course.ShowCourses();
                Console.WriteLine("\nTrainers:");
                foreach (Trainers obj in _trainersPerCourseList)
                {
                    obj.ShowTrainers();
                }
                Console.WriteLine();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
