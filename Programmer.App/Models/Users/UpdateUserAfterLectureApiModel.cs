namespace Programmer.App.Models.Users
{
    public class UpdateUserAfterLectureApiModel
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
