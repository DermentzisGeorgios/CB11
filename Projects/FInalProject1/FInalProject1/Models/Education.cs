using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace FInalProject1.Models
{
    public class Education
    {
        [ForeignKey("Developer")]
        public int EducationID { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "School required")]
        [StringLength(100)]
        public string School { get; set; }
        public string Degree { get; set; }
        public string Field { get; set; }
        public double? Grade { get; set; }

        [Display(Name = "Start Year")]
        public int? StartYear { get; set; }

        [Display(Name = "End Year")]
        public int? EndYear { get; set; }


        public virtual Developer Developer { get; set; }
    }
}