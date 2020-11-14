using System;
using System.Collections.Generic;

namespace PublisherScheduler.Models
{
    public partial class PersonAvails
    {
        public int Id { get; set; }
        public DateTime BeginTime { get; set; }
        public DateTime EndTime { get; set; }
        public bool IsAvailable { get; set; }
        public int PersonId { get; set; }

        public virtual Persons Person { get; set; }
    }
}
