namespace IndividualProject.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Students
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Students()
        {
            StudentsPerCourse = new HashSet<StudentsPerCourse>();
        }

        [Key]
        public int studentID { get; set; }

        [Required]
        [StringLength(40)]
        public string firstName { get; set; }

        [Required]
        [StringLength(40)]
        public string lastName { get; set; }

        public DateTime dateOfBirth { get; set; }

        public decimal? tuitionFees { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<StudentsPerCourse> StudentsPerCourse { get; set; }
    }
}
