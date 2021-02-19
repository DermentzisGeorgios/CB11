using System;
using System.Collections.Generic;
using System.Linq;
using Individual_Project_Part_A.Infrastructure;
using Individual_Project_Part_A.Interfaces;
using Individual_Project_Part_A.Models;
using Individual_Project_Part_A.Validations;

namespace Individual_Project_Part_A.Repositories
{
    class TrainerRepository
    {
        public void AddTrainer(IEqualityComparer<IModel> comparer)
        {
            var trainer = GetTrainer();
            while (Context.Trainers.Contains(trainer, comparer))
            {
                Helper.ErrorMsg($"That trainer already exists!");
                trainer = GetTrainer();
            }

            Context.Trainers.Add(trainer);
        }

        private Trainer GetTrainer()
        {
            return new Trainer
            (
                Context.Trainers.Count + 1,
                Helper.ValidateString("First Name:", true),
                Helper.ValidateString("Last Name:", true),
                Helper.ValidateString("Subject:")
            );
        }

        public void AddTrainersPerCourse(CourseRepository courseRepository, IEqualityComparer<IModel> comparer)
        {
            var courseId = courseRepository.GetCourseId();
            if (courseId == 0) return;

            var trainerPicked = GetTrainerById();
            if (trainerPicked == null) return;

            AddTrainerPerCourse(courseId, trainerPicked, comparer);
        }

        private Trainer GetTrainerById()
        {
            foreach (var trainer in Context.Trainers)
            {
                trainer.Print();
            }
            var trainerId = Helper.ValidateInt($"\nPlease choose a trainer from 1 - {Context.Trainers.Count}, or 0 if you want to exit", 0, Context.Trainers.Count);
            if (trainerId == 0) return null;

            return Context.Trainers.SingleOrDefault(t => t.Id == trainerId);
        }

        private void AddTrainerPerCourse(int courseId, Trainer trainer, IEqualityComparer<IModel> comparer)
        {
            if (Context.TrainersPerCourse.ContainsKey(courseId))
            {
                if (Context.TrainersPerCourse[courseId].Contains(trainer, comparer))
                {
                    Helper.ErrorMsg("You have already assigned this trainer to the current course!");
                    AddTrainerPerCourse(courseId, GetTrainerById(), comparer);
                }
                else
                    Context.TrainersPerCourse[courseId].Add(trainer);
            }
            else
                Context.TrainersPerCourse.Add(courseId, new List<Trainer> { trainer });
        }
    }
}