using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Vaskelista.Models
{
    public class Activity
    {
        public Int32 ActivityId { get; set; }

        public virtual Household Household { get; set; }
        public Int32 HouseholdId { get; set; }

        [Required]
        [Display(Name = "Oppgavenavn")]
        public string Name { get; set; }

        [Display(Name = "Beskrivelse")]
        public string Description { get; set; }

        public virtual Room Room { get; set; }
        public Int32? RoomId { get; set; }

        public virtual ScheduleElement ScheduleElement {get; set;}
        public Int32? ScheduleElementId { get; set; }

    }
}