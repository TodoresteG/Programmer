namespace Programmer.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public class Lecture
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }

        [NotMapped]
        public TimeSpan TimeNeeded
            => TimeSpan.FromSeconds(Math.Round(this.Course.Users.Sum(u => u.User.Xp / u.User.Level * this.Course.BaseTimeNeeded.TotalSeconds)));

        public int XpReward { get; set; }

        public int CourseId { get; set; }

        public Course Course { get; set; }
    }
}
