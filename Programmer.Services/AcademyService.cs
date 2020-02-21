namespace Programmer.Services
{
    using Programmer.Data;
    using Programmer.Services.Dtos.Academy;
    using System.Linq;

    public class AcademyService : IAcademyService
    {
        private readonly ProgrammerDbContext context;

        public AcademyService(ProgrammerDbContext context)
        {
            this.context = context;
        }

        public AcademyAllCoursesDto GetAllCourses()
        {
            var courses = this.context.Courses
                .Select(c => new AcademyCourseDto
                {
                    Id = c.Id,
                    Name = c.Name,
                    Price = c.Price,
                    IsCompleted = c.IsCompleted,
                })
                .ToList();

            var dto = new AcademyAllCoursesDto { Courses = courses };

            return dto;
        }
    }
}
