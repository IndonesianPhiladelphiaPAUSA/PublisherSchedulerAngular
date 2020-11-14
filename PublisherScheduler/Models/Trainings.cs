using System;
using System.Collections.Generic;

namespace PublisherScheduler.Models
{
    public partial class Trainings
    {
        public Trainings()
        {
            PersonTrainings = new HashSet<PersonTrainings>();
            Slots = new HashSet<Slots>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public virtual ICollection<PersonTrainings> PersonTrainings { get; set; }
        public virtual ICollection<Slots> Slots { get; set; }
    }
}
