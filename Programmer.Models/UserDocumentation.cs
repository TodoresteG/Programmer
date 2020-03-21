using System;
using System.Collections.Generic;
using System.Text;
using Programmer.Data.Common.Models;

namespace Programmer.Data.Models
{
    public class UserDocumentation
    {
        public string ProgrammerId { get; set; }

        public ProgrammerUser User { get; set; }

        public int DocumentationId { get; set; }

        public Documentation Documentation { get; set; }
    }
}
