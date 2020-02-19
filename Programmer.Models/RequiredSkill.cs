namespace Programmer.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class RequiredSkill
    {
        public RequiredSkill()
        {
            this.JobTasks = new HashSet<JobTask>();
        }

        [Key]
        public int Id { get; set; }

        public double RequiredHardSkillOne { get; set; }

        public double RequiredHardSkillTwo { get; set; }

        public double ReuqiredSoftSkill { get; set; }

        public ICollection<JobTask> JobTasks { get; set; }
    }
}
