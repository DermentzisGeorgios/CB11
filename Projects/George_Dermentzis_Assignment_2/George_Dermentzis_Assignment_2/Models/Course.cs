using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using George_Dermentzis_Assignment_2.enums;
using George_Dermentzis_Assignment_2.Validations;
using George_Dermentzis_Assignment_2.ViewModels;

namespace George_Dermentzis_Assignment_2.Models
{
    public class Course
    {
        public int CourseID { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Please fill in the Title")]
        [StringLength(40)]
        public string Title { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Please fill in the Stream")]
        [StringLength(40)]
        public string Stream { get; set; }

        [EnumDataType(typeof(CourseType))]
        public CourseType? Type { get; set; }

        [Display(Name = "Start Date")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:d}")]
        public DateTime StartDate { get; set; }

        [Display(Name = "End Date")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:d}")]
        [FutureDate("StartDate")]
        public DateTime EndDate { get; set; }

        public ICollection<Student> Students { get; set; }
        public ICollection<Trainer> Trainers { get; set; }
        public ICollection<Assignment> Assignments { get; set; }

        public Course() { }

        public Course(int id)
        {
            CourseID = id;
        }

        public Course(CourseViewModel viewModel)
        {
            CourseID = viewModel.CourseID;
            Title = viewModel.Title;
            Stream = viewModel.Stream;
            Type = viewModel.Type;
            StartDate = viewModel.StartDate;
            EndDate = viewModel.EndDate;
        }
    }
}