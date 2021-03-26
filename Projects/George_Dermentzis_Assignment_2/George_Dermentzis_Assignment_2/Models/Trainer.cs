using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using George_Dermentzis_Assignment_2.ViewModels;

namespace George_Dermentzis_Assignment_2.Models
{
    public class Trainer
    {
        public int TrainerID { get; set; }

        [Required(AllowEmptyStrings = false)]
        [StringLength(40)]
        [RegularExpression(@"^[a-zA-Z]+$")]
        public string FirstName { get; set; }

        [Required(AllowEmptyStrings = false)]
        [StringLength(40)]
        [RegularExpression(@"^[a-zA-Z]+$")]
        public string LastName { get; set; }

        //public string FullName => $"{FirstName} {LastName}";

        [StringLength(40)]
        public string Subject { get; set; }

        public ICollection<Course> Courses { get; set; }

        public Trainer() { }

        public Trainer(int id)
        {
            TrainerID = id;
        }

        public Trainer(TrainerViewModel viewModel)
        {
            TrainerID = viewModel.TrainerID;
            FirstName = viewModel.FirstName;
            LastName = viewModel.LastName;
            Subject = viewModel.Subject;
        }
    }
}