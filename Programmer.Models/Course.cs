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
            this.Users = new HashSet<UserCourse>();
        }

        [Key]
        public int Id { get; set; }

        public string Name { get; set; }

        public decimal Price { get; set; }

        public int RequiredEnergy { get; set; }

        public double HardSkillReward { get; set; }

        public string HardSkillName { get; set; }

        public double SoftSkillReward { get; set; }

        public string SoftSkillName { get; set; }

        public int XpReward { get; set; }

        public Exam Exam { get; set; }

        public ICollection<Lecture> Lectures { get; set; }

        public ICollection<UserCourse> Users { get; set; }
    }
}
