using System;
using Individual_Project_Part_A.Other;
using Individual_Project_Part_A.Repositories;
using Individual_Project_Part_A.Validations;
using Unity;
using Unity.Injection;

namespace Individual_Project_Part_A
{
    class Program
    {
        static void Main()
        {
            var container = RegisterContainers();
            container.Resolve<Menu>().Welcome();
        }
        
        static IUnityContainer RegisterContainers()
        {
            var container = new UnityContainer();
            container.RegisterSingleton<Menu>(new InjectionConstructor(container));
            container.RegisterType<CourseRepository>();
            container.RegisterType<StudentRepository>();
            container.RegisterType<TrainerRepository>();
            container.RegisterType<AssignmentRepository>();
            container.RegisterType<ModelComparer>();

            return container;
        }
    }
}