namespace Programmer.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Lecture
    {
        public Lecture()
        {
            this.UserLectures = new HashSet<UserLecture>();
        }

        [Key]
        public int Id { get; set; }

        public string Name { get; set; }

        public int CourseId { get; set; }

        public Course Course { get; set; }

        public ICollection<UserLecture> UserLectures { get; set; }
    }
}
