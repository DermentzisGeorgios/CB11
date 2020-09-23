namespace IndividualProject.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("TrainersPerCourse")]
    public partial class TrainersPerCourse
    {
        [Key]
        public int TpC_ID { get; set; }

        public int course_ID { get; set; }

        public int trainer_ID { get; set; }

        public virtual Courses Courses { get; set; }

        public virtual Trainers Trainers { get; set; }
    }
}
