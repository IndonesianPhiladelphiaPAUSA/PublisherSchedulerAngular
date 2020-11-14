using System;
using System.Collections.Generic;

namespace PublisherScheduler.Models
{
    public partial class Persons
    {
        public Persons()
        {
            Assignments = new HashSet<Assignments>();
            PersonAvails = new HashSet<PersonAvails>();
            PersonCapacities = new HashSet<PersonCapacities>();
            PersonTrainings = new HashSet<PersonTrainings>();
            ProjectPersons = new HashSet<ProjectPersons>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public bool? IsActive { get; set; }
        public int? SecurityLevel { get; set; }
        public string Aspnetuserid { get; set; }

        public virtual ICollection<Assignments> Assignments { get; set; }
        public virtual ICollection<PersonAvails> PersonAvails { get; set; }
        public virtual ICollection<PersonCapacities> PersonCapacities { get; set; }
        public virtual ICollection<PersonTrainings> PersonTrainings { get; set; }
        public virtual ICollection<ProjectPersons> ProjectPersons { get; set; }
    }
}
