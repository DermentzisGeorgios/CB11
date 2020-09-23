namespace IndividualProject.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Assignments
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Assignments()
        {
            AssignmentsPerCourse = new HashSet<AssignmentsPerCourse>();
        }

        [Key]
        public int assignmentID { get; set; }

        [Required]
        [StringLength(40)]
        public string title { get; set; }

        [StringLength(400)]
        public string description { get; set; }

        public DateTime subDateTime { get; set; }

        public int? oralMark { get; set; }

        public int? totalMark { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<AssignmentsPerCourse> AssignmentsPerCourse { get; set; }
    }
}
