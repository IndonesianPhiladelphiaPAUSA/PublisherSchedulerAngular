using System;
using System.Collections.Generic;

namespace PublisherScheduler.Models
{
    public partial class Locations
    {
        public Locations()
        {
            Assignments = new HashSet<Assignments>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public int? IsActive { get; set; }

        public virtual ICollection<Assignments> Assignments { get; set; }
    }
}
