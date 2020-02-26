namespace Programmer.Services.Dtos.Academy
{
    public class AcademyCourseDto
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public decimal Price { get; set; }

        public bool IsEnrolled { get; set; }
    }
}
