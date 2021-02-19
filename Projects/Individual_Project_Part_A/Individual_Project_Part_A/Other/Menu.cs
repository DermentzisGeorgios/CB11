using System;
using Individual_Project_Part_A.Infrastructure;
using Individual_Project_Part_A.Repositories;
using Individual_Project_Part_A.SyntheticData;
using Individual_Project_Part_A.Validations;
using Unity;

namespace Individual_Project_Part_A.Other
{
    class Menu
    {
        private readonly CourseRepository courseRepository;
        private readonly StudentRepository studentRepository;
        private readonly TrainerRepository trainerRepository;
        private readonly AssignmentRepository assignmentRepository;
        private readonly ModelComparer comparer;

        [InjectionConstructor]
        public Menu(IUnityContainer container)
        {
            courseRepository = container.Resolve<CourseRepository>();
            studentRepository = container.Resolve<StudentRepository>();
            trainerRepository = container.Resolve<TrainerRepository>();
            assignmentRepository = container.Resolve<AssignmentRepository>();
            comparer = container.Resolve<ModelComparer>();
        }


        public void Welcome()
        {
            var flag = true;
            while (flag)
            {
                var request = "Please choose a number from 1 to 3:\n1. Add Data\n2. Show Data\n3. Exit";
                var answer = Helper.ValidateInt(request, 1, 3);
                switch (answer)
                {
                    case 1: AddData(); break;
                    case 2: CheckData(); break;
                    default: flag = false; break;
                }
            }
        }

        private void AddData()
        {
            var flag = true;
            while (flag)
            {
                var request = "\nWhat would you like to do?\n1. Add Course\n2. Add Student\n3. Add Trainer\n4. Add Assignment\n5. Add Students to Course\n6. Add Trainers to Course\n7. Add Assignments to Course\n8. Synthetic Data\n9. Back";
                var answer = Helper.ValidateInt(request, 1, 9);
                if (answer != 9)
                    AddDataOptions(answer);
                else
                    flag = false;             
            }
        }

        private void CheckData()
        {
            var flag = true;
            while (flag)
            {
                var request = "\nWhat would you like to check?\n1. Courses\n2. Students\n3. Trainers\n4. Assignments\n5. Students per course\n6. Trainers per course\n7. Assignments per course\n8. Assignments per student per course\n9. Students with more than one courses\n10. Students per date\n11. Back";
                var answer = Helper.ValidateInt(request, 1, 11);
                if (answer != 11)
                    CheckDataOptions(answer);
                else
                    flag = false;
            }
        }

        private void AddDataOptions(int answer)
        {
            switch (answer)
            {
                case 1: courseRepository.AddCourse(comparer); break;
                case 2: studentRepository.AddStudent(comparer); break;
                case 3: trainerRepository.AddTrainer(comparer); break;
                case 4: assignmentRepository.AddAssignment(comparer); break;
                case 5: studentRepository.AddStudentsPerCourse(courseRepository, comparer); break;
                case 6: trainerRepository.AddTrainersPerCourse(courseRepository, comparer); break;
                case 7: assignmentRepository.AddAssignmentsPerCourse(courseRepository, comparer); break;
                case 8: MockData.Create(); break;
            }
        }

        private void CheckDataOptions(int answer)
        {
            switch (answer)
            {
                case 1: View.CheckList(Context.Courses); break;
                case 2: View.CheckList(Context.Students); break;
                case 3: View.CheckList(Context.Trainers); break;
                case 4: View.CheckList(Context.Assignments); break;
                case 5: View.CheckDictionaryPerCourse(Context.StudentsPerCourse); break;
                case 6: View.CheckDictionaryPerCourse(Context.TrainersPerCourse); break;
                case 7: View.CheckDictionaryPerCourse(Context.AssignmentsPerCourse); break;
                case 8: View.CheckAssignmentsPerStudent(Context.AssignmentsPerStudent); break;
                case 9: View.CheckStudentsWithMoreThanOneCourse(Context.StudentsPerCourse); break;
                case 10: View.CheckStudentsPerDate(Context.AssignmentsPerStudent); break;
            }
        }
    }
}