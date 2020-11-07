using System;
using System.Collections.Generic;

namespace PublisherScheduler.Models
{
    public partial class PersonTrainings
    {
        public int Id { get; set; }
        public int PersonId { get; set; }
        public int? TrainingId { get; set; }

        public virtual Persons Person { get; set; }
        public virtual Trainings Training { get; set; }
    }
}
