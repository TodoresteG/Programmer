namespace Programmer.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations.Schema;
    using Microsoft.AspNetCore.Identity;

    public class ProgrammerUser : IdentityUser<string>
    {
        private const long XpForSecondLevel = 50;
        private const int MultiplierForXpForNextLevel = 2;

        public ProgrammerUser()
        {
            this.Id = Guid.NewGuid().ToString();
            this.Courses = new HashSet<UserCourse>();
            this.Events = new HashSet<Event>();
            this.Documentations = new HashSet<Documentation>();
            this.JobTasks = new HashSet<JobTask>();
        }

        public long Xp { get; set; }

        public int Level { get; set; }

        public int Energy { get; set; }

        public decimal Money { get; set; }

        public int Bitcoins { get; set; }

        public bool IsActive { get; set; }

        [NotMapped]
        public long XpForNextLevel => this.Level == 1 ? XpForSecondLevel : this.Xp * MultiplierForXpForNextLevel;

        public TimeSpan? TaskTimeRemaining { get; set; }

        public double Teamwork { get; set; }

        public double ProblemSolving { get; set; }

        public double Creativity { get; set; }

        public double Curiosity { get; set; }

        public double AbstractThinking { get; set; }

        public double Coding { get; set; }

        public double? DataStructures { get; set; }

        public double? Algorithms { get; set; }

        public double CSharp { get; set; }

        public double? AspNetCore { get; set; }

        public double? EfCore { get; set; }

        public double? Testing { get; set; }

        public double? DatabasesAndSQL { get; set; }

        public double? VanillaJavaScript { get; set; }

        public double? React { get; set; }

        public double? NodeJs { get; set; }

        public double? Html { get; set; }

        public double? Css { get; set; }

        public ICollection<UserCourse> Courses { get; set; }

        public ICollection<Event> Events { get; set; }

        public ICollection<Documentation> Documentations { get; set; }

        public ICollection<JobTask> JobTasks { get; set; }

        public ICollection<ProgrammerRole> Roles { get; set; }
    }
}
