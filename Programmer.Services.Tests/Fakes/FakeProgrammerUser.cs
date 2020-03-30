using System;
using System.Collections.Generic;
using System.Text;

namespace Programmer.Services.Tests.Fakes
{
    public class FakeProgrammerUser
    {
        private const long XpForSecondLevel = 50;
        private const int MultiplierForXpForNextLevel = 2;

        //public FakeProgrammerUser()
        //{
        //    this.Id = Guid.NewGuid().ToString();
        //    this.Roles = new HashSet<ProgrammerRole>();
        //    this.Courses = new HashSet<UserCourse>();
        //    this.Events = new HashSet<Event>();
        //    this.JobTasks = new HashSet<JobTask>();
        //    this.UserLectures = new HashSet<UserLecture>();
        //    this.UserDocumentations = new HashSet<UserDocumentation>();
        //}

        public string Id { get; set; }

        public string UserName { get; set; }

        public string Email { get; set; }

        public DateTime CreatedOn { get; set; }

        public DateTime? ModifiedOn { get; set; }

        public bool IsDeleted { get; set; }

        public DateTime? DeletedOn { get; set; }

        public long Xp { get; set; }

        public int Level { get; set; }

        public int Energy { get; set; }

        public decimal Money { get; set; }

        public int Bitcoins { get; set; }

        public bool IsActive { get; set; }

        public string TypeOfTask { get; set; }

        public long XpForNextLevel => this.Level == 1 ? XpForSecondLevel : this.Xp * MultiplierForXpForNextLevel;

        public DateTime? TaskTimeRemaining { get; set; }

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

        //public ICollection<UserCourse> Courses { get; set; }

        //public ICollection<UserLecture> UserLectures { get; set; }

        //public ICollection<Event> Events { get; set; }

        //public ICollection<JobTask> JobTasks { get; set; }

        //public ICollection<ProgrammerRole> Roles { get; set; }

        //public ICollection<UserDocumentation> UserDocumentations { get; set; }
    }
}
