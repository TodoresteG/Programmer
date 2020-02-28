namespace Programmer.App.Models.Users
{
    using System;

    public class UpdateUserAfterLectureApiModel
    {
        public long Xp { get; set; }

        public long XpForNextLevel { get; set; }

        public int Level { get; set; }

        public double HardSkill { get; set; }

        public double SoftSkill { get; set; }

        public TimeSpan? TaskTimeRemaining { get; set; }

        public bool IsActive { get; set; }
    }
}
