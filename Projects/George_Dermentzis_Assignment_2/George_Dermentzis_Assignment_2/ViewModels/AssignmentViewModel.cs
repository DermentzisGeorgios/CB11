using System;
using System.ComponentModel.DataAnnotations;

namespace George_Dermentzis_Assignment_2.ViewModels
{
    public class AssignmentViewModel
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
    }
}