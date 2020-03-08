namespace Programmer.Data.Models
{
    using Microsoft.AspNetCore.Identity;
    using Programmer.Data.Common.Models;
    using System;

    public class ProgrammerRole : IdentityRole<string>, IAuditInfo, IDeletableEntity
    {
        public ProgrammerRole()
            : this(null)
        {
        }

        public ProgrammerRole(string name)
            : base(name)
        {
            this.Id = Guid.NewGuid().ToString();
        }

        public DateTime CreatedOn { get; set; }

        public DateTime? ModifiedOn { get; set; }

        public bool IsDeleted { get; set; }

        public DateTime? DeletedOn { get; set; }
    }
}
