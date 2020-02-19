namespace Programmer.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class Lecture
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }

        [NotMapped]
        public TimeSpan TimeNeeded
            => TimeSpan.FromSeconds(Math.Round(this.Course.Player.Xp / this.Course.Player.Level * this.Course.BaseTimeNeeded.TotalSeconds));

        public int XpReward { get; set; }

        public int CourseId { get; set; }

        public Course Course { get; set; }
    }
}
