namespace Programmer.App.ViewModels.Courses
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using Microsoft.AspNetCore.Mvc.Rendering;

    public class AdministrationCreateCourseInputModel
    {
        [Required]
        [StringLength(40, ErrorMessage = "Name must be between {0} and {2} characters", MinimumLength = 3)]
        public string Name { get; set; }

        [Range(100, (double)decimal.MaxValue, ErrorMessage = "Price cannot be less than {1}")]
        public decimal Price { get; set; }

        public IEnumerable<SelectListItem> HardSkillNames { get; set; }

        [Required]
        public string HardSkillName { get; set; }

        [Range(0, double.MaxValue, ErrorMessage = "HardSkillReward cannot be less than {1}")]
        public double HardSkillReward { get; set; }

        public IEnumerable<SelectListItem> SoftSkillNames { get; set; }

        [Required]
        public string SoftSkillName { get; set; }

        [Range(0, double.MaxValue, ErrorMessage = "SoftSkillReward cannot be less than {1}")]
        public double SoftSkillReward { get; set; }

        [Range(0, 20, ErrorMessage = "SoftSkillReward cannot be less than {0} and higher than {1}")]
        public int RequiredEnergy { get; set; }

        [Range(0, int.MaxValue, ErrorMessage = "SoftSkillReward cannot be less than {0}")]
        public int XpReward { get; set; }
    }
}
