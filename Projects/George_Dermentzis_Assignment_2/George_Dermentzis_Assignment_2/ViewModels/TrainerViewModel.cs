using System;
using System.ComponentModel.DataAnnotations;

namespace George_Dermentzis_Assignment_2.ViewModels
{
    public class TrainerViewModel
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

        [StringLength(40)]
        public string Subject { get; set; }
    }
}