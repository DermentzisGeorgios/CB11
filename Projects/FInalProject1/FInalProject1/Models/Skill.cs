using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FInalProject1.Models
{
    public class Skill
    {
        public int ID { get; set; }

        [StringLength(40)]
        public string Name { get; set; }

        public virtual ICollection<Developer> Developers { get; set; }
    }
}