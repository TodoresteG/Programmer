namespace Programmer.App.ViewModels.Users
{
    using AutoMapper;
    using Programmer.Data.Models;
    using Programmer.Services.Mapping;

    public class UpdateUserAfterActivityApiModel : IMapFrom<ProgrammerUser>
    {
        public long Xp { get; set; }

        public long XpForNextLevel { get; set; }

        public int Level { get; set; }

        public double HardSkill { get; set; }

        public double SoftSkill { get; set; }

        public string HardSkillName { get; set; }

        public string SoftSkillName { get; set; }
    }
}
