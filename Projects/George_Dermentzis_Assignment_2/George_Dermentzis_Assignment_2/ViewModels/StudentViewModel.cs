using System;
using System.ComponentModel.DataAnnotations;

namespace George_Dermentzis_Assignment_2.ViewModels
{
    public class StudentViewModel
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

        [Display(Name = "Date of Birth")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:d}")]
        [DataType(DataType.Date)]
        public DateTime? DateOfBirth { get; set; }

        [Display(Name = "Tuition Fees")]
        [DataType(DataType.Currency)]
        public decimal? TuitionFees { get; set; }
    }
}