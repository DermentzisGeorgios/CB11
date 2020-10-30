using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace FInalProject1.Models
{
    public class ContactInfo
    {
        [ForeignKey("Developer")]
        public int ContactInfoID { get; set; }

        [Display(Name = "Firstname")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Firstname required")]
        [StringLength(40)]
        public string FirstName { get; set; }

        [Display(Name = "Lastname")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Lastname required")]
        [StringLength(40)]
        public string LastName { get; set; }

        [Display(Name = "Date of Birth")]
        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:d}")]
        public DateTime? DateOfBirth { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "City required")]
        [StringLength(40)]
        public string City { get; set; }

        [DataType(DataType.PostalCode)]
        public int? PostalCode { get; set; }

        [DataType(DataType.PhoneNumber)]
        [StringLength(10, MinimumLength = 10)]
        public string Phone { get; set; }

        public string FullName => FirstName + " " + LastName;


        public virtual Developer Developer { get; set; }
    }
}