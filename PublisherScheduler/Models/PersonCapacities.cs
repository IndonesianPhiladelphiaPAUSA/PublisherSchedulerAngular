using System;
using System.Collections.Generic;

namespace PublisherScheduler.Models
{
    public partial class PersonCapacities
    {
        public int Id { get; set; }
        public int PersonId { get; set; }
        public int CapacityId { get; set; }

        public virtual Capacities Capacity { get; set; }
        public virtual Persons Person { get; set; }
    }
}
