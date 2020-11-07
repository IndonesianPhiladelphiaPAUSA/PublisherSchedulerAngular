using System;
using System.Collections.Generic;

namespace PublisherScheduler.Models
{
    public partial class PersonTaskTypes
    {
        public int Id { get; set; }
        public int TaskTypeId { get; set; }
        public int PersonId { get; set; }
    }
}
