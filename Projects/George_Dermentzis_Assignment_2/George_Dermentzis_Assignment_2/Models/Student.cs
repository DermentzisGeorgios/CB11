using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using George_Dermentzis_Assignment_2.ViewModels;

namespace George_Dermentzis_Assignment_2.Models
{
    public class Student
    {
        public int StudentID { get; set; }

        [Required(AllowEmptyStrings = false)]
        [StringLength(40)]
        [RegularExpression(@"^[a-zA-Z]+$")]
        public string FirstName { get; set; }

        [Required(AllowEmptyStrings = false)]
        [StringLength(40)]
        [RegularExpression(@"^[a-zA-Z]+$")]
        public string LastName { get; set; }

        //public string FullName => $"{FirstName} {LastName}";

        [Display(Name = "Date of Birth")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:d}")]
        [DataType(DataType.Date)]
        public DateTime? DateOfBirth { get; set; }

        [Display(Name = "Tuition Fees")]
        [DataType(DataType.Currency)]
        public decimal? TuitionFees { get; set; }

        public ICollection<Course> Courses { get; set; }

        public Student() { }

        public Student(int id)
        {
            StudentID = id;
        }

        public Student(StudentViewModel viewModel)
        {
            StudentID = viewModel.StudentID;
            FirstName = viewModel.FirstName;
            LastName = viewModel.LastName;
            DateOfBirth = viewModel.DateOfBirth;
            TuitionFees = viewModel.TuitionFees;
        }
    }
}