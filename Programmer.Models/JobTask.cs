namespace Programmer.Models
{
    using Programmer.Data.Common.Models;
    using System;

    public class JobTask : BaseDeletableModel<int>
    {
        public string Name { get; set; }

        // TODO: Jobtasks Types in different table
        // public JobTaskType Type { get; set; }

        public int RequiredEnergy { get; set; }

        public TimeSpan TimeNeeded { get; set; }

        public decimal MoneyReward { get; set; }

        public string ProgrammerUserId { get; set; }

        public ProgrammerUser Player { get; set; }

        public int RequiredSkillId { get; set; }

        public RequiredSkill RequiredSkills { get; set; }
    }
}
