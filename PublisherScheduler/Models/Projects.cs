using System;
using System.Collections.Generic;

namespace PublisherScheduler.Models
{
    public partial class Projects
    {
        public Projects()
        {
            ProjectPersons = new HashSet<ProjectPersons>();
            Slots = new HashSet<Slots>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int? IsActive { get; set; }

        public virtual ICollection<ProjectPersons> ProjectPersons { get; set; }
        public virtual ICollection<Slots> Slots { get; set; }
    }
}
