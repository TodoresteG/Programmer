namespace Programmer.Models
{
    using Programmer.Data.Common.Models;

    using System.Collections.Generic;

    public class Course : BaseDeletableModel<int>
    {
        public Course()
        {
            this.Lectures = new HashSet<Lecture>();
            this.Users = new HashSet<UserCourse>();
        }

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
