namespace Programmer.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class Course
    {
        public Course()
        {
            this.Lectures = new HashSet<Lecture>();
        }

        [Key]
        public int Id { get; set; }

        public string Name { get; set; }

        public decimal Price { get; set; }

        public int RequiredEnergy { get; set; }

        public double HardSkillReward { get; set; }

        public double SoftSkillReward { get; set; }

        public TimeSpan BaseTimeNeeded { get; set; }

        public bool IsCompleted { get; set; }

        [NotMapped]
        public double Reward { get; set; }

        public Exam Exam { get; set; }

        public ICollection<Lecture> Lectures { get; set; }

        public string ProgrammerUserId { get; set; }

        public ProgrammerUser Player { get; set; }
    }
}
