namespace Programmer.Services.Dtos.Lectures
{
    public class LectureDetailsDto
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int RequiredEnergy { get; set; }

        public string TimeNeeded { get; set; }

        public double HardSkillReward { get; set; }

        public string HardSkillName { get; set; }

        public double SoftSkillReward { get; set; }

        public string SoftSkillName { get; set; }

        public int XpReward { get; set; }
    }
}
