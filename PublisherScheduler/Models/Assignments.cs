using System;
using System.Collections.Generic;

namespace PublisherScheduler.Models
{
    public partial class Assignments
    {
        public int Id { get; set; }
        public int SlotId { get; set; }
        public int PersonId { get; set; }
        public int LocationId { get; set; }

        public virtual Locations Location { get; set; }
        public virtual Persons Person { get; set; }
        public virtual Slots Slot { get; set; }
    }
}
