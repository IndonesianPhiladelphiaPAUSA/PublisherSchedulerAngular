using System;
using System.Collections.Generic;

namespace PublisherScheduler.Models
{
    public partial class TaskTypes
    {
        public TaskTypes()
        {
            Slots = new HashSet<Slots>();
            TaskTypeCapacities = new HashSet<TaskTypeCapacities>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public int ProjectId { get; set; }
        public int? IsActive { get; set; }

        public virtual ICollection<Slots> Slots { get; set; }
        public virtual ICollection<TaskTypeCapacities> TaskTypeCapacities { get; set; }
    }
}
