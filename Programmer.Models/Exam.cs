namespace Programmer.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public class Exam
    {
        [Key]
        public int Id { get; set; }

        public int RequiredEnergy { get; set; }

        public double RequiredHardSkill { get; set; }

        public double RequiredCodingSkill { get; set; }

        public int CourseId { get; set; }

        public Course Course { get; set; }
    }
}
