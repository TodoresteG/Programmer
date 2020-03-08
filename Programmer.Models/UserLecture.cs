namespace Programmer.Data.Models
{
    public class UserLecture
    {
        public string ProgrammerUserId { get; set; }

        public ProgrammerUser User { get; set; }

        public int LectureId { get; set; }

        public Lecture Lecture { get; set; }

        public bool IsCompleted { get; set; }

        public bool IsActive { get; set; }
    }
}
