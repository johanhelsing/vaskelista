using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Vaskelista.Models
{
    public class Task
    {
        public Int32 TaskId { get; set; }

        [Required]
        public virtual Household Household { get; set; }
        public Int32 HouseholdId { get; set; }

        [Required]
        [Display(Name = "Oppgavenavn")]
        public string Name { get; set; }

        [Display(Name = "Beskrivelse")]
        public string Description { get; set; }

        [DataType(DataType.Date)]
        public DateTime Start { get; set; }

        [Required]
        [Display(Name = "Dager")]
        public Weekday Days { get; set; }

        [Display(Name = "Rom")]
        public virtual Room Room { get; set; }
        public Int32? RoomId { get; set; }
    }
}