using System;
using AutoMapper;
using George_Dermentzis_Assignment_2.Models;

namespace George_Dermentzis_Assignment_2.App_Start
{
    public class OrganizationProfile : Profile
    {
        public OrganizationProfile()
        {
            CreateMap<Course, Course>();
            CreateMap<Student, Student>();
            CreateMap<Trainer, Trainer>();
            CreateMap<Assignment, Assignment>();
        }
    }
}