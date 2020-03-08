namespace Programmer.Services.Dtos
{
    using Programmer.Data.Models;
    using Programmer.Services.Mapping;

    public class UserStatsDto : IMapFrom<ProgrammerUser>
    {
        public long Xp { get; set; }

        public int Level { get; set; }

        public int Energy { get; set; }

        public bool IsActive { get; set; }

        public decimal Money { get; set; }

        public int Bitcoins { get; set; }

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
    }
}
