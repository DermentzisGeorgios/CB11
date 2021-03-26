using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using George_Dermentzis_Assignment_2.ViewModels;

namespace George_Dermentzis_Assignment_2.Models
{
    public class Assignment
    {
        public int AssignmentID { get; set; }

        [Required(AllowEmptyStrings = false)]
        [StringLength(40)]
        public string Title { get; set; }

        public string Description { get; set; }

        [Display(Name = "Submission Date")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:d}")]
        [DataType(DataType.Date)]
        public DateTime SubmissionDate { get; set; }

        [Display(Name = "Oral Mark")]
        [Range(0, 100)]
        public int? OralMark { get; set; }

        [Display(Name = "Total Mark")]
        [Range(0, 100)]
        public int? TotalMark { get; set; }

        public ICollection<Course> Courses { get; set; }

        public Assignment() { }

        public Assignment(int id)
        {
            AssignmentID = id;
        }

        public Assignment(AssignmentViewModel viewModel)
        {
            AssignmentID = viewModel.AssignmentID;
            Title = viewModel.Title;
            Description = viewModel.Description;
            SubmissionDate = viewModel.SubmissionDate;
            OralMark = viewModel.OralMark;
            TotalMark = viewModel.TotalMark;
        }
    }
}