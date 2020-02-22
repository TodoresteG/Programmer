namespace Programmer.Models
{
    public class UserCourse
    {
        public string ProgrammerUserId { get; set; }

        public ProgrammerUser User { get; set; }

        public int CourseId { get; set; }

        public Course Course { get; set; }

        public bool IsCompleted { get; set; }

        public bool IsEnrolled { get; set; }
    }
}
