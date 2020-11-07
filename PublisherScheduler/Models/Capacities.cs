using System;
using System.Collections.Generic;

namespace PublisherScheduler.Models
{
    public partial class Capacities
    {
        public Capacities()
        {
            PersonCapacities = new HashSet<PersonCapacities>();
            TaskTypeCapacities = new HashSet<TaskTypeCapacities>();
        }

        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<PersonCapacities> PersonCapacities { get; set; }
        public virtual ICollection<TaskTypeCapacities> TaskTypeCapacities { get; set; }
    }
}
