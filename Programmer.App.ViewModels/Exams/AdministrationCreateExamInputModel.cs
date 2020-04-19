namespace Programmer.App.ViewModels.Exams
{
    using System.ComponentModel.DataAnnotations;

    public class AdministrationCreateExamInputModel
    {
        [Range(0, 30, ErrorMessage = "{0} cannot be less than {1} and more than {2}")]
        public int RequiredEnergy { get; set; }

        [Range(0, double.MaxValue, ErrorMessage = "{0} cannot be less than {1} and more than {2}")]
        public double RequiredHardSkill { get; set; }

        [Range(0, double.MaxValue, ErrorMessage = "{0} cannot be less than {1} and more than {2}")]
        public double RequiredCodingSkill { get; set; }

        [Required]
        public string RequiredHardSkillName { get; set; }

        public int CourseId { get; set; }
    }
}
