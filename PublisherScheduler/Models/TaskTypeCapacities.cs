using System;
using System.Collections.Generic;

namespace PublisherScheduler.Models
{
    public partial class TaskTypeCapacities
    {
        public int Id { get; set; }
        public int TaskTypeId { get; set; }
        public int CapacityId { get; set; }

        public virtual Capacities Capacity { get; set; }
        public virtual TaskTypes TaskType { get; set; }
    }
}
