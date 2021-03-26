using System;
using System.ComponentModel.DataAnnotations;
using George_Dermentzis_Assignment_2.enums;
using George_Dermentzis_Assignment_2.Validations;

namespace George_Dermentzis_Assignment_2.ViewModels
{
    public class CourseViewModel
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
    }
}