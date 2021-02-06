namespace IndividualProject.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Trainers
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Trainers()
        {
            TrainersPerCourse = new HashSet<TrainersPerCourse>();
        }

        [Key]
        public int trainerID { get; set; }

        [Required]
        [StringLength(40)]
        public string firstName { get; set; }

        [Required]
        [StringLength(40)]
        public string lastName { get; set; }

        [Required]
        [StringLength(40)]
        public string subject { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TrainersPerCourse> TrainersPerCourse { get; set; }
    }
}
