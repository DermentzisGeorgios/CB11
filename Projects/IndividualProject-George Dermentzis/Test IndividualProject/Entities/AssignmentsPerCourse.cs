namespace IndividualProject.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("AssignmentsPerCourse")]
    public partial class AssignmentsPerCourse
    {
        [Key]
        public int ApC_ID { get; set; }

        public int course_ID { get; set; }

        public int assignment_ID { get; set; }

        public virtual Assignments Assignments { get; set; }

        public virtual Courses Courses { get; set; }
    }
}
