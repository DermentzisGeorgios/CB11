namespace IndividualProject.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("StudentsPerCourse")]
    public partial class StudentsPerCourse
    {
        [Key]
        public int SpC_ID { get; set; }

        public int course_ID { get; set; }

        public int student_ID { get; set; }

        public virtual Courses Courses { get; set; }

        public virtual Students Students { get; set; }
    }
}
