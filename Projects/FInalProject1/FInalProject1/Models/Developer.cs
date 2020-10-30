using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FInalProject1.Models
{
    public class Developer
    {
        public int DeveloperID { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Email required")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [DataType(DataType.Password)]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Password must be between 6 and 40 characters")]
        [StringLength(40, MinimumLength = 6)]
        public string Password { get; set; }

        public virtual ContactInfo ContactInfo { get; set; }

        public virtual Education Education { get; set; }

        public virtual ICollection<Skill> Skills { get; set; }
    }
}