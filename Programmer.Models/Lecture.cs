namespace Programmer.Data.Models
{
    using Programmer.Data.Common.Models;

    using System.Collections.Generic;

    public class Lecture : BaseDeletableModel<int>
    {
        public Lecture()
        {
            this.UserLectures = new HashSet<UserLecture>();
        }

        public string Name { get; set; }

        public int CourseId { get; set; }

        public Course Course { get; set; }

        public ICollection<UserLecture> UserLectures { get; set; }
    }
}
