using System;
using System.Collections.Generic;

namespace PublisherScheduler.Models
{
    public partial class Slots
    {
        public Slots()
        {
            Assignments = new HashSet<Assignments>();
        }

        public int Id { get; set; }
        public int ProjectId { get; set; }
        public DateTime BeginTime { get; set; }
        public DateTime EndTime { get; set; }
        public int? IsActive { get; set; }
        public string Description { get; set; }
        public int TaskTypeId { get; set; }
        public int? TrainingId { get; set; }

        public virtual Projects Project { get; set; }
        public virtual TaskTypes TaskType { get; set; }
        public virtual Trainings Training { get; set; }
        public virtual ICollection<Assignments> Assignments { get; set; }
    }
}
