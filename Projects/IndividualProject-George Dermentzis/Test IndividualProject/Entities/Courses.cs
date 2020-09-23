namespace IndividualProject.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Courses
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Courses()
        {
            AssignmentsPerCourse = new HashSet<AssignmentsPerCourse>();
            StudentsPerCourse = new HashSet<StudentsPerCourse>();
            TrainersPerCourse = new HashSet<TrainersPerCourse>();
        }

        [Key]
        public int courseID { get; set; }

        [Required]
        [StringLength(40)]
        public string title { get; set; }

        [Required]
        [StringLength(40)]
        public string stream { get; set; }

        [Required]
        [StringLength(40)]
        public string type { get; set; }

        public DateTime start_date { get; set; }

        public DateTime end_date { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<AssignmentsPerCourse> AssignmentsPerCourse { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<StudentsPerCourse> StudentsPerCourse { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TrainersPerCourse> TrainersPerCourse { get; set; }
    }
}
