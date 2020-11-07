using System;
using System.Collections.Generic;

namespace PublisherScheduler.Models
{
    public partial class ProjectPersons
    {
        public int Id { get; set; }
        public int ProjectId { get; set; }
        public int PersonId { get; set; }

        public virtual Persons Person { get; set; }
        public virtual Projects Project { get; set; }
    }
}
